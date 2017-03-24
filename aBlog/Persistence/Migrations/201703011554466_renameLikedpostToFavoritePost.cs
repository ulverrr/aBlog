namespace aBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameLikedpostToFavoritePost : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LikedPosts", newName: "FavoritePosts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.FavoritePosts", newName: "LikedPosts");
        }
    }
}
