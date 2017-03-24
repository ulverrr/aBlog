using aBlog.Core;
using aBlog.Core.ViewModels;
using aBlog.DataModel.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace aBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string query = null)
        {
            var posts = _unitOfWork.Posts.GetQueryPosts(query);

            var userId = User.Identity.GetUserId();

            var viewModel = new PostsViewModel
            {
                Posts = posts,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "aBlog",
                SearchTerm = query,
                Favorites = _unitOfWork.Favourites.GetFavoritePostsOfUser(userId).ToLookup(f => f.PostId)
            };

            return View("Index",viewModel);
        }

        public ActionResult Detail(int id)
        {
            var post = _unitOfWork.Posts.GetPostById(id);

            var comments = _unitOfWork.Comment.GetCommentsById(post.Id);

            var viewModel = Mapper.Map<Post, PostCommentViewModel>(post);
            viewModel.Comment = comments;

            return View(viewModel);
        }
    }
}