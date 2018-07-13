namespace BCCVehicleRequisitionManagementSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requisition_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requisitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        JourneyDate = c.DateTime(nullable: false),
                        PlaceFrom = c.String(nullable: false),
                        PlaceTo = c.String(nullable: false),
                        JourneyStartTime = c.DateTime(nullable: false),
                        JourneyEndTime = c.DateTime(nullable: false),
                        JourneyDescription = c.String(nullable: false, maxLength: 1000),
                        DriverVehicleId = c.Int(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        IsCancelled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DriverVehicles", t => t.DriverVehicleId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .Index(t => t.EmployeeId)
                .Index(t => t.DriverVehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requisitions", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Requisitions", "DriverVehicleId", "dbo.DriverVehicles");
            DropIndex("dbo.Requisitions", new[] { "DriverVehicleId" });
            DropIndex("dbo.Requisitions", new[] { "EmployeeId" });
            DropTable("dbo.Requisitions");
        }
    }
}
