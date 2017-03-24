namespace aBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatePostTimeToPostModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "DatePostTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "DatePostTime");
        }
    }
}
