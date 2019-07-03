using Claro.Feature.Blog.Models;
using Claro.Foundation.Testing;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Claro.Feature.Blog.Tests.Controllers
{
    [TestClass]
    public class CommentControllerTests : TestBase<CommentControllerTestHarness>
    {
        [TestMethod]
        public void LeaveComment_Given_ReturnCommentModelToView()
        {
            //Arrange
            IBlog blog = Substitute.For<IBlog>();
            _testHarness.RenderingRepository.GetPageContextItem<IBlog>().Returns(blog);

            //Act
            var result = _testHarness._CommentController.LeaveComment() as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.LeaveCommentViewName);

        }

        [TestMethod]
        public void SeeComment_Given_ReturnCommentsToView()
        {
            //Arrange
            IBlog blog = Substitute.For<IBlog>();
            List<CommentViewModel> commentViewModel = Substitute.For<List<CommentViewModel>>();
            _testHarness.RenderingRepository.GetPageContextItem<IBlog>().Returns(blog);
            _testHarness.CommentService.GetComments(blog.Id.ToString()).Returns(commentViewModel);

            //Act
            var result = _testHarness._CommentController.SeeComment() as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.SeeCommentViewName);

        }
        [TestMethod]
        public void SeeComment_Given_ReturnEmptyCommentToView()
        {
            //Arrange
            IBlog blog = Substitute.For<IBlog>();
            List<CommentViewModel> commentViewModel = null;
            _testHarness.RenderingRepository.GetPageContextItem<IBlog>().Returns(blog);
            _testHarness.CommentService.GetComments(blog.Id.ToString()).Returns(commentViewModel);

            //Act
            var result = _testHarness._CommentController.SeeComment() as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.SeeCommentViewName);
        }
        [TestMethod]
        public void PostComment_Given_PostFailed()
        {
            //Arrange
            bool created = true;
            var fixture = new Fixture();
            var response = fixture.Build<CommentViewModel>().Create();
            _testHarness.CommentService.CreateComment(response).Returns(created);
            //Act
            var result = _testHarness._CommentController.PostComment(response) as JsonResult;

            //assert
            result.JsonRequestBehavior.Should().Be(System.Web.Mvc.JsonRequestBehavior.DenyGet);

        }
        [TestMethod]
        public void SetCommentInSession_Given_SetComment()
        {
            //Arrange
            var fixture = new Fixture();
            var response = fixture.Build<CommentViewModel>().Create();
            //Act
            var result = _testHarness._CommentController.SetCommentInSession(response) as JsonResult;

            //assert
            result.JsonRequestBehavior.Should().Be(System.Web.Mvc.JsonRequestBehavior.DenyGet);
        }
    }
}
