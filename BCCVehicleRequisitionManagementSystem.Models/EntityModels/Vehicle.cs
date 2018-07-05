using System.ComponentModel.DataAnnotations;

namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }

        [Required, MinLength(4), MaxLength(6)]
        public string RegistrationNo { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }
    }
}