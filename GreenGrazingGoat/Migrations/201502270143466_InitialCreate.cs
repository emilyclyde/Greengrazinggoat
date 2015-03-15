namespace GreenGrazingGoat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerFirst = c.String(nullable: false, maxLength: 50),
                        CustomerLast = c.String(nullable: false, maxLength: 50),
                        CustomerAddress = c.String(),
                        CustomerEmail = c.String(),
                        Goat_GoatID = c.Int(),
                        Lot_LotID = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Goat", t => t.Goat_GoatID)
                .ForeignKey("dbo.Lot", t => t.Lot_LotID)
                .Index(t => t.Goat_GoatID)
                .Index(t => t.Lot_LotID);
            
            CreateTable(
                "dbo.Goat",
                c => new
                    {
                        GoatID = c.Int(nullable: false, identity: true),
                        GoatName = c.String(),
                        GoatColor = c.String(),
                        GoatType = c.String(),
                        GoatGender = c.String(),
                        Lot_LotID = c.Int(),
                    })
                .PrimaryKey(t => t.GoatID)
                .ForeignKey("dbo.Lot", t => t.Lot_LotID)
                .Index(t => t.Lot_LotID);
            
            CreateTable(
                "dbo.Lot",
                c => new
                    {
                        LotID = c.Int(nullable: false, identity: true),
                        GoatID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        GoatName = c.String(nullable: false, maxLength: 50),
                        CustomerFirst = c.String(nullable: false, maxLength: 50),
                        CustomerLast = c.String(nullable: false, maxLength: 50),
                        LotAddress = c.String(nullable: false, maxLength: 50),
                        LotDescription = c.String(),
                    })
                .PrimaryKey(t => t.LotID);
            
            CreateTable(
                "dbo.Pasture",
                c => new
                    {
                        PastureID = c.Int(nullable: false, identity: true),
                        GoatID = c.Int(nullable: false),
                        Field = c.String(),
                    })
                .PrimaryKey(t => t.PastureID)
                .ForeignKey("dbo.Goat", t => t.GoatID, cascadeDelete: true)
                .Index(t => t.GoatID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "Lot_LotID", "dbo.Lot");
            DropForeignKey("dbo.Customer", "Goat_GoatID", "dbo.Goat");
            DropForeignKey("dbo.Pasture", "GoatID", "dbo.Goat");
            DropForeignKey("dbo.Goat", "Lot_LotID", "dbo.Lot");
            DropIndex("dbo.Pasture", new[] { "GoatID" });
            DropIndex("dbo.Goat", new[] { "Lot_LotID" });
            DropIndex("dbo.Customer", new[] { "Lot_LotID" });
            DropIndex("dbo.Customer", new[] { "Goat_GoatID" });
            DropTable("dbo.Pasture");
            DropTable("dbo.Lot");
            DropTable("dbo.Goat");
            DropTable("dbo.Customer");
        }
    }
}
