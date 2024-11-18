using rannaSoftwareProject.Business.Abstract;
using rannaSoftwareProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rannaSoftwareProject.Business.Concrete
{
    public class GenericBusinessManager<T>:IGenericBusinessService<T> where T : BaseEntity
    {
    }
}
