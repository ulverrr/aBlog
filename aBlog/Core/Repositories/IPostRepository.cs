using System.Collections.Generic;
using aBlog.DataModel.Models;

namespace aBlog.Core.Repositories
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetFavoritePosts(string userId);
        IEnumerable<Post> GetPostsByUserId(string userId);
        Post GetPostById(int id);
        Post GetPostForUserById(int id, string userId);
        IEnumerable<Post> GetQueryPosts(string query);

        void Add(Post post);
    }
}