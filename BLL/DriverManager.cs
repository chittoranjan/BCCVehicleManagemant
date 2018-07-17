using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.BLL.Contract;
using BCCVehicleRequisitionManagementSystem.Models.Contracts;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using BCCVehicleRequisitionManagementSystem.Repository.Contracts;
using BLL.Base;
using Repository;

namespace BLL
{

    public class DriverManager:Manager<Driver>,IDriverManager
    {
        private readonly IDriverRepository _repository;
        public DriverManager(IDriverRepository repository) : base(repository)
        {
            this._repository = repository;
        }
        public override bool Add(Driver driver)
        {
            if (string.IsNullOrEmpty(driver.Name))
            {
                throw new Exception("Driver Name is not provided!");
            }
            if (string.IsNullOrEmpty(driver.MobileNo))
            {
                throw new Exception("Driver mobile no is not provided!");
            }
            if (string.IsNullOrEmpty(driver.LicenceNo))
            {
                throw new Exception("Driving licence is not provided!");
            }
            if (string.IsNullOrEmpty(driver.NID))
            {
                throw new Exception("NID no is not provided!");
            }
            if (string.IsNullOrEmpty(driver.Address))
            {
                throw new Exception("Please write present address!");
            }
            return _repository.Add(driver);
        }

        public override bool Update(Driver driver)
        {
            if (string.IsNullOrEmpty(driver.Name))
            {
                throw new Exception("Driver Name is not provided!");
            }
            if (string.IsNullOrEmpty(driver.MobileNo))
            {
                throw new Exception("Driver mobile no is not provided!");
            }
            if (string.IsNullOrEmpty(driver.LicenceNo))
            {
                throw new Exception("Driving licence is not provided!");
            }
            if (string.IsNullOrEmpty(driver.NID))
            {
                throw new Exception("NID no is not provided!");
            }
            if (string.IsNullOrEmpty(driver.Address))
            {
                throw new Exception("Please write present address!");
            }
            return _repository.Update(driver);
        }

        public override Driver GetById(int id)
        {
            if (id==0)
            {
                throw new Exception("Driver id is not provided!");
            }
            return _repository.GetById(id);
        }       
    }
}
