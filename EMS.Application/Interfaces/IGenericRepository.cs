using EMS.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Interfaces
{
    public interface IGenericRepository<T>  where T : BaseEntity
    {
        Task<T2?> GetById<T2>(int id);
        Task<IEnumerable<T1>> GetAll<T1>();
        Task<int> Remove(int id);
        Task<int> Update(T entity);
    }
}
