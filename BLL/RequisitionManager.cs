using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using Repository;

namespace BLL
{

    public class RequisitionManager 
    {
        readonly RequisitionRepository _requisitionRepository = new RequisitionRepository();

        public bool Add(Requisition requisition)
        {
            if (requisition.EmployeeId==0)
            {
                throw new Exception("Employee is not provided!");
            }
            if (DateTime.Now>=requisition.JourneyDate)
            {
                throw new Exception("Journey date is not valid!");
            }
            if (string.IsNullOrEmpty(requisition.PlaceFrom))
            {
                throw new Exception("Journey from is not provided!");
            }
            if (string.IsNullOrEmpty(requisition.PlaceTo))
            {
                throw new Exception("Journey to is not provided!");
            }
            if (DateTime.Now >= requisition.JourneyStartTime)
            {
                throw new Exception("Journey start time is not valid!");
            }
            if (DateTime.Now >= requisition.JourneyEndTime)
            {
                throw new Exception("Journey end time is not valid!");
            }
            if (string.IsNullOrEmpty(requisition.JourneyDescription))
            {
                throw new Exception("Description is not provided!");
            }
            if (requisition.DriverVehicleId==0)
            {
                throw new Exception("Driver is not provided!");
            }
            return _requisitionRepository.Add(requisition);
        }

        public bool Update(Requisition requisition)
        {
            if (requisition.EmployeeId == 0)
            {
                throw new Exception("Employee is not provided!");
            }
            if (DateTime.Now >= requisition.JourneyDate)
            {
                throw new Exception("Journey date is not valid!");
            }
            if (string.IsNullOrEmpty(requisition.PlaceFrom))
            {
                throw new Exception("Journey from is not provided!");
            }
            if (string.IsNullOrEmpty(requisition.PlaceTo))
            {
                throw new Exception("Journey to is not provided!");
            }
            if (DateTime.Now >= requisition.JourneyStartTime)
            {
                throw new Exception("Journey start time is not valid!");
            }
            if (DateTime.Now >= requisition.JourneyEndTime)
            {
                throw new Exception("Journey end time is not valid!");
            }
            if (string.IsNullOrEmpty(requisition.JourneyDescription))
            {
                throw new Exception("Description is not provided!");
            }
            if (requisition.DriverVehicleId == 0)
            {
                throw new Exception("Driver is not provided!");
            }
            return _requisitionRepository.Add(requisition);
        }

        public bool Remove(Requisition requisition)
        {
            if (requisition.Id == 0)
            {
                throw new Exception("Removable Department is not selected!");
            }
            requisition.IsDeleted = true;
            return _requisitionRepository.Remove(requisition);
        }

        public ICollection<Requisition> GetAll(bool withDeleted = false)
        {
            return _requisitionRepository.GetAll(withDeleted);
        }

        public Requisition GetById(int id)
        {
            return _requisitionRepository.GetById(id);
        }

        public void Dispose()
        {
            _requisitionRepository.Dispose();
        }
    }
}
