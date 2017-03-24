using aBlog.Core.Repositories;
using aBlog.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace aBlog.Persistence.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly IApplicationDbContext _context;

        public PostRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetFavoritePosts(string userId)
        {
            return _context.FavoritePosts
                .Where(p => p.UserId == userId)
                .Select(s => s.Post)
                .Include(u => u.User)
                .Include(c => c.Category)
                .ToList();
        }

        public IEnumerable<Post> GetPostsByUserId(string userId)
        {
            return _context.Posts
                .Where(p =>
                    p.UserId == userId &&
                    !p.IsCanceled)
                .Include(u => u.User)
                .Include(c => c.Category)
                .ToList();
        }

        public Post GetPostById(int id)
        {
            return _context.Posts
                .Include(c => c.Category)
                .Include(u => u.User)
                .FirstOrDefault(p => p.Id == id);
        }

        public Post GetPostForUserById(int id, string userId)
        {
            return _context.Posts
                .Include(c => c.Category)
                .Include(u => u.User)
                .FirstOrDefault(p => p.Id == id && p.UserId == userId);
        }

        public IEnumerable<Post> GetQueryPosts(string query)
        {
            var posts = _context.Posts
                .Include(p => p.User)
                .Include(p => p.Category)
                .Where(p => !p.IsCanceled);

            if (!String.IsNullOrWhiteSpace(query))
            {
                posts = posts
                    .Where(p =>
                        p.Title.Contains(query) ||
                        p.Description.Contains(query) ||
                        p.User.Name.Contains(query));
            }

            return posts;
        }

        public void Add(Post post)
        {
            _context.Posts.Add(post);
        }
    }
}
