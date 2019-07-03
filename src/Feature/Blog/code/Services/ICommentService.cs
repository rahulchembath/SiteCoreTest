using Claro.Feature.Blog.Models;
using System.Collections.Generic;
using Sitecore.Data.Items;
namespace Claro.Feature.Blog.Services
{
    public interface ICommentService
    {
        List<CommentViewModel> GetComments(string parentItemId);
        bool CreateComment(CommentViewModel model);
        int GetCommentsCount(string parentItemId);
    }
}
