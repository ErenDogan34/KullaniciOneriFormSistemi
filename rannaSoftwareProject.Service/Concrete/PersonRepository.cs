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
    public class PersonRepository : GenericRepository<User>, IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> GetByEmailUser(User user)
        {
            var result = _context.Users.FirstOrDefaultAsync(x=>x.Email==user.Email && x.isActive==true);
            if(result==null)
            {
                return false;
            }
            return true;
        }

        public async Task<User> GetByIdUserAsync(int id)
        {
            var person=await _context.Users.FindAsync(id);
            return person;
        }

        public async Task<User> GetByUserNameAsync(string name)
        {
            var person =await  _context.Users.FirstOrDefaultAsync(x=>x.UserName==name);
            return person;
        }

        public async Task PersonAddAsync(User user)
        {
            if(user==null || user.RoleId==0)
            {
                throw new ArgumentNullException(nameof(user), "Kullanıcı nesnesi null olamaz.");
            }
            user.isActive = true;
            user.RoleId = 2;
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task PersonDeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user==null)
            {
                throw new ArgumentNullException(nameof(user), "Kullanıcı nesnesi null olamaz.");

            }
            user.isActive=false;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> PersonGetAllAsync()
        {
            var person=await _context.Users.Where(x=>x.isActive==true).ToListAsync();
            return person;
        }

        public async Task<bool> UpdatePerson(User user)
        {
            var person = await _context.Users.FindAsync(user.Id);
            if(person==null)
            {
                return false;
            }
            person.UserName = user.UserName;
            person.Name = user.Name;
            person.Email = user.Email;
            person.LastName = user.LastName;
            person.Password = user.Password;
            person.RoleId = user.RoleId;
            _context.Users.Update(person);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
