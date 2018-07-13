using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;

namespace BCCVehicleRequisitionManagementSystem.ViewModels
{
    public class RequisitionViewModel   
    {   
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select requisitor information!")]
        [Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required(ErrorMessage = "Please select journey date!")]
        public DateTime JourneyDate{ get; set; }

        [Required(ErrorMessage = "Please write journey start place address!")]
        public string PlaceFrom { get; set; }

        [Required(ErrorMessage = "Please write journey to place address!")]
        public string PlaceTo { get; set; }

        [Required(ErrorMessage = "Please select journey start time!")]
        public DateTime JourneyStartTime { get; set; }

        [Required(ErrorMessage = "Please select journey end time!")]
        public DateTime JourneyEndTime { get; set; }

        [Required(ErrorMessage = "Please wirte a sort journey description and causes!")]
        public string JourneyDescription { get; set; }

        [Required(ErrorMessage = "Please seletc driver and vehicle!")]
        [Display(Name = "Select Driver")]
        public int DriverVehicleId { get; set; }
        public DriverVehicle DriverVehicle { get; set; }
        public List<DriverVehicle> DriverVehicles { get; set; }

        public bool IsApproved { get; set; }
        public bool IsCancelled { get; set; }

    }
}
