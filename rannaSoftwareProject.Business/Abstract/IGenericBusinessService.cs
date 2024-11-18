using rannaSoftwareProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rannaSoftwareProject.Business.Abstract
{
    public interface IGenericBusinessService<T> where T : BaseEntity
    {
    }
}
