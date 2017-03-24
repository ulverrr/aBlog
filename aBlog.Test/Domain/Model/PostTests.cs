using aBlog.DataModel.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aBlog.Test.Domain.Model
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public void Cancel_WhenCalled_ShouldSetIsCanceledToTrue()
        {
            var post = new Post();

            post.Cancel();

            post.IsCanceled.Should().BeTrue();
        }
    }
}
