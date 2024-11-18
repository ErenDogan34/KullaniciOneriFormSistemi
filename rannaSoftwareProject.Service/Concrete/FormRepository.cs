using Microsoft.EntityFrameworkCore;
using rannaSoftwareProject.Data.Context;
using rannaSoftwareProject.Data.Entities;
using rannaSoftwareProject.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rannaSoftwareProject.Service.Concrete
{
    public class FormRepository : IFormRepository
    {
        private readonly ApplicationDbContext _context;

        public FormRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckForm(int id)
        {
            var form=await _context.SupportForms.FindAsync(id);
            form.Status = FormStatus.Processed;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task FormAddAsync(SupportForm form)
        {
            form.isActive = true;
            form.Status = FormStatus.Pending;
            await _context.SupportForms.AddAsync(form);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FormDeleteAsync(int id)
        {
            var form = await _context.SupportForms.FindAsync(id);
            form.isActive = false;
            form.Status=FormStatus.Deleted;
            _context.SupportForms.Update(form);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SupportForm>> FormGetAllAsync()
        {
            return await _context.SupportForms.Where(x => x.isActive == true).ToListAsync();
        }
    }
}
