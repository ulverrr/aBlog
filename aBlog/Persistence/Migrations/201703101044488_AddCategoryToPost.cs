namespace aBlog.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddCategoryToPost : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tags", newName: "Categories");
            DropForeignKey("dbo.TagPosts", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TagPosts", "Post_Id", "dbo.Posts");
            DropIndex("dbo.TagPosts", new[] { "Tag_Id" });
            DropIndex("dbo.TagPosts", new[] { "Post_Id" });
            AddColumn("dbo.Posts", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "CategoryId");
            AddForeignKey("dbo.Posts", "CategoryId", "dbo.Categories", "Id", cascadeDelete: false);
            DropTable("dbo.TagPosts");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.TagPosts",
                c => new
                {
                    Tag_Id = c.Int(nullable: false),
                    Post_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Tag_Id, t.Post_Id });

            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropColumn("dbo.Posts", "CategoryId");
            CreateIndex("dbo.TagPosts", "Post_Id");
            CreateIndex("dbo.TagPosts", "Tag_Id");
            AddForeignKey("dbo.TagPosts", "Post_Id", "dbo.Posts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TagPosts", "Tag_Id", "dbo.Tags", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Categories", newName: "Tags");

        }
    }
}
