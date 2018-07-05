using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Model;

namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class EmployeeDesignation
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(250)]
        public string Designation { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public bool IsDeleted { get; set; } 

    }
}