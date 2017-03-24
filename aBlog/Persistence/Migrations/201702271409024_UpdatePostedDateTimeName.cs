namespace aBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePostedDateTimeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostedDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Posts", "DatePostTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "DatePostTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Posts", "PostedDateTime");
        }
    }
}
