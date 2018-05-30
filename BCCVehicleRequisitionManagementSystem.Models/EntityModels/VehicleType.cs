using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class VehicleType
    {
        public byte Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public List<Vehicle> Vehicles { get; set; }

    }
}
