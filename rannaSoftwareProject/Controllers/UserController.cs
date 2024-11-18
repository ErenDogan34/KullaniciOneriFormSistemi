﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rannaSoftwareProject.Business.Abstract;
using rannaSoftwareProject.Data.Entities;
using rannaSoftwareProject.Service.Abstract;

namespace rannaSoftwareProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IPersonBusinessService repository;
        public UserController(IPersonBusinessService repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                await repository.PersonAddAsync(user);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new
                {
                    Title = "Hata",
                    Message = ex.Message
                });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            user.RoleId = 1;
            var result=await repository.PersonAddAsync(user);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await repository.PersonDeleteAsync(id);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new
                {
                    Title = "Hata",
                    Message = ex.Message
                });
            }

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUser()
        {
            var person = await repository.PersonGetAllAsync();
            return Ok(person);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetById(int id)
        {
            var person=await repository.GetByIdUserAsync(id);
            return Ok(person.UserName);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdPerson(int id)
        {
            var person = await repository.GetByIdUserAsync(id);
            return Ok(person);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePerson(User user)
        {
            var result = await repository.UpdatePerson(user);
            return Ok(result);
        }
    }
}
