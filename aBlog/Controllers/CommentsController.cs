using aBlog.Core;
using aBlog.Core.ViewModels;
using aBlog.DataModel.Models;
using AutoMapper;
using System;
using System.Web.Mvc;

namespace aBlog.Controllers
{
    public class CommentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Create(PostCommentViewModel viewModel)
        {
            var comment = Mapper.Map<PostCommentViewModel, Comment>(viewModel);
            comment.DateCreated = DateTime.Now;

            _unitOfWork.Comment.Add(comment);
            _unitOfWork.Complete();


            return RedirectToAction("Detail", "Home", new { id = viewModel.Id });
        }
    }
}