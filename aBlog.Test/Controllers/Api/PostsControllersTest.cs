using aBlog.Controllers.Api;
using aBlog.Core;
using aBlog.Core.Repositories;
using aBlog.DataModel.Models;
using aBlog.Test.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace aBlog.Test.Controllers.Api
{
    [TestClass]
    public class PostsControllersTest
    {
        private PostsController _postsController;
        private Mock<IPostRepository> _mockRepository;
        private string _userId;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IPostRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Posts).Returns(_mockRepository.Object);

            _postsController = new PostsController(mockUoW.Object);
            _userId = "1";
            _postsController.MockCurrentUser(_userId, "user1@test.com");
        }

        [TestMethod]
        public void Cancel_NoPostWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _postsController.Cancel(1);

            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_PostIsCanceled_ShouldReturnNotfound()
        {
            var post = new Post();
            post.Cancel();

            _mockRepository.Setup(r => r.GetPostById(1)).Returns(post);

            var result = _postsController.Cancel(1);
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_UserCancelingAnotherUserPost_ShouldRetuenUnautorized()
        {
            var post = new Post() { UserId = _userId + "-" };

            _mockRepository.Setup(r => r.GetPostById(1)).Returns(post);

            var result = _postsController.Cancel(1);
            result.Should().BeOfType<UnauthorizedResult>();
        }

        [TestMethod]
        public void Cancel_ValidRequest_ShouldReturnOk()
        {
            var post = new Post() { UserId = _userId };

            _mockRepository.Setup(r => r.GetPostById(1)).Returns(post);

            var result = _postsController.Cancel(1);
            result.Should().BeOfType<OkResult>();
        }
    }
}