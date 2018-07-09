using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.Contracts;
using BCCVehicleRequisitionManagementSystem.Models.DatabaseContext;

namespace Repository.Base
{
    public abstract  class Repository<T> where T:class 
    {
        VehicleDbContext db=new VehicleDbContext();
        public virtual bool Add(T entity)
        {
            db.Set<T>().Add(entity);
            return db.SaveChanges() > 0;

        }

        public virtual bool Update(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry(entity).State=EntityState.Modified;
            return db.SaveChanges()>0;
        }

        public virtual bool Remove(IDeletable entity)
        {
            entity.Delete();
            return Update((T)entity);
        }

        public virtual ICollection<T> GetAll(bool withDeleted=false)
        {
            return db.Set<T>().ToList();
            
        }

        public virtual T GetById(int id)
        {
            return db.Set<T>().FirstOrDefault(c => ((IEntityModel) c).Id == id);
        }
    }
}
