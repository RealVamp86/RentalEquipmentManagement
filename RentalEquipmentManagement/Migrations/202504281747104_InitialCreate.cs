namespace RentalEquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Category = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 255),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FinancialReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Income = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EquipmentUsage = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Message = c.String(nullable: false, maxLength: 255),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Role = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                        RentalDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EquipmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rentals", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Notifications", "UserId", "dbo.Users");
            DropIndex("dbo.Rentals", new[] { "EquipmentId" });
            DropIndex("dbo.Rentals", new[] { "UserId" });
            DropIndex("dbo.Notifications", new[] { "UserId" });
            DropTable("dbo.Rentals");
            DropTable("dbo.Users");
            DropTable("dbo.Notifications");
            DropTable("dbo.FinancialReports");
            DropTable("dbo.Equipments");
        }
    }
}
