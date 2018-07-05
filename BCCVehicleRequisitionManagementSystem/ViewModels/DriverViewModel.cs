using System.ComponentModel.DataAnnotations;

namespace BCCVehicleRequisitionManagementSystem.ViewModels
{
    public class DriverViewModel    
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input driver name!")]
        [Display(Name = "Driver Name")]
        public string Name { get; set; }

        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Please inpute mobile no!")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Please input licence no!")]
        [Display(Name = "Licence No")]
        public string LicenceNo { get; set; }

        [Required(ErrorMessage = "Please inpute NID No")]
        [Display(Name = "NID No")]
        public string NID { get; set; }

        [Required(ErrorMessage = "Please input present address!")]
        [Display(Name = "Present Address")]
        public string Address { get; set; }

    }
}