using LibraryWorkbench.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWorkbench.Controllers
{
    /// <summary>
    /// 2.1.2
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingPersonsController : ControllerBase
    {
        private readonly Data.ReadingPersonsRepository _readingUsers = new Data.ReadingPersonsRepository();

        [HttpGet]
        public async Task<IEnumerable<ReadingPerson>> GetReadingUsers()
        {
            List<ReadingPerson> readingUsers = await _readingUsers.GetReadingPersonsAsync();
            return readingUsers;
        }

        /// <summary>
        /// 2.1.4
        /// </summary>
        [HttpPost]
        public async Task<IEnumerable<PersonShort>> AddReadingUser(ReadingPerson readingPerson)
        {
            List<Person> persons = await Task.Run(() =>
            {
                _readingUsers.AddReadingPerson(readingPerson);
                return _readingUsers.GetReadingPersons().Select(x => x.Person).ToList();
            });
            return persons.Cast<PersonShort>().ToList().Distinct();

        }
    }
}
