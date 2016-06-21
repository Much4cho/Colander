namespace Colander.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuessedRightDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Words", "GuessedRight", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Words", "GuessedRight", c => c.DateTime(nullable: false));
        }
    }
}
