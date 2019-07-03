using Claro.Feature.Blog.Models;
using Claro.Feature.Blog.Services;
using Claro.Foundation.Content.Repositories;
using Claro.Foundation.Dictionary.Repositories;
using Sitecore.Pipelines.GetSignInUrlInfo;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Claro.Feature.Blog.Controllers
{
    public class CommentController : Controller
    {
        private readonly IRenderingRepository _renderingRepository;
        private readonly ICommentService _commentService;
        private readonly IDictionaryPhraseRepository _dictionaryPhraseRepository;
        public CommentController(IRenderingRepository renderingRepository, ICommentService commentService, IDictionaryPhraseRepository dictionaryPhraseRepository)
        {
            _renderingRepository = renderingRepository;
            _commentService = commentService;
            _dictionaryPhraseRepository = dictionaryPhraseRepository;
        }
        // GET: Comment
        [HttpGet]
        public ActionResult LeaveComment()
        {
            string[] names = null;
            CommentViewModel model = new CommentViewModel();
            try
            {
                CommentViewModel commentModel = System.Web.HttpContext.Current.Session[Constants.CommentModel] as CommentViewModel;
                if (commentModel != null)
                {
                    model = commentModel;
                    System.Web.HttpContext.Current.Session[Constants.CommentModel] = null;
                }

                IBlog blog = _renderingRepository.GetPageContextItem<IBlog>();
                if (blog != null)
                {
                    model.parentId = blog.Id.ToString();
                }
                if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    string fullName = Sitecore.Context.User.Profile != null ? Sitecore.Context.User.Profile.FullName : string.Empty;
                    if (!string.IsNullOrEmpty(fullName) && !Sitecore.Context.User.IsAdministrator)
                    {
                        if (Sitecore.Context.User.Profile.Comment == Constants.GoogleLogin)
                        {
                            names = Regex.Split(fullName, @"(?<!^)(?=[A-Z])");
                        }
                        else
                        {
                            names = fullName.Split(' ');

                        }
                        model.FirstName = names.Length >= 0 ? string.IsNullOrEmpty(names[0]) ? model.FirstName : names[0] : model.FirstName;
                        model.LastName = names.Length >= 1 ? string.IsNullOrEmpty(names[1].Trim()) ? model.LastName : names[1].Trim() : model.LastName;
                    }
                }

                if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity != null && !System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var corePipelineManager = DependencyResolver.Current.GetService<Sitecore.Abstractions.BaseCorePipelineManager>();
                    var args = new GetSignInUrlInfoArgs(Sitecore.Context.Site.Name, blog.Url);
                    GetSignInUrlInfoPipeline.Run(corePipelineManager, args);

                    model.signinURLInfo = args?.Result;
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return View(Constants.LeaveCommentViewName, model);
        }
        public ActionResult SeeComment()
        {
            List<CommentViewModel> model = new List<CommentViewModel>();
            try
            {
                IBlog blog = _renderingRepository.GetPageContextItem<IBlog>();
                if (blog != null)
                {
                    model = _commentService.GetComments(blog.Id.ToString());
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }

            return View(Constants.SeeCommentViewName, model);
        }

        [HttpPost]
        public JsonResult PostComment(CommentViewModel commentModel)
        {
            bool isCommentPosted = false;
            try
            {
                if ((System.Web.HttpContext.Current.User != null) && !System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return Json(new { Success = false, Message = _dictionaryPhraseRepository.Get("/Blog/LeaveComment/SignUpSocialMediaText", "Kindly login using any one of the Social Network to post your comments.") });
                }
                if (commentModel != null)
                {
                    if (string.IsNullOrEmpty(commentModel.FirstName) || string.IsNullOrEmpty(commentModel.LastName) || string.IsNullOrEmpty(commentModel.Comment))
                    {
                        return Json(new { Success = false, Message = _dictionaryPhraseRepository.Get("/Blog/LeaveComment/FillRequiredFieldsText", "Please Fill Required Fields") });
                    }
                    if (!string.IsNullOrEmpty(commentModel.Email))
                    {
                        if (!IsValidEmail(commentModel.Email))
                        {
                            return Json(new { Success = false, Message = _dictionaryPhraseRepository.Get("/Blog/LeaveComment/InvalidEmailText", "Invalid Email") });
                        }
                    }
                    isCommentPosted = _commentService.CreateComment(commentModel);
                }
                if (isCommentPosted)
                {
                    return Json(new { Success = true, Message = _dictionaryPhraseRepository.Get("/Blog/LeaveComment/SuccessText", "SuccessFully Posted") });
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return Json(new { Success = false, Message = _dictionaryPhraseRepository.Get("/Blog/LeaveComment/ErrorText", "Failed to Post") });
        }
        [HttpPost]
        public JsonResult SetCommentInSession(CommentViewModel commentViewModel)
        {
            try
            {
                if (commentViewModel != null)
                {
                    System.Web.HttpContext.Current.Session[Constants.CommentModel] = commentViewModel;
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return Json(new
            {
                Success = true
            });
        }
        private bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }
    }
}