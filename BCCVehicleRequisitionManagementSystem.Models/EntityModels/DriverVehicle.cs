using System.ComponentModel.DataAnnotations;

namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class DriverVehicle
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select driver!")]
        [Display(Name = "Select Driver")]
        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        [Required(ErrorMessage = "Please select vehicle!")]
        [Display(Name = "Select Vehicle")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}