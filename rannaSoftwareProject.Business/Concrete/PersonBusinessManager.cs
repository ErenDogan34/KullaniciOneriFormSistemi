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
    public class PersonBusinessManager : IPersonBusinessService
    {
        private readonly IPersonRepository personRepository;

        public PersonBusinessManager(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public Task<User> GetByIdUserAsync(int id)
        {
            var person=personRepository.GetByIdUserAsync(id);
            return person;
        }

        public async Task<User> GetByUserNameAsync(string name)
        {
            var person = await personRepository.GetByUserNameAsync(name);
            return person;
        }

        public async Task<bool> PersonAddAsync(User user)
        {
            if(user == null)
            {
                return false;
            }
            var result =await personRepository.GetByEmailUser(user);
            if(result==true)
            {
                return false;
            }

            await personRepository.PersonAddAsync(user);
            return true;
        }

        public async Task<bool> PersonDeleteAsync(int id)
        {
            if (id == 0) {
                return false;
            }
            await personRepository.PersonDeleteAsync(id);
            return true;    
        }

        public async Task<IEnumerable<User>> PersonGetAllAsync()
        {
            var users=await personRepository.PersonGetAllAsync();
            return users;
        }

        public async Task<bool> UpdatePerson(User user)
        {
            var result = await personRepository.UpdatePerson(user);
            if(result==false)
            {
                return false;
            }

            return true;
        }
    }
}
