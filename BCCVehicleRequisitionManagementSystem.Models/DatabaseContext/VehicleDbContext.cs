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

    }
}
