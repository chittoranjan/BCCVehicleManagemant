using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.BLL.Contract;
using BCCVehicleRequisitionManagementSystem.Models.Contracts;
using BCCVehicleRequisitionManagementSystem.Repository.Contracts;
using Repository.Base;

namespace BLL.Base
{
    public abstract class Manager<T>:IManager<T> where T:class, IEntityModel
    {
        protected IRepository<T> repository;

        protected Manager(IRepository<T> repository )
        {
            this.repository = repository;
        }

        public virtual bool Add(T entity)
        {
            return repository.Add(entity);
        }

        public virtual bool Update(T entity)
        {
            return repository.Update(entity);
        }

        public virtual bool Remove(IDeletable entity)
        {
            return repository.Remove(entity);
        }

        public bool Remove(ICollection<IDeletable> entities)
        {
            return repository.Remove(entities);
        }

        public virtual ICollection<T> GetAll(bool withDeleted = false)
        {
            return repository.GetAll(withDeleted);
        }

        public virtual T GetById(int id)
        {
            return repository.GetById(id); 
        }

        public ICollection<T> Get(Expression<Func<T, bool>> query)
        {
            return repository.Get(query);
        }

        public void Dispose()
        {
            repository?.Dispose();
        }
    }
}
