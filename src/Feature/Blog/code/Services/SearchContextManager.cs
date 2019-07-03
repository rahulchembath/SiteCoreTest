using Claro.Feature.Blog.Interface;
using Claro.Feature.Blog.Models;
using Claro.Foundation.Content.Repositories;
using Claro.Foundation.Indexing.Models;
using Claro.Foundation.Indexing.Services;
using Claro.Foundation.Settings.Models;
using Glass.Mapper.Sc;
using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Web;

namespace Claro.Feature.Blog.Services
{
    public class SearchContextManager : ISearchContextManager
    {
        private readonly IContextRepository _contextRepository;
        private readonly IContentRepository _contentRepository;
        private readonly ISearchService _searchService;
        private readonly IConverter<IBlog, BlogViewModel> _blogViewModelConverter;
        public SearchContextManager(IContextRepository contextRepository, IContentRepository contentRepository, ISearchService searchService, 
           IConverter<IBlog, BlogViewModel> blogViewModelConverter)
        {
            _contextRepository = contextRepository;
            _contentRepository = contentRepository;
            _searchService = searchService;
            _blogViewModelConverter = blogViewModelConverter;
        }
        public SearchContext Get()
        {
            var query = HttpContext.Current == null ? "" : HttpContext.Current.Request[Constants.SearchQuery];
            SearchContext searchContext = new SearchContext();
            searchContext.Query = query;
            try
            {
                ISearchSettings searchSettings = _contextRepository.GetRootItem<ISearchSettings>();
                if (searchSettings != null)
                {
                    if (!string.IsNullOrEmpty(searchSettings.SearchPageUrl))
                    {
                        var item = _contentRepository.GetItem<Item>(new GetItemByPathOptions { Path = searchSettings.SearchPageUrl });
                        if (item != null)
                        {
                            searchContext.SearchPageUrl = LinkManager.GetItemUrl(item);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(searchContext.SearchPageUrl))
                {
                    searchContext.SearchPageUrl = Constants.SearchPage;
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return searchContext;
        }
        public List<BlogViewModel> GetBlogs(IQuery searchQuery, bool isFeatureBlog = false)
        {
            List<BlogViewModel> model = new List<BlogViewModel>();
            BlogViewModel modelItem = null;
            try
            {
                if (searchQuery != null)
                {
                    var searchList = _searchService.SearchBlogs(searchQuery);
                    if (searchList != null && searchList.Results != null)
                    {
                        foreach (var result in searchList.Results)
                        {
                            IBlog blog = _contentRepository.GetItem<IBlog>(new GetItemByIdOptions { Id = result.ItemID.Guid });
                            if (blog != null)
                            {
                                modelItem = isFeatureBlog ? _blogViewModelConverter.ConvertTo(blog, true) : _blogViewModelConverter.ConvertTo(blog);
                               // modelItem.CommentCount = _commentService.GetCommentsCount(blog.Id.ToString());
                                model.Add(modelItem);                               
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return model;
        }      
    }
}