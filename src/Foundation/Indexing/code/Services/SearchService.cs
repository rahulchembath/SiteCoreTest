using Claro.Foundation.Indexing.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using System;
using System.Linq;

namespace Claro.Foundation.Indexing.Services
{
    public class SearchService : ISearchService
    {
        public virtual ISearchResults SearchBlogs(IQuery query)
        {
            try
            {
                using (var context = ContentSearchManager.GetIndex(Constants.Claro_Blog_Index).CreateSearchContext())
                {
                    var queryable = this.CreateAndInitializeQuery(context);


                    if (!string.IsNullOrEmpty(query.Category))
                    {
                        queryable = AddCategoryFilter(queryable, query);
                    }
                    if (query.ExcludeArticles != null && query.ExcludeArticles.Any())
                    {
                        queryable = FilterFeatureArticle(queryable, query);
                    }
                    if (!string.IsNullOrEmpty(query.SearchText))
                    {
                        queryable = SearchText(queryable, query);
                    }
                    queryable = this.AddPaging(queryable, query);
                    queryable = AddOrderBy(queryable, query);
                    var results = queryable.GetResults();
                    return new SearchResults { PageSize = query.Page, PageNo = query.NoOfResults, Results = results.Hits.Select(searchItem => CreateSearchResult(searchItem.Document)) };
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return null;
        }
        private IQueryable<SearchResultItem> SearchText(IQueryable<SearchResultItem> queryable, IQuery query)
        {
            var contentPredicates = PredicateBuilder.False<IndexedItem>();
            string[] searchParts = query.SearchText.Trim().Split(' ');
            foreach (var searchItem in searchParts)
            {
                contentPredicates = contentPredicates.Or(i => i.Blog_Title.Contains(searchItem));
                contentPredicates = contentPredicates.Or(i => i.Blog_Intro.Contains(searchItem));
                contentPredicates = contentPredicates.Or(i => i.Blog_Description.Contains(searchItem));
                contentPredicates = contentPredicates.Or(i => i.BlogCategoryText.Contains(searchItem));
                contentPredicates = contentPredicates.Or(i => i.Blog_Author.Contains(searchItem));
            }
            return queryable.Cast<IndexedItem>().Where(contentPredicates);
        }
        private IQueryable<SearchResultItem> AddCategoryFilter(IQueryable<SearchResultItem> queryable, IQuery query)
        {
            return queryable.Cast<IndexedItem>().Where(item => item.Blog_Categories.Contains(query.Category));
        }
        private IQueryable<SearchResultItem> FilterFeatureArticle(IQueryable<SearchResultItem> queryable, IQuery query)
        {
            foreach (var articleId in query.ExcludeArticles)
            {
                ID articleItemId;
                if (ID.TryParse(articleId, out articleItemId))
                {
                    queryable = queryable.Where(item => item.ItemId != articleItemId);
                }
            }

            return queryable;
        }
        private IQueryable<SearchResultItem> AddOrderBy(IQueryable<SearchResultItem> querable, IQuery query)
        {
            return querable.Cast<IndexedItem>().OrderByDescending(item => item.Blog_CreatedDate);
        }
        private IQueryable<SearchResultItem> AddPaging(IQueryable<SearchResultItem> queryable, IQuery query)
        {
            return queryable.Page(query.Page < 0 ? 0 : query.Page, query.NoOfResults <= 0 ? 10 : query.NoOfResults);
        }
        private IQueryable<SearchResultItem> CreateAndInitializeQuery(IProviderSearchContext context)
        {
            var queryable = context.GetQueryable<SearchResultItem>();
            return queryable;
        }
        private Models.ISearchResult CreateSearchResult(SearchResultItem result)
        {
            var formattedResult = new SearchResult { ItemID = result.ItemId };
            return formattedResult;
        }
    }
}