using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCCVehicleRequisitionManagementSystem.Models.DatabaseContext
{
    public class VehicleDbContext:DbContext
    {
        public VehicleDbContext() :base("DefaultConnection")
        {
            //
        }

        public System.Data.Entity.DbSet<BCCVehicleRequisitionManagementSystem.Models.EntityModels.VehicleType> VehicleTypes { get; set; }
        public System.Data.Entity.DbSet<BCCVehicleRequisitionManagementSystem.Models.EntityModels.Vehicle> Vehicles { get; set; }

        public System.Data.Entity.DbSet<BCCVehicleRequisitionManagementSystem.Models.EntityModels.Driver> Drivers { get; set; }

        public System.Data.Entity.DbSet<BCCVehicleRequisitionManagementSystem.Models.EntityModels.Department> Departments { get; set; }
        public System.Data.Entity.DbSet<BCCVehicleRequisitionManagementSystem.Models.EntityModels.EmployeeDesignation> EmployeeDesignations { get; set; }
        public System.Data.Entity.DbSet<BCCVehicleRequisitionManagementSystem.Models.EntityModels.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<BCCVehicleRequisitionManagementSystem.Models.EntityModels.DriverVehicle> DriverVehicles { get; set; }

    }
}
