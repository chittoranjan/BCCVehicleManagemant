namespace BCCVehicleRequisitionManagementSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isDeleted_added_in_Driver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Drivers", "IsDelete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "IsDelete", c => c.Boolean(nullable: false));
            DropColumn("dbo.Drivers", "IsDeleted");
        }
    }
}
