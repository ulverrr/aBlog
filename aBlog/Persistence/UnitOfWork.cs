using aBlog.Core;
using aBlog.Core.Repositories;
using aBlog.Persistence.Repository;

namespace aBlog.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IPostRepository Posts { get; private set; }
        public IFavouriteRepository Favourites { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ICommentRepository Comment { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Posts = new PostRepository(_context);
            Favourites = new FavouriteRepository(_context);
            Category = new CategoryRepository(_context);
            Comment = new CommentRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
