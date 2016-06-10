namespace Colander.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WordLists",
                c => new
                    {
                        WordListID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.WordListID);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        WordID = c.Int(nullable: false, identity: true),
                        WordOriginal = c.String(),
                        WordTranslation = c.String(),
                        WordListID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WordID)
                .ForeignKey("dbo.WordLists", t => t.WordListID, cascadeDelete: true)
                .Index(t => t.WordListID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Words", "WordListID", "dbo.WordLists");
            DropIndex("dbo.Words", new[] { "WordListID" });
            DropTable("dbo.Words");
            DropTable("dbo.WordLists");
        }
    }
}
