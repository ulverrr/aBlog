using System;
using aBlog.DataModel.Models;
using aBlog.Persistence;
using Microsoft.AspNet.Identity;

namespace aBlog.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Persistence\Migrations";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var passwordHash = new PasswordHasher();
            var password = passwordHash.HashPassword("123456");
            var user = new ApplicationUser
            {
                UserName = "test@test.com",
                Email = "test@test.com",
                PasswordHash = password,
                PhoneNumber = "08869879",
                Name = "Pupkin"
            };

            context.Users.AddOrUpdate(u => u.UserName, user);
                
            var category = new Category {Name = "Lorem Ipsum"};
            context.Categories.Add(category);

            var post = new Post
            {
                CategoryId = 1,
                Title = "What is Lorem Ipsum?",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                              "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                              "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                              "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                              "remaining essentially unchanged. It was popularised in the 1960s with the release of " +
                              "Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software " +
                              "like Aldus PageMaker including versions of Lorem Ipsum",
                PostedDateTime = DateTime.Now,
                UserId = user.Id,
            };
            context.Posts.Add(post);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
