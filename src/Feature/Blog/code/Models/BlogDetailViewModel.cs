using System;
using System.Web;

namespace Claro.Feature.Blog.Models
{
    public class BlogDetailViewModel
    {
        public HtmlString Title { get; set; }
        public HtmlString Intro { get; set; }
        public HtmlString Description { get; set; }
        public HtmlString BlogImage { get; set; }
        public DateTime BlogCreated { get; set; }
    }
}