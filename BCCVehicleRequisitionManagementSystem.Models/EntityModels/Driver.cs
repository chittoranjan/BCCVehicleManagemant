using System.ComponentModel.DataAnnotations;
using BCCVehicleRequisitionManagementSystem.Models.Contracts;

namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class Driver : IEntityModel,IDeletable
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public string MobileNo { get; set; }

        [Required]
        public string LicenceNo { get; set; }

        [Required, StringLength(17)]
        public string NID { get; set; }

        [Required, MaxLength(500)]
        public string Address { get; set; }

        public bool IsDeleted { get; set; }
        public bool Delete()
        {
            IsDeleted = true;
            return IsDeleted;
        }
    }
}