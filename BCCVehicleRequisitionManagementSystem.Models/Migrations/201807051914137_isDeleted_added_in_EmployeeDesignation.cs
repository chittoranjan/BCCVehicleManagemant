namespace BCCVehicleRequisitionManagementSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isDeleted_added_in_EmployeeDesignation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeDesignations", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeDesignations", "IsDeleted");
        }
    }
}
