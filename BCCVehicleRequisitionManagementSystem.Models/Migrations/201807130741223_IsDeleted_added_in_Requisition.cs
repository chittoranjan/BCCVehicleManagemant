namespace BCCVehicleRequisitionManagementSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDeleted_added_in_Requisition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requisitions", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requisitions", "IsDeleted");
        }
    }
}
