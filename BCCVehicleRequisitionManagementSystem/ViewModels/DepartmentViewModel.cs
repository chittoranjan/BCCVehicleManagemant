using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;

namespace BCCVehicleRequisitionManagementSystem.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input Department name!")]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
        public List<EmployeeDesignation> EmployeeDesignations { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
