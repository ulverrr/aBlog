using aBlog.Core.Repositories;

namespace aBlog.Core
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }
        IFavouriteRepository Favourites { get; }
        ICategoryRepository Category { get; }
        ICommentRepository Comment { get; }
        void Complete();
    }
}