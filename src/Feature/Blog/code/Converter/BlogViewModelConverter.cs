using Claro.Feature.Blog.Interface;
using Claro.Feature.Blog.Models;
using Claro.Feature.Blog.Services;
using Glass.Mapper.Sc;
using System.Web;

namespace Claro.Feature.Blog.Converter
{
    public class BlogViewModelConverter : IConverter<IBlog, BlogViewModel>
    {
        private readonly IGlassHtml _glassHtml;
        private readonly ICommentService _commentService;
        public BlogViewModelConverter(IGlassHtml glassHtml, ICommentService commentService)
        {
            _glassHtml = glassHtml;
            _commentService = commentService;
        }
        public BlogViewModel ConvertTo(IBlog blog, bool isFeaturedArticle)
        {
            return new BlogViewModel
            {
                BlogId = blog.Id.ToString(),
                Title = new HtmlString(_glassHtml.Editable(blog, item => item.Title)),
                Intro = new HtmlString(_glassHtml.Editable(blog, item => item.Intro)),
                Description = new HtmlString(_glassHtml.Editable(blog, item => item.Description)),
                BlogImage = isFeaturedArticle ? new HtmlString(_glassHtml.RenderImage(blog, item => item.FeatureImage, new { @class = Constants.BlogImageClassName })) : new HtmlString(_glassHtml.RenderImage(blog, item => item.LandingBoxImage, new { @class = Constants.BlogImageWithFluidClassName })),
                BlogCreated = blog.BlogCreated,
                AuthorFirstName = blog.Author != null ? new HtmlString(_glassHtml.Editable(blog, item => item.Author.FirstName)) : null,
                AuthorLastName = blog.Author != null ? new HtmlString(_glassHtml.Editable(blog, item => item.Author.LastName)) : null,
                AuthorImage = blog.Author != null ? new HtmlString(_glassHtml.RenderImage(blog, item => item.Author.Image, new { @class = isFeaturedArticle ? Constants.AuthorImageClassName : Constants.ImageFluidClassName })) : null,
                AuthorDescription = blog.Author != null ? new HtmlString(_glassHtml.Editable(blog, item => item.Author.AuthorSummary)) : null,
                BlogUrl = blog.Url,
                CommentCount = _commentService.GetCommentsCount(blog.Id.ToString())
            };
        }
    }
}