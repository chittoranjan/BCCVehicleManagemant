using System.ComponentModel.DataAnnotations;

namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public int EmployeeDesignationId { get; set; }
        public EmployeeDesignation EmployeeDesignation { get; set; }

        
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        
        public string ContactNo { get; set; }
        
        
        public string Address { get; set; }

        public bool IsDelete { get; set; }
        public string UserId { get; set; }
    }
}