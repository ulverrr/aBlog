using System.Web.Http;
using aBlog.Core;
using aBlog.Core.DTOs;
using aBlog.DataModel.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;

namespace aBlog.Controllers.Api
{
    [Authorize]
    public class FavouritePostsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FavouritePostsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult AddToFavourites(FavouritePostDto dto)
        {
            var userId = User.Identity.GetUserId();

            dto.UserId = userId;

            var favourite = Mapper.Map<FavouritePostDto, FavouritePost>(dto);

            _unitOfWork.Favourites.Add(favourite);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFavourite(int id)
        {
            var userId = User.Identity.GetUserId();

            var favourite = _unitOfWork.Favourites.GetFavouritePostById(id, userId);

            if (favourite == null)
            {
                return NotFound();
            }

            _unitOfWork.Favourites.Remove(favourite);
            _unitOfWork.Complete();

            return Ok(id);
        }

    }
}

