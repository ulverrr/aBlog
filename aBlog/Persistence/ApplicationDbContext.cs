using System.Data.Entity;
using aBlog.DataModel.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace aBlog.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FavouritePost> FavoritePosts { get; set; }
        public DbSet<Comment> Comments { get; set; }



        public ApplicationDbContext()
            : base("aBlogDbConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavouritePost>()
                .HasRequired(a => a.Post)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}