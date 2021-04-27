using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Data.Interfaces;
using LibraryWorkbench.Data.Models;
using LibraryWorkbench.Data.Models.Interfaces;
using LibraryWorkbench.Core.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWorkbench.Controllers
{
    /// <summary>
    /// 2.0.3
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsRepository _persons = new PersonsRepository();
        /// <summary>
        /// 2.0.4.A
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<IPerson>> GetAllPersons()
        {
            List<IPerson> persons = await _persons.GetAllPersonsAsync();
            return persons;
        }
        /// <summary>
        /// 2.0.4.C
        /// </summary>
        [HttpGet]
        [Route("{name}")]
        public async Task<IEnumerable<IPerson>> GetPersonByName(string name)
        {
            List<IPerson> persons = await _persons.GetPersonsByNameAsync(name);
            return persons;
        }
        /// <summary>
        /// 2.0.5, 2.2.2.Б
        /// </summary>
        [HttpPost]
        public async Task<IEnumerable<PersonShort>> AddPerson(Person person)
        {
            List<PersonShort> persons = await Task.Run(() =>
            {
                _persons.AddPerson(person);
                return _persons.GetAllPersons().Cast<PersonShort>().ToList();
            });
            return persons;
        }
        /// <summary>
        /// 2.0.6
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> RemovePerson(string firstName, string lastName, string patronym)
        {
            return StatusCode(await RemovePersons.RemovePerson(firstName, lastName, patronym, _persons));
            
        }
    }
}
