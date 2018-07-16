using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.Contracts;

namespace BCCVehicleRequisitionManagementSystem.BLL.Contract
{
    public interface IManager<T>:IDisposable where T:class ,IEntityModel
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(IDeletable entity);
        bool Remove(ICollection<IDeletable> entities);
        ICollection<T> GetAll(bool withDeleted = false);
        T GetById(int id);
        ICollection<T> Get(Expression<Func<T, bool>> query);

    }
}
