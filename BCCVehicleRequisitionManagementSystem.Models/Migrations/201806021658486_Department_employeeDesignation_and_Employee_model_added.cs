namespace BCCVehicleRequisitionManagementSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Department_employeeDesignation_and_Employee_model_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeDesignations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, maxLength: 250),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        EmployeeDesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        ContactNo = c.String(nullable: false),
                        Email = c.String(),
                        Address = c.String(nullable: false, maxLength: 250),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.EmployeeDesignations", t => t.EmployeeDesignationId, cascadeDelete: false)
                .Index(t => t.EmployeeDesignationId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmployeeDesignationId", "dbo.EmployeeDesignations");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.EmployeeDesignations", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "EmployeeDesignationId" });
            DropIndex("dbo.EmployeeDesignations", new[] { "DepartmentId" });
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeDesignations");
            DropTable("dbo.Departments");
        }
    }
}
