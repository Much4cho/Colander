namespace Colander.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WordColander : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WordColanders",
                c => new
                    {
                        WordColanderID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.WordColanderID);
            
            AddColumn("dbo.Words", "WordColanderID", c => c.Int(nullable: false));
            CreateIndex("dbo.Words", "WordColanderID");
            AddForeignKey("dbo.Words", "WordColanderID", "dbo.WordColanders", "WordColanderID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Words", "WordColanderID", "dbo.WordColanders");
            DropIndex("dbo.Words", new[] { "WordColanderID" });
            DropColumn("dbo.Words", "WordColanderID");
            DropTable("dbo.WordColanders");
        }
    }
}
