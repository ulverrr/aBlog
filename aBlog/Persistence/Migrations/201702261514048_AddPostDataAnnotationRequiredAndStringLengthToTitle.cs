namespace aBlog.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddPostDataAnnotationRequiredAndStringLengthToTitle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 255));
        }

        public override void Down()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String());
        }
    }
}
