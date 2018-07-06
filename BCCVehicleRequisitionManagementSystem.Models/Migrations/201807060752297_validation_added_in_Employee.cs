namespace BCCVehicleRequisitionManagementSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation_added_in_Employee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Employees", "ContactNo", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "IsDelete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "IsDelete", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Employees", "Address", c => c.String());
            AlterColumn("dbo.Employees", "ContactNo", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
            DropColumn("dbo.Employees", "IsDeleted");
        }
    }
}
