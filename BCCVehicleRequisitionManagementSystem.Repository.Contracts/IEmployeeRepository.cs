using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;

namespace BCCVehicleRequisitionManagementSystem.Repository.Contracts
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Employee GetByUserId(string userId); 
    }
}
