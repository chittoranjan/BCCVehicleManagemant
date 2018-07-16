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
    public class VehiclesTypeRepository:DeleteableRepository<VehicleType>, IVehicleTypeRepository
    {

        public ICollection<VehicleType> GetByName(string name)
        {
            return Get(c => c.TypeName.Contains(name));
        }
    }
}
