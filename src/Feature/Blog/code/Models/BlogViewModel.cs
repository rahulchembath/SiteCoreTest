using System;
using System.Web;

namespace Claro.Feature.Blog.Models
{
    public class BlogViewModel
    {
        public HtmlString Title { get; set; }
        public HtmlString Intro { get; set; }
        public HtmlString Description { get; set; }
        public HtmlString BlogImage { get; set; }
        public DateTime BlogCreated { get; set; }
        public bool IsFeaturedBlog { get; set; }
        public int CommentCount { get; set; }
        public int ViewCount { get; set; }
        public HtmlString AuthorImage { get; set; }
        public HtmlString AuthorFirstName { get; set; }
        public HtmlString AuthorLastName { get; set; }
        public HtmlString AuthorDescription { get; set; }
        public string BlogUrl { get; set; }

        public string BlogId { get; set; }
    }
}