using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using Repository;

namespace BLL
{

    public class VehicleTypeManager
    {
        readonly VehiclesTypeRepository _repository = new VehiclesTypeRepository();

        public bool Add(VehicleType vehicleType)
        {
            if (string.IsNullOrEmpty(vehicleType.TypeName))
            {
                throw new Exception("Vehicle Type Name is not provided!");
            }
            return _repository.Add(vehicleType);
        }

        public bool Update(VehicleType vehicleType)
        {
            if (string.IsNullOrEmpty(vehicleType.TypeName))
            {
                throw new Exception("Vehicle Type Name is not provided!");
            }
            return _repository.Update(vehicleType);
        }

        public bool Remove(VehicleType vehicleType)
        {
            if (vehicleType.Id == 0)
            {
                throw new Exception("Removable Vehicle Type is not selected!");
            }
            vehicleType.IsDeleted = true;
            return _repository.Remove(vehicleType);
        }

        public ICollection<VehicleType> GetAll(bool withDeleted = false)
        {
            return _repository.GetAll(withDeleted);
        }

        public VehicleType GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
