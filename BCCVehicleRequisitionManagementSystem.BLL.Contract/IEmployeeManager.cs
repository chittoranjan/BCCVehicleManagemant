﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;

namespace BCCVehicleRequisitionManagementSystem.BLL.Contract
{
    public interface IEmployeeManager:IManager<Employee>
    {
        Employee GetByUserId(string userId);
    }
}
