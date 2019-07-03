using Claro.Feature.Blog.Models;
using Claro.Feature.Blog.Services;
using Claro.Foundation.Content.Repositories;
using Claro.Foundation.Indexing.Models;
using Glass.Mapper.Sc;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System;
using Claro.Feature.Blog.Interface;

namespace Claro.Feature.Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IRenderingRepository _renderingRepository;
        private readonly IQuoteService _quoteService;
        private readonly ISearchContextManager _searchContextManager;
        private readonly IConverter<IBlog, BlogDetailViewModel> _blogDetailViewModelConverter;
        private readonly IConverter<IBlog, BlogViewModel> _blogViewModelConverter;
        public BlogController(IRenderingRepository renderingRepository, IQuoteService quoteService, ISearchContextManager searchContextManager,
            IConverter<IBlog, BlogDetailViewModel> blogDetailViewModelConverter, IConverter<IBlog, BlogViewModel> blogViewModelConverter)
        {
            _renderingRepository = renderingRepository;
            _quoteService = quoteService;
            _searchContextManager = searchContextManager;
            _blogDetailViewModelConverter = blogDetailViewModelConverter;
            _blogViewModelConverter = blogViewModelConverter;
        }
        // GET: Blog
        [HttpGet]
        public ActionResult FeaturedArticle()
        {
            BlogViewModel model = null;
            try
            {
                IBlog blog = _renderingRepository.GetDataSourceItem<IBlog>();
                if (blog != null)
                {
                    model = _blogViewModelConverter.ConvertTo(blog, true);
                    System.Web.HttpContext.Current.Items.Add(Constants.featuredArticleID, blog.Id.ToString());
                }
                else
                {
                    string category = HttpUtility.UrlDecode(System.Web.HttpContext.Current.Request.QueryString[Constants.categoryQueryString]);
                    var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, Category = string.IsNullOrEmpty(category) ? category : category.ToLower() };
                    var blogList = _searchContextManager.GetBlogs(searchQuery, true);
                    if (blogList != null && blogList.Any())
                    {
                        model = blogList.First();
                        System.Web.HttpContext.Current.Items.Add(Constants.featuredArticleID, model.BlogId);
                    }
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return View(Constants.FeaturedArticle, model);
        }

        [HttpGet]
        public ActionResult BlogList()
        {
            BlogListViewModel model = new BlogListViewModel { Blogs = new List<BlogViewModel>() };
            try
            {
                //get the featureArticleId from the  current context which was set in the FeatureArticle Action call
                string featureArticleId = System.Web.HttpContext.Current.Items[Constants.featuredArticleID] as string;
                model.FeatureArticleId = featureArticleId;

                //Get the PageContext item to check whether it is home page,then only quotes need to show
                string contextItemName = _renderingRepository.GetPageContextItem<Item>()?.Name;
                model.IsQuotesRequired = string.IsNullOrEmpty(contextItemName) ? false : contextItemName.ToLower() == Constants.HomeItemName ? true : false;
                string category = HttpUtility.UrlDecode(System.Web.HttpContext.Current.Request.QueryString[Constants.categoryQueryString]);
                category = string.IsNullOrEmpty(category) ? category : category.ToLower();
                model.Category = category;
                //get the blogs from solr based on page no and page size
                var searchQuery = new SearchQuery { NoOfResults = model.IsQuotesRequired ? Constants.NoOfBlogsWithQuotes : Constants.NoOfBlogs, Page = Constants.IntialPageNo, Category = category, ExcludeArticles = new List<string> { featureArticleId } };
                var blogList = _searchContextManager.GetBlogs(searchQuery);
                if (blogList != null && blogList.Any())
                {
                    model.Blogs.AddRange(blogList);
                }
                if (model.IsQuotesRequired)
                {
                    GetQuote(Constants.IntialPageNo, model);
                }

            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return View(Constants.BlogList, model);
        }
        public ActionResult GetBlogs(int pageNo, string featureArticleId, string category)
        {
            BlogListViewModel model = new BlogListViewModel { Blogs = new List<BlogViewModel>() };
            try
            {
                model.IsQuotesRequired = string.IsNullOrEmpty(category) ? true : false;
                var searchQuery = new SearchQuery { NoOfResults = model.IsQuotesRequired ? Constants.NoOfBlogsWithQuotes : Constants.NoOfBlogs, Page = pageNo, Category = category, ExcludeArticles = new List<string> { featureArticleId } };
                var blogList = _searchContextManager.GetBlogs(searchQuery);
                if (blogList != null && blogList.Any())
                {
                    model.Blogs.AddRange(blogList);
                }
                if (model.IsQuotesRequired)
                {
                    GetQuote(pageNo, model);
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return PartialView(Constants.BlogPartialPage, model);
        }
        public ActionResult BlogDetails()
        {
            BlogDetailViewModel blogDetailViewModel = null;
            try
            {
                IBlog blog = _renderingRepository.GetPageContextItem<IBlog>();
                if (blog != null)
                {
                    blogDetailViewModel = _blogDetailViewModelConverter.ConvertTo(blog);
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return View(Constants.BlogDetailsViewName, blogDetailViewModel);
        }
        public ActionResult RelatedBlog()
        {
            BlogViewModel blogViewModel = null;
            try
            {
                BlogViewModel contextBlogViewModel = System.Web.HttpContext.Current.Items[Constants.RelatedBlog] as BlogViewModel;

                if (contextBlogViewModel != null)
                {
                    blogViewModel = contextBlogViewModel;
                }
                else
                {
                    IBlog contextBlog = _renderingRepository.GetPageContextItem<IBlog>();
                    if (contextBlog != null)
                    {
                        string category = contextBlog.Categories.FirstOrDefault()?.CategoryTitle;
                        category = string.IsNullOrEmpty(category) ? category : category.ToLower();
                        var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, Category = category, ExcludeArticles = new List<string> { contextBlog.Id.ToString() } };
                        var blogList = _searchContextManager.GetBlogs(searchQuery);
                        if (blogList != null && blogList.Any())
                        {
                            blogViewModel = blogList.First();
                            string featureArticleId = System.Web.HttpContext.Current.Items[Constants.featuredArticleID] as string;
                            System.Web.HttpContext.Current.Items.Add(Constants.RelatedBlogID, blogList.First().BlogId);
                            System.Web.HttpContext.Current.Items.Add(Constants.RelatedBlog, blogViewModel);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return View(Constants.RelatedBlogViewName, blogViewModel);
        }
        public ActionResult OtherInsight()
        {
            List<BlogViewModel> blogListViewModel = new List<BlogViewModel>();
            List<string> ExcludeArticles = new List<string>();
            try
            {
                IBlog contextBlog = _renderingRepository.GetPageContextItem<IBlog>();
                if (contextBlog != null)
                {
                    ExcludeArticles.Add(contextBlog.Id.ToString());
                }
                //Related Blog Id
                string relatedArticleId = System.Web.HttpContext.Current.Items[Constants.RelatedBlogID] as string;
                if (!string.IsNullOrEmpty(relatedArticleId))
                {
                    ExcludeArticles.Add(relatedArticleId);
                }
                var searchQuery = new SearchQuery { NoOfResults = Constants.OtherInsight_BlogNo, Page = Constants.IntialPageNo, ExcludeArticles = ExcludeArticles };
                blogListViewModel = _searchContextManager.GetBlogs(searchQuery);
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return View(Constants.OtherInsightViewName, blogListViewModel);
        }
        /// <summary>
        /// Get the quotes
        /// </summary>
        /// <param name="pageLevel"></param>
        /// <param name="model"></param>
        private void GetQuote(int pageLevel, BlogListViewModel model)
        {
            GetQuotePosition(pageLevel, model);
            IQuote quote = _quoteService.GetQuotes(pageLevel);
            if (quote != null)
            {
                model.Quote = quote.Summary;
                model.QuotesAuthor = quote.Author?.FirstName + " " + quote.Author?.LastName;
            }
        }
        /// <summary>
        /// Check the quote location and position
        /// </summary>
        /// <param name="pageLevel"></param>
        /// <param name="model"></param>
        private void GetQuotePosition(int pageLevel, BlogListViewModel model)
        {
            if (pageLevel == 0 || (pageLevel % 2) == 0)
            {
                model.QuotePosition = (Constants.QuoteRow * Constants.blogsInEachRow) - 1;
                model.IsQuoteLocationRight = true;
            }
            else
            {
                model.QuotePosition = (Constants.QuoteRow * Constants.blogsInEachRow) - 2;
                model.IsQuoteLocationRight = false;
            }
        }
    }
}