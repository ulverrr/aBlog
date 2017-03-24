using aBlog.DataModel.Models;
using aBlog.Persistence;
using aBlog.Persistence.Repository;
using aBlog.Test.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;

namespace aBlog.Test.Persistence.Repository
{
    [TestClass]
    public class PostRepositoryTests
    {
        private PostRepository _repository;
        private Mock<DbSet<Post>> _mockPosts;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockPosts = new Mock<DbSet<Post>>();

            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Posts).Returns(_mockPosts.Object);

            _repository = new PostRepository(mockContext.Object);
        }

        [TestMethod]
        public void GetPostsByUserId_PostInTheCancel_ShouldNotBeReturned()
        {
            var post = new Post() { UserId = "1" };
            post.Cancel();

            _mockPosts.SetSource(new[] { post });

            var posts = _repository.GetPostsByUserId("1");

            posts.Should().BeEmpty();
        }

        [TestMethod]
        public void GetPostByUserId_PostIsaDifferentUser_ShouldNotBeReturned()
        {
            var post = new Post() { UserId = "1" };

            _mockPosts.SetSource(new[] { post });

            var posts = _repository.GetPostsByUserId(post.UserId + "-");

            posts.Should().BeEmpty();
        }

        [TestMethod]
        public void GetPostByUserId_PostIsForTheGivenUser_ShouldBeReturned()
        {
            var post = new Post() { UserId = "1" };

            _mockPosts.SetSource(new[] { post });

            var posts = _repository.GetPostsByUserId(post.UserId);

            posts.Should().Contain(post);
        }
    }
}
