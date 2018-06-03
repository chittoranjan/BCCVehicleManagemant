using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;

namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class EmployeeDesignation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input employee designation!")]
        [Display(Name = "Employee Designation")]
        [StringLength(250)]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Please select department!")]
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}