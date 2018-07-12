using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.Contracts;
using Repository.Base;

namespace BLL.Base
{
    public abstract class Manager<T>:IDisposable where T:class
    {
        protected Repository<T> Repository;

        protected Manager(Repository<T> repository )
        {
            Repository = repository;
        }

        public virtual bool Add(T entity)
        {
            return Repository.Add(entity);
        }

        public virtual bool Update(T entity)
        {
            return Repository.Update(entity);
        }

        public virtual bool Remove(IDeletable entity)
        {
            return Repository.Remove(entity);
        }

        public virtual ICollection<T> GetAll(bool withDeleted = false)
        {
            return Repository.GetAll(withDeleted);
        }

        public virtual T GetById(int id)
        {
            return Repository.GetById(id); 
        }
        public void Dispose()
        {
            Repository?.Dispose();
        }
    }
}
