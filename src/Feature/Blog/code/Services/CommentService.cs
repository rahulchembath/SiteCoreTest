using Claro.Feature.Blog.Models;
using Claro.Foundation.Content.Repositories;
using Glass.Mapper.Sc;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using Sitecore.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Claro.Feature.Blog.Services
{
    public class CommentService : ICommentService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IContextRepository _contextRepository;
        public CommentService(IContentRepository contentRepository, IContextRepository contextRepository)
        {
            _contentRepository = contentRepository;
            _contextRepository = contextRepository;
        }
        public bool CreateComment(CommentViewModel model)
        {
            Item newItem = null;
            try
            {
                if (model != null)
                {
                    using (new SecurityDisabler())
                    {

                        Database masterDb =
                        Sitecore.Configuration.Factory.GetDatabase("master");
                        if (masterDb != null)
                        {
                            Item parentItem = masterDb.GetItem(ID.Parse(model.parentId));
                            TemplateItem template = masterDb.GetTemplate(Templates.Comment.ID);
                            if (template != null)
                            {
                                newItem = parentItem.Add(Constants.Comment, template);
                                newItem.Editing.BeginEdit();
                                newItem[Constants.FirstName] = model.FirstName;
                                newItem[Constants.LastName] = model.LastName;
                                newItem[Constants.CompanyName] = model.CompanyName;
                                newItem[Constants.Email] = model.Email;
                                newItem[Constants.Comments] = model.Comment;
                                AssignWorkflow(newItem, masterDb);
                                newItem.Editing.EndEdit();
                            }
                        }

                    }

                    return true;
                }
            }

            catch (Exception ex)
            {
                if (newItem != null)
                    newItem.Editing.CancelEdit();
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return false;
        }

        public List<CommentViewModel> GetComments(string parentItemId)
        {
            ID parentId;
            List<CommentViewModel> model = new List<CommentViewModel>();
            try
            {
                if (ID.TryParse(parentItemId, out parentId))
                {
                    var parentItem = _contentRepository.GetItem<Item>(new GetItemByIdOptions { Id = parentId.Guid });
                    if (parentItem != null)
                    {
                        var comments = parentItem.Children.ToArray().OrderByDescending(item => item.Statistics?.Created);
                        foreach (Item comment in comments)
                        {
                            IComment commentItem = _contentRepository.GetItem<IComment>(new GetItemByItemOptions { Item = comment });

                            if (commentItem != null)
                            {
                                CommentViewModel commentModel = new CommentViewModel
                                {
                                    FirstName = commentItem.FirstName,
                                    LastName = commentItem.LastName,
                                    CompanyName = commentItem.CompanyName,
                                    Email = commentItem.Email,
                                    Comment = commentItem.Comment,
                                    Created = comment.Statistics != null ? comment.Statistics.Created : DateTime.MinValue
                                };
                                model.Add(commentModel);
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

        public int GetCommentsCount(string parentItemId)
        {
            ID parentId;
            if (ID.TryParse(parentItemId, out parentId))
            {
                var parentItem = _contentRepository.GetItem<Item>(new GetItemByIdOptions { Id = parentId.Guid });
                if (parentItem != null)
                {
                    return parentItem.Children != null ? parentItem.Children.Count : 0;
                }
            }
            return 0;
        }
        private void AssignWorkflow(Item item, Database masterDb)
        {
            IWorkflow wf = masterDb.WorkflowProvider.GetWorkflow(Constants.WorkflowId);
            wf.Start(item);
            string sitecoreUser = Sitecore.Configuration.Settings.GetSetting("SitecoreUser", "sitecore\admin");
            var user = Sitecore.Security.Accounts.User.FromName(sitecoreUser, false);
            using (new Sitecore.Security.Accounts.UserSwitcher(user))
            {
                using (new EditContext(item))
                {
                    item[FieldIDs.WorkflowState] = Constants.WorkflowStateId;
                }
            }
        }
    }
}