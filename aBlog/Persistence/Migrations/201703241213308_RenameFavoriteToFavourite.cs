namespace aBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameFavoriteToFavourite : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FavoritePosts", newName: "FavouritePosts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.FavouritePosts", newName: "FavoritePosts");
        }
    }
}
