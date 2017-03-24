using System.Collections.Generic;
using aBlog.DataModel.Models;

namespace aBlog.Core.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetCommentsById(int id);
        void Add(Comment comment);
    }
}