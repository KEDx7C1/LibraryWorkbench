using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWorkbench.DTO;
using LibraryWorkbench.Data;
using LibraryWorkbench.Interfaces;

namespace LibraryWorkbench.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsRepository _users = new PersonsRepository();

        [HttpGet]
        public async Task<IEnumerable<PersonDTO>> GetAll()
        {
            List<PersonDTO> users = await Task.Run(() => _users.Get());
            return users;
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IEnumerable<PersonDTO>> GetByName(string name)
        {
            List<PersonDTO> users = await Task.Run(() => _users.GetByName(name));
            return users;
        }

        [HttpPost]
        public async Task<IEnumerable<Person>> AddUser(PersonDTO user)
        {
            List<Person> users = await Task.Run(() =>
            {
                _users.Add(user);
                return _users.Get().Cast<Person>().ToList();
            });
            return users;
            
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveUser(string firstName, string lastName, string patronym)
        {
            IActionResult actionResult = await Task.Run(() =>
            {
                _users.Remove(firstName, lastName, patronym);
                return Ok();
            });
            return actionResult;
        }
    }
}
