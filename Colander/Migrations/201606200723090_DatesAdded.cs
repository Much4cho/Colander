namespace Colander.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Words", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Words", "GuessedRight", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Words", "GuessedRight");
            DropColumn("dbo.Words", "Created");
        }
    }
}
