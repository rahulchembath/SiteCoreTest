using Claro.Feature.Blog.Models;
using Claro.Feature.Blog.Services;
using Claro.Foundation.Indexing.Models;
using System;
using System.Web.Mvc;

namespace Claro.Feature.Blog.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchContextManager _searchContextManager;
        public SearchController(ISearchContextManager searchContextManager)
        {
            _searchContextManager = searchContextManager;

        }
        // GET: Search
        public ActionResult GlobalSearch()
        {
            SearchContext model = new SearchContext();
            try
            {
                model = _searchContextManager.Get();
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return View(Constants.GlobalSearchViewName, model);
        }
        public ActionResult SearchHeader()
        {
            SearchContext model = new SearchContext();
            try
            {
                model = _searchContextManager.Get();
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return View(Constants.SearchHeaderViewName, model);
        }
        public ActionResult SearchResults(string query)
        {
            BlogListViewModel model = new BlogListViewModel();
            try
            {
                if (!string.IsNullOrEmpty(query))
                {
                    var searchQuery = new SearchQuery { NoOfResults = Constants.NoOfBlogs, Page = Constants.IntialPageNo, SearchText = query };
                    model.Blogs = _searchContextManager.GetBlogs(searchQuery);
                }
            }
            catch(Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }       
            return View(Constants.SearchResultsViewName,model);
        }
        public ActionResult SearchBlogs(int pageNo, string query)
        {

            BlogListViewModel model = new BlogListViewModel();
            try
            {
                if (!string.IsNullOrEmpty(query))
                {
                    var searchQuery = new SearchQuery { NoOfResults = Constants.NoOfBlogs, Page = pageNo, SearchText = query };
                    model.Blogs = _searchContextManager.GetBlogs(searchQuery);
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return PartialView(Constants.SearchBlogResultsViewName, model);
        }      
    }
}