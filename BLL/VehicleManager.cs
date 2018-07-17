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

namespace BLL
{

    public class VehicleManager:Manager<Vehicle>,IVehicleManager
    {
        private readonly IVehicleRepository _repository;

        public VehicleManager(IVehicleRepository vehicleRepository) : base(vehicleRepository)
        {
            this._repository = vehicleRepository;
        }

        public override bool Add(Vehicle vehicle)
        {
            if (string.IsNullOrEmpty(vehicle.Name))
            {
                throw new Exception("Vehicle Name is not provided!");
            }
            if (string.IsNullOrEmpty(vehicle.RegistrationNo))
            {
                throw new Exception("Vehicle Registration Number is not provided!");
            }
            if (vehicle.VehicleTypeId==0)
            {
                throw new Exception("Vehicle Type is not provided!");
            }
            return _repository.Add(vehicle);
        }

        public override bool Update(Vehicle vehicle)
        {
            if (string.IsNullOrEmpty(vehicle.Name))
            {
                throw new Exception("Vehicle Name is not provided!");
            }
            if (string.IsNullOrEmpty(vehicle.RegistrationNo))
            {
                throw new Exception("Vehicle Registration Number is not provided!");
            }
            if (vehicle.VehicleTypeId == 0)
            {
                throw new Exception("Vehicle Type is not provided!");
            }
            return _repository.Update(vehicle);
        }

        public override Vehicle GetById(int id)
        {
            if (id==0)
            {
                throw new Exception("Vehicle id is not provided!");
            }
            return _repository.GetById(id);
        }

    }
}
