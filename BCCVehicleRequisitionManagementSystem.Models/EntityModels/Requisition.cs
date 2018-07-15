using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class Requisition
    {   
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("Employee")]
        public int EmployeeId { get; set; }
       

        [Required]
        public DateTime JourneyStartDateTime{ get; set; }

        [Required]
        public DateTime JourneyEndDateTime { get; set; }

        [Required]
        public string PlaceFrom { get; set; }

        [Required]
        public string PlaceTo { get; set; }

        [Required]
        public int Seat { get; set; }

        [Required, StringLength(1000)]
        public string Description { get; set; } 

        public bool IsApproved { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsDeleted { get; set; }
        public Employee Employee { get; set; }
    }
}
