using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.Contracts;
using BCCVehicleRequisitionManagementSystem.Models.DatabaseContext;

namespace Repository.Base
{
    public abstract  class Repository<T>:IDisposable where T:class
    {
        protected VehicleDbContext db=new VehicleDbContext();
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

        public virtual bool Remove(ICollection<IDeletable> entitys)
        {
            int removeCount = 0;
            foreach (var entity in entitys)
            {
                bool isRemove=Remove(entity);
                if (isRemove)
                {
                    removeCount++;
                }
            }
            return entitys.Count == removeCount;
        }
        public virtual ICollection<T> GetAll(bool withDeleted=false)
        {


            return db.Set<T>().ToList();


        }

       
        public virtual T GetById(int id)
        {
            return db.Set<T>().FirstOrDefault(c => ((IEntityModel) c).Id == id);
        }
        public virtual ICollection<T> Get(Expression<Func<T, bool>> query)
        {
            return db.Set<T>().Where(query).ToList();
        }
        public virtual void Dispose()
        {
            db?.Dispose();
        }
    }
    public abstract class DeleteableRepository<T> : Repository<T> where T : class, IDeletable
    {
        public override ICollection<T> GetAll(bool withDeleted = false)
        {
            return db.Set<T>().Where(c => c.IsDeleted == false || c.IsDeleted == withDeleted).ToList();
        }
    }
}
