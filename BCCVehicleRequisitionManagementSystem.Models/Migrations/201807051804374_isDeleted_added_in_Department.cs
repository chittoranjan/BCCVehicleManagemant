namespace BCCVehicleRequisitionManagementSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isDeleted_added_in_Department : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Departments", "IsDeleted");
        }
    }
}
