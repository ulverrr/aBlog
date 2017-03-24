using System.Collections.Generic;
using System.Linq;
using aBlog.Core.Repositories;
using aBlog.DataModel.Models;

namespace aBlog.Persistence.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetCommentsById(int id)
        {
            return _context.Comments
                .Where(c => c.PostId == id)
                .ToList();
        }

        public void Add(Comment comment)
        {
            _context.Comments.Add(comment);
        }
    }
}
