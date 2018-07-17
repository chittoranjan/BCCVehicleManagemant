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
using BCCVehicleRequisitionManagementSystem.Repository.Contracts;

namespace Repository.Base
{
    public abstract  class Repository<T>:IRepository<T> where T:class,IEntityModel,IDeletable
    {
        protected DbContext Db;

        protected Repository(DbContext db)
        {
            this.Db = db;
        }

        public Repository()
        {
        }

        public virtual bool Add(T entity)
        {
            Db.Set<T>().Add(entity);
            return Db.SaveChanges() > 0;

        }

        public virtual bool Update(T entity)
        {
            Db.Set<T>().Attach(entity);
            Db.Entry(entity).State=EntityState.Modified;
            return Db.SaveChanges()>0;
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

            return Db.Set<T>().Where(c=>c.IsDeleted==false||c.IsDeleted==withDeleted).ToList();

        }

       
        public virtual T GetById(int id)
        {
            return Db.Set<T>().FirstOrDefault(c =>c.Id == id);
        }
        public virtual ICollection<T> Get(Expression<Func<T, bool>> query)
        {
            return Db.Set<T>().Where(query).ToList();
        }
        public virtual void Dispose()
        {
            Db?.Dispose();
        }
    }
    public abstract class DeleteableRepository<T> :Repository<T> where T : class, IDeletable, IEntityModel
    {
        public override ICollection<T> GetAll(bool withDeleted = false)
        {
            return Db.Set<T>().Where(c => c.IsDeleted == false || c.IsDeleted == withDeleted).ToList();
        }

        protected DeleteableRepository(DbContext db) : base(db)
        {
        }
    }
}
