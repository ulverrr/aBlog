namespace aBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserPropertyToPostModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Posts", "UserId");
            AddForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropColumn("dbo.Posts", "UserId");
        }
    }
}
