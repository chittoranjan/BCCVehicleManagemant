using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;

namespace BCCVehicleRequisitionManagementSystem.ViewModels
{
    public class VehicleTypeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input vehicle type name!")]
        [Display(Name = "Vehicle Type")]
        public string TypeName { get; set; }

        public string Description { get; set; }

        public List<Vehicle> Vehicles { get; set; }

    }
}
