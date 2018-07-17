using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Model;
using BCCVehicleRequisitionManagementSystem.Models.Contracts;

namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class EmployeeDesignation : IEntityModel,IDeletable
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(250)]
        public string Designation { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public bool IsDeleted { get; set; }
        public bool Delete()
        {
            IsDeleted = true;
            return IsDeleted;
        }
    }
}