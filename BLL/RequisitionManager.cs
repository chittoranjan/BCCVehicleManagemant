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
            if (DateTime.Now>=requisition.JourneyStartDateTime)
            {
                throw new Exception("Journey start date and time is not valid!");
            }
            if (DateTime.Now >= requisition.JourneyEndDateTime)
            {
                throw new Exception("Journey end date and time is not valid!");
            }
            if (requisition.Seat<=0)
            {
                throw new Exception("Journey end time is not valid!");
            }
            if (string.IsNullOrEmpty(requisition.PlaceFrom))
            {
                throw new Exception("Journey from is not provided!");
            }
            if (string.IsNullOrEmpty(requisition.PlaceTo))
            {
                throw new Exception("Journey to is not provided!");
            }
            if (string.IsNullOrEmpty(requisition.Description))
            {
                throw new Exception("Description is not provided!");
            }

            return _requisitionRepository.Add(requisition);
        }

        public bool Update(Requisition requisition)
        {
            if (requisition.EmployeeId == 0)
            {
                throw new Exception("Employee is not provided!");
            }
            if (DateTime.Now >= requisition.JourneyStartDateTime)
            {
                throw new Exception("Journey start date and time is not valid!");
            }
            if (DateTime.Now >= requisition.JourneyEndDateTime)
            {
                throw new Exception("Journey end date and time is not valid!");
            }
            if (requisition.Seat <= 0)
            {
                throw new Exception("Journey end time is not valid!");
            }
            if (string.IsNullOrEmpty(requisition.PlaceFrom))
            {
                throw new Exception("Journey from is not provided!");
            }
            if (string.IsNullOrEmpty(requisition.PlaceTo))
            {
                throw new Exception("Journey to is not provided!");
            }
            if (string.IsNullOrEmpty(requisition.Description))
            {
                throw new Exception("Description is not provided!");
            }
            return _requisitionRepository.Add(requisition);
        }

        public bool Remove(Requisition requisition)
        {
            if (requisition.Id == 0)
            {
                throw new Exception("Removable requisition is not valid!");
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
            if (id==0)
            {
                throw new Exception("Select requisition is not valid!");
            }
            return _requisitionRepository.GetById(id);
        }

        public void Dispose()
        {
            _requisitionRepository.Dispose();
        }
    }
}
