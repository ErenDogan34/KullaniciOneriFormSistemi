using rannaSoftwareProject.Business.Abstract;
using rannaSoftwareProject.Data.Entities;
using rannaSoftwareProject.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rannaSoftwareProject.Business.Concrete
{
    public class FormBusinessManager : IFormBusinessService
    {
        private readonly IFormRepository _formRepository;

        public FormBusinessManager(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<bool> CheckForm(int id)
        {
            var result= await _formRepository.CheckForm(id);
            if(result==false)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> FormAddAsync(SupportForm form)
        {
            if (form == null)
            {
                return false;
            }
            await _formRepository.FormAddAsync(form);
            return true;
        }

        public async Task<bool> FormDeleteAsync(int id)
        {
            if (id == 0) {
                return false;
            }
            await _formRepository.FormDeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<SupportForm>> FormGetAllAsync()
        {
            return await _formRepository.FormGetAllAsync();
        }
    }
}
