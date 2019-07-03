using System;
using System.Collections.Generic;

namespace Claro.Feature.Blog.Models
{
    public class CommentViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public string parentId { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<Sitecore.Data.SignInUrlInfo> signinURLInfo { get; set; }
    }
}