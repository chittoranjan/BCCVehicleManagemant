namespace BCCVehicleRequisitionManagementSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DriverVehicle_model_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DriverVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DriverId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DriverVehicles", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.DriverVehicles", "DriverId", "dbo.Drivers");
            DropIndex("dbo.DriverVehicles", new[] { "VehicleId" });
            DropIndex("dbo.DriverVehicles", new[] { "DriverId" });
            DropTable("dbo.DriverVehicles");
        }
    }
}
