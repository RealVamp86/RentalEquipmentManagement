namespace RentalEquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPasswordToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Password");
        }
    }
}
