using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.DatabaseContext;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using BCCVehicleRequisitionManagementSystem.Repository.Contracts;
using Repository.Base;

namespace Repository
{
    public class DriverRepository:Repository<Driver>,IDriverRepository
    {
        public DriverRepository(DbContext db) : base(db)
        {
        }
    }
}
