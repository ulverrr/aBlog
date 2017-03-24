namespace aBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikesPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LikesPosts",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PostId, t.UserId })
                .ForeignKey("dbo.Posts", t => t.PostId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LikesPosts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LikesPosts", "PostId", "dbo.Posts");
            DropIndex("dbo.LikesPosts", new[] { "UserId" });
            DropIndex("dbo.LikesPosts", new[] { "PostId" });
            DropTable("dbo.LikesPosts");
        }
    }
}
