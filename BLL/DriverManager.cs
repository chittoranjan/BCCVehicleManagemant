using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using Repository;

namespace BLL
{

    public class DriverManager
    {
        readonly DriverRepository _repository = new DriverRepository();

        public bool Add(Driver driver)
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

        public bool Update(Driver driver)
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

        public bool Remove(Driver driver)
        {
            if (driver.Id == 0)
            {
                throw new Exception("Removable driver is not selected!");
            }
            driver.IsDeleted = true;
            return _repository.Remove(driver);
        }

        public List<Driver> GetAll(bool withDeleted = false)
        {
            return _repository.GetAll(withDeleted);
        }

        public Driver GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
