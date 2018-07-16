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
        [Display(Name = "Journey Date and Time")]
        public DateTime JourneyStartDateTime{ get; set; }

        [Required(ErrorMessage = "Please select journey end time!")]
        [Display(Name = "Journey End Date and Time")]
        public DateTime JourneyEndDateTime { get; set; }

        [Required(ErrorMessage = "Please write journey start place address!")]
        public string PlaceFrom { get; set; }

        [Required(ErrorMessage = "Please write journey to place address!")]
        public string PlaceTo { get; set; }

        [Required(ErrorMessage = "Please input set capasity!")]
        [Display(Name = "Seat capacity")]
        public int Seat { get; set; }

        [Required(ErrorMessage = "Please wirte a sort journey description and causes!")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public bool IsApproved { get; set; }
        public bool IsCancelled { get; set; }

    }
}
