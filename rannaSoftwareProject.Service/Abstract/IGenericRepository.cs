using rannaSoftwareProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rannaSoftwareProject.Service.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity,int roleId);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        List<T> GetListAll();
    }
}
