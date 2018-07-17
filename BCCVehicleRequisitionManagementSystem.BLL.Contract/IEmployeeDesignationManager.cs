using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;

namespace BCCVehicleRequisitionManagementSystem.BLL.Contract
{
    public interface IEmployeeDesignationManager:IManager<EmployeeDesignation>
    {
         ICollection<EmployeeDesignation> GetByDepartmentId(int departmentId); 

    }
}
