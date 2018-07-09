using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using Repository;

namespace BLL
{

    public class VehicleManager
    {
        readonly VehiclesRepository _repository = new VehiclesRepository();

        public bool Add(Vehicle vehicle)
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

        public bool Update(Vehicle vehicle)
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

        public bool Remove(Vehicle vehicle)
        {
            if (vehicle.Id == 0)
            {
                throw new Exception("Removable Vehicle is not selected!");
            }
            vehicle.IsDeleted = true;
            return _repository.Remove(vehicle);
        }

        public ICollection<Vehicle> GetAll(bool withDeleted = false)
        {
            return _repository.GetAll(withDeleted);
        }

        public Vehicle GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
