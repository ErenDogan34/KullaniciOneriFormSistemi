using rannaSoftwareProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rannaSoftwareProject.Business.Abstract
{
    public interface IFormBusinessService
    {
        Task<bool> FormAddAsync(SupportForm form);
        Task<bool> FormDeleteAsync(int id);
        Task<IEnumerable<SupportForm>> FormGetAllAsync();
        Task<bool> CheckForm(int id);
    }
}
