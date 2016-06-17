namespace Colander.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableColanderID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Words", "WordColanderID", "dbo.WordColanders");
            DropIndex("dbo.Words", new[] { "WordColanderID" });
            AlterColumn("dbo.Words", "WordColanderID", c => c.Int());
            CreateIndex("dbo.Words", "WordColanderID");
            AddForeignKey("dbo.Words", "WordColanderID", "dbo.WordColanders", "WordColanderID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Words", "WordColanderID", "dbo.WordColanders");
            DropIndex("dbo.Words", new[] { "WordColanderID" });
            AlterColumn("dbo.Words", "WordColanderID", c => c.Int(nullable: false));
            CreateIndex("dbo.Words", "WordColanderID");
            AddForeignKey("dbo.Words", "WordColanderID", "dbo.WordColanders", "WordColanderID", cascadeDelete: true);
        }
    }
}
