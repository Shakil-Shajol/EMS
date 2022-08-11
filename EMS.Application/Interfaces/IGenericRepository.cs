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
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Remove(int id);
        Task<int> Update(T entity);
    }
}
