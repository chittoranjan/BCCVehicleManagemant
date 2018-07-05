namespace BCCVehicleRequisitionManagementSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isDeleted_added_in_VehicleType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.VehicleTypes", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Vehicles", "IsDelete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "IsDelete", c => c.Boolean(nullable: false));
            DropColumn("dbo.VehicleTypes", "IsDeleted");
            DropColumn("dbo.Vehicles", "IsDeleted");
        }
    }
}
