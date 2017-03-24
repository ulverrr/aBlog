namespace aBlog.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddCommentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserName = c.String(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                    Content = c.String(nullable: false),
                    PostId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropTable("dbo.Comments");
        }
    }
}
