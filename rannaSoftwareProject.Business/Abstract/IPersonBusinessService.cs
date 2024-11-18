using rannaSoftwareProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rannaSoftwareProject.Business.Abstract
{
    public interface IPersonBusinessService
    {
        Task<bool> PersonAddAsync(User user);
        Task<bool> PersonDeleteAsync(int id);
        Task<IEnumerable<User>> PersonGetAllAsync();
        Task<User> GetByUserNameAsync(string name);
        Task<User> GetByIdUserAsync(int id);
        Task<bool> UpdatePerson(User user);

    }
}
