﻿using System.ComponentModel.DataAnnotations;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;

namespace BCCVehicleRequisitionManagementSystem.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input employee name!")]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select employee designation!")]
        [Display(Name = "Employeee Designation")]
        public int EmployeeDesignationId { get; set; }
        public EmployeeDesignation EmployeeDesignation { get; set; }

        [Required(ErrorMessage = "please select Deparment")]
        [Display(Name = "Deparment Name")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required(ErrorMessage = "Please input mobile no!")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }
        
        [Display(Name = "Present Address")]
        [Required(ErrorMessage = "Please input present address!")]
        public string Address { get; set; }

        public bool IsDelete { get; set; }
    }
}