using Claro.Feature.Blog.Interface;
using Claro.Feature.Blog.Models;
using Claro.Feature.Blog.Services;
using Glass.Mapper.Sc;
using System.Web;

namespace Claro.Feature.Blog.Converter
{
    public class BlogDetailsViewModelConverter : IConverter<IBlog, BlogDetailViewModel>
    {
        private readonly IGlassHtml _glassHtml;
        public BlogDetailsViewModelConverter(IGlassHtml glassHtml, ICommentService commentService)
        {
            _glassHtml = glassHtml;
        }
        public BlogDetailViewModel ConvertTo(IBlog blog, bool isFeaturedArticle = false)
        {
            return new BlogDetailViewModel
            {
                Title = new HtmlString(_glassHtml.Editable(blog, item => item.Title)),
                Intro = new HtmlString(_glassHtml.Editable(blog, item => item.Intro)),
                Description = new HtmlString(_glassHtml.Editable(blog, item => item.Description)),
                BlogImage = new HtmlString(_glassHtml.RenderImage(blog, item => item.HeroImage)),
                BlogCreated = blog.BlogCreated               
            };
        }
    }
}