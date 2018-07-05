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
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(250)]
        public string TypeName { get; set; }

        public string Description { get; set; }
        public bool IsDeleted { get; set; }

    }
}
