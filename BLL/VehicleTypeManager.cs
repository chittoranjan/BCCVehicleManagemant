using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using BLL.Base;
using Repository;
using Repository.Base;

namespace BLL
{

    public class VehicleTypeManager
    {
        //private VehiclesTypeRepository _vehiclesTypeRepository
        //{
        //    get
        //    {
        //        VehiclesTypeRepository vehiclesTypeRepository = (VehiclesTypeRepository)Repository;
        //        return vehiclesTypeRepository;
        //    }
        //}
        //public VehicleTypeManager() : base(new VehiclesTypeRepository())
        //{
        //}
        readonly VehiclesTypeRepository _vehiclesTypeRepository=new VehiclesTypeRepository();
        public bool Add(VehicleType vehicleType)
        {
            if (string.IsNullOrEmpty(vehicleType.TypeName))
            {
                throw new Exception("Vehicle Type Name is not provided!");
            }
            return _vehiclesTypeRepository.Add(vehicleType);
        }

        public bool Update(VehicleType vehicleType)
        {
            if (string.IsNullOrEmpty(vehicleType.TypeName))
            {
                throw new Exception("Vehicle Type Name is not provided!");
            }
            return _vehiclesTypeRepository.Update(vehicleType);
        }

        public  bool Remove(VehicleType vehicleType)
        {
            if (vehicleType.Id == 0)
            {
                throw new Exception("Removable Vehicle Type is not selected!");
            }
            return _vehiclesTypeRepository.Remove(vehicleType);
        }

        public ICollection<VehicleType> GetAll(bool withDeleted = false)
        {
            return _vehiclesTypeRepository.GetAll(withDeleted);
        }

        public VehicleType GetById(int id)
        {
            return _vehiclesTypeRepository.GetById(id);
        }

        public void Dispose()
        {
            _vehiclesTypeRepository.Dispose();
        }
    }
}
