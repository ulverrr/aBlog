namespace aBlog.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreatePostTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Posts");
        }
    }
}
