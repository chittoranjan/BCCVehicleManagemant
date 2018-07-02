namespace BCCVehicleRequisitionManagementSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employeemodel_change_with_registration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "UserId", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
            AlterColumn("dbo.Employees", "ContactNo", c => c.String());
            AlterColumn("dbo.Employees", "Address", c => c.String());
            DropColumn("dbo.Employees", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Email", c => c.String());
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Employees", "ContactNo", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.Employees", "UserId");
        }
    }
}
