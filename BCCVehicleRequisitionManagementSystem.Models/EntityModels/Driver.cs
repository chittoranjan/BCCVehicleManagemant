using System.ComponentModel.DataAnnotations;

namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input driver name!")]
        [Display(Name = "Driver Name")]
        [MaxLength(250)]
        public string Name { get; set; }

        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Please inpute mobile no!")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Please input licence no!")]
        [Display(Name = "Licence No")]
        public string LicenceNo { get; set; }

        [Required(ErrorMessage = "Please inpute NID No")]
        [Display(Name = "NID No"),StringLength(17)]
        public string NID { get; set; }

        [Required(ErrorMessage = "Please input present address!")]
        [Display(Name = "Present Address"),MaxLength(500)]
        public string Address { get; set; }

        public bool IsDelete { get; set; }
    }
}