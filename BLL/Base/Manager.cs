using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.Contracts;
using Repository.Base;

namespace BLL.Base
{
    public abstract class Manager<T> where T:class
    {
        private Repository<T> _repository;

        private Manager(Repository<T> repository )
        {
            _repository = repository;
        }

        public virtual bool Add(T entity)
        {
            return _repository.Add(entity);
        }

        public virtual bool Update(T entity)
        {
            return _repository.Update(entity);
        }

        public virtual bool Remove(IDeletable entity)
        {
            return _repository.Remove(entity);
        }

        public virtual ICollection<T> GetAll(bool withDeleted = false)
        {
            return _repository.GetAll(withDeleted);
        }
    }
}
