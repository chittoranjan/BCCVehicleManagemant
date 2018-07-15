namespace BCCVehicleRequisitionManagementSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_Requisition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requisitions", "Seat", c => c.Int(nullable: false));
            AddColumn("dbo.Requisitions", "Description", c => c.String(nullable: false, maxLength: 1000));
            DropColumn("dbo.Requisitions", "SetCapasity");
            DropColumn("dbo.Requisitions", "JourneyDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requisitions", "JourneyDescription", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.Requisitions", "SetCapasity", c => c.Int(nullable: false));
            DropColumn("dbo.Requisitions", "Description");
            DropColumn("dbo.Requisitions", "Seat");
        }
    }
}
