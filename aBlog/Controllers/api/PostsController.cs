using aBlog.Core;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace aBlog.Controllers.Api
{
    [Authorize]
    public class PostsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;


        public PostsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();

            var post = _unitOfWork.Posts.GetPostById(id);

            if (post == null || post.IsCanceled)
            {
                return NotFound();
            }

            if (post.UserId != userId)
            {
                return Unauthorized();
            }

            post.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
