using System.Data.Entity;
using aBlog.DataModel.Models;

namespace aBlog.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Post> Posts { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<FavouritePost> FavoritePosts { get; set; }
        DbSet<Comment> Comments { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
    }
}