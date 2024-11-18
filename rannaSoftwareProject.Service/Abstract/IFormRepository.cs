using rannaSoftwareProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rannaSoftwareProject.Service.Abstract
{
    public interface IFormRepository
    {
        Task FormAddAsync(SupportForm form);
        Task<bool> FormDeleteAsync(int id);
        Task<IEnumerable<SupportForm>> FormGetAllAsync();
        Task<bool> CheckForm(int id);

    }
}
