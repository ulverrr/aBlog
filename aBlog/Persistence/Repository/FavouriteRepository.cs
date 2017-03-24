using System.Collections.Generic;
using System.Linq;
using aBlog.Core.Repositories;
using aBlog.DataModel.Models;

namespace aBlog.Persistence.Repository
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly ApplicationDbContext _context;

        public FavouriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FavouritePost> GetFavoritePostsOfUser(string userId)
        {
            return _context.FavoritePosts
               .Where(f => f.UserId == userId)
               .ToList();
        }

        public void Add(FavouritePost favourite)
        {
            _context.FavoritePosts.Add(favourite);
        }

        public void Remove(FavouritePost favourite)
        {
            _context.FavoritePosts.Remove(favourite);
        }

        public FavouritePost GetFavouritePostById(int id, string userId)
        {
            return _context.FavoritePosts
                .SingleOrDefault(e => e.UserId == userId && e.PostId == id);
        }
    }
}
