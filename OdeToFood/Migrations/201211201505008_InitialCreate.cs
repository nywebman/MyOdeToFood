namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaraunts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestarauntReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        RestarauntId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaraunts", t => t.RestarauntId, cascadeDelete: true)
                .Index(t => t.RestarauntId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.RestarauntReviews", new[] { "RestarauntId" });
            DropForeignKey("dbo.RestarauntReviews", "RestarauntId", "dbo.Restaraunts");
            DropTable("dbo.RestarauntReviews");
            DropTable("dbo.Restaraunts");
        }
    }
}
