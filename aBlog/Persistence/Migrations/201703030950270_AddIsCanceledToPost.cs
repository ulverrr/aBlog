namespace aBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceledToPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "IsCanceled");
        }
    }
}
