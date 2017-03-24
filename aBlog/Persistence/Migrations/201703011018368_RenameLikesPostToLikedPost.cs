namespace aBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameLikesPostToLikedPost : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LikesPosts", newName: "LikedPosts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.LikedPosts", newName: "LikesPosts");
        }
    }
}
