﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;

namespace BCCVehicleRequisitionManagementSystem.Repository.Contracts
{
    public interface IEmployeeDesignationRepository:IRepository<EmployeeDesignation>
    {
        ICollection<EmployeeDesignation> GetByDepartmentId(int departmentId);
    }

}
