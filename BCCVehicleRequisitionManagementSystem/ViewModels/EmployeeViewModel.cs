using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;

namespace BCCVehicleRequisitionManagementSystem.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input name!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select employee designatin!")]
        [Display(Name = "Designation")]
        public int EmployeeDesignationId { get; set; }
        public EmployeeDesignation EmployeeDesignation { get; set; }

        [Required(ErrorMessage = "Please select employee department!")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required(ErrorMessage = "Please input contact no!")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }
        
        [Required(ErrorMessage = "Please input address!")]
        [Display(Name = "Present Address")]
        public string Address { get; set; }
    }
}