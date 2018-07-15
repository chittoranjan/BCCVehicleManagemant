namespace BCCVehicleRequisitionManagementSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_DriverVehicle_and_change_Requisition : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DriverVehicles", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.DriverVehicles", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Requisitions", "DriverVehicleId", "dbo.DriverVehicles");
            DropIndex("dbo.DriverVehicles", new[] { "DriverId" });
            DropIndex("dbo.DriverVehicles", new[] { "VehicleId" });
            DropIndex("dbo.Requisitions", new[] { "DriverVehicleId" });
            AddColumn("dbo.Requisitions", "JourneyStartDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requisitions", "JourneyEndDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requisitions", "SetCapasity", c => c.Int(nullable: false));
            DropColumn("dbo.Requisitions", "JourneyDate");
            DropColumn("dbo.Requisitions", "JourneyStartTime");
            DropColumn("dbo.Requisitions", "JourneyEndTime");
            DropColumn("dbo.Requisitions", "DriverVehicleId");
            DropTable("dbo.DriverVehicles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DriverVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DriverId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Requisitions", "DriverVehicleId", c => c.Int(nullable: false));
            AddColumn("dbo.Requisitions", "JourneyEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requisitions", "JourneyStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requisitions", "JourneyDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Requisitions", "SetCapasity");
            DropColumn("dbo.Requisitions", "JourneyEndDateTime");
            DropColumn("dbo.Requisitions", "JourneyStartDateTime");
            CreateIndex("dbo.Requisitions", "DriverVehicleId");
            CreateIndex("dbo.DriverVehicles", "VehicleId");
            CreateIndex("dbo.DriverVehicles", "DriverId");
            AddForeignKey("dbo.Requisitions", "DriverVehicleId", "dbo.DriverVehicles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DriverVehicles", "VehicleId", "dbo.Vehicles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DriverVehicles", "DriverId", "dbo.Drivers", "Id", cascadeDelete: true);
        }
    }
}
