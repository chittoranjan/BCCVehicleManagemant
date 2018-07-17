using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.BLL.Contract;
using BCCVehicleRequisitionManagementSystem.Models.Contracts;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using BCCVehicleRequisitionManagementSystem.Repository.Contracts;
using BLL.Base;
using Repository;
using Repository.Base;

namespace BLL
{

    public class VehicleTypeManager:Manager<VehicleType>,IVehicleTypeManager
    {
        readonly IVehicleTypeRepository _vehiclesTypeRepository;

        public VehicleTypeManager(IVehicleTypeRepository vehicleTypeRepository) : base(vehicleTypeRepository)
        {
            this._vehiclesTypeRepository = vehicleTypeRepository;
        }

        public override bool Add(VehicleType vehicleType)
        {
            if (string.IsNullOrEmpty(vehicleType.TypeName))
            {
                throw new Exception("Vehicle Type Name is not provided!");
            }
            return _vehiclesTypeRepository.Add(vehicleType);
        }

        public override bool Update(VehicleType vehicleType)
        {
            if (string.IsNullOrEmpty(vehicleType.TypeName))
            {
                throw new Exception("Vehicle Type Name is not provided!");
            }
            return _vehiclesTypeRepository.Update(vehicleType);
        }

        public override VehicleType GetById(int id)
        {
            if (id==0)
            {
                throw new Exception("Vehicle id is not provided!");
            }
            return _vehiclesTypeRepository.GetById(id);
        }


    }
}
