using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required,StringLength(250)]
        public string Name { get; set; }

        [Required,ForeignKey("EmployeeDesignation")]
        public int EmployeeDesignationId { get; set; }
        public EmployeeDesignation EmployeeDesignation { get; set; }

        [Required,ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        public string ContactNo { get; set; }
        
        [Required]
        public string Address { get; set; }

        public bool IsDeleted { get; set; }
        public string UserId { get; set; }
    }
}