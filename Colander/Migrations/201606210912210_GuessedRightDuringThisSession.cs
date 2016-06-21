namespace Colander.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuessedRightDuringThisSession : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Words", "GuessedRightDuringThisSession", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Words", "GuessedRightDuringThisSession");
        }
    }
}
