using System.Collections.Generic;
using aBlog.DataModel.Models;

namespace aBlog.Core.Repositories
{
    public interface IFavouriteRepository
    {
        IEnumerable<FavouritePost> GetFavoritePostsOfUser(string userId);
        FavouritePost GetFavouritePostById(int id, string userId);
        void Add(FavouritePost favourite);
        void Remove(FavouritePost favourite);

    }
}