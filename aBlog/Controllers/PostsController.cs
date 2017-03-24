using aBlog.Core;
using aBlog.Core.ViewModels;
using aBlog.DataModel.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace aBlog.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult MyPosts()
        {
            var userId = User.Identity.GetUserId();
            var posts = _unitOfWork.Posts.GetPostsByUserId(userId);

            return View(posts);
        }

        [Authorize]
        public ActionResult Favourites()
        {
            var userId = User.Identity.GetUserId();

            var viewModel = new PostsViewModel()
            {
                Posts = _unitOfWork.Posts.GetFavoritePosts(userId),
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Favourites Post",
                Favorites = _unitOfWork.Favourites.GetFavoritePostsOfUser(userId).ToLookup(f => f.PostId)
            };

            return View("Index", viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new PostFormViewModel()
            {
                Heading = "Add a post"
            };

            return View("CreatePost", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreatePost", viewModel);
            }

            var userId = User.Identity.GetUserId();

            var category = _unitOfWork.Category.CheckCategory(viewModel.CategoryName);
            _unitOfWork.Category.Add(category);

            viewModel.PostedDateTime = DateTime.Now;
            viewModel.UserId = userId;
            viewModel.CategoryId = category.Id;

            var post = Mapper.Map<PostFormViewModel, Post>(viewModel);

            _unitOfWork.Posts.Add(post);
            _unitOfWork.Complete();

            return RedirectToAction("MyPosts", "Posts");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PostFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreatePost", viewModel);
            }

            var userId = User.Identity.GetUserId();

            var post = _unitOfWork.Posts.GetPostForUserById(viewModel.Id, userId);

            post.Title = viewModel.Title;
            post.Description = viewModel.Description;

            _unitOfWork.Complete();

            return RedirectToAction("MyPosts", "Posts");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var post = _unitOfWork.Posts.GetPostForUserById(id, userId);

            var viewModel = Mapper.Map<Post, PostFormViewModel>(post);

            viewModel.Heading = "Edit a post";
            viewModel.CategoryName = post.Category.Name;

            return View("CreatePost", viewModel);
        }

        public ActionResult Search(PostsViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
        }

    }
}