using System.Collections.Generic;

namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class EmployeeDesignation
    {
        public byte Id { get; set; }
        public string Designation { get; set; }
        public List<Employee> Employees { get; set; }

    }
}