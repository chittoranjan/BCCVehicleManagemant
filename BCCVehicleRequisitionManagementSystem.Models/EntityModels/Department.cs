using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.Contracts;

namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class Department : IEntityModel,IDeletable
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(250)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        public bool Delete()
        {
            IsDeleted = true;
            return IsDeleted;
        }
        public List<EmployeeDesignation> EmployeeDesignations { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
