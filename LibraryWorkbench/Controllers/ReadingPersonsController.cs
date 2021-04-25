using LibraryWorkbench.Aggregators;
using LibraryWorkbench.DTO;
using LibraryWorkbench.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWorkbench.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingPersonsController : ControllerBase
    {
        private readonly Data.ReadingPersonsRepository _readingUsers = new();

        [HttpGet]
        public async Task<IEnumerable<ReadingPersonAggregator>> GetReadingUsers()
        {
            List<ReadingPersonAggregator> readingUsers = await Task.Run(() => _readingUsers.GetReadingUsers());
            return readingUsers;
        }


        [HttpPost]
        public async Task<IEnumerable<Person>> AddReadingUser(ReadingPersonAggregator readingUser)
        {
            List<PersonDTO> persons = await Task.Run(() =>
            {
                _readingUsers.AddReadingUser(readingUser);
                return _readingUsers.GetReadingUsers().Select(x => x.Person).ToList();
            });
            return persons.Cast<Person>().ToList().Distinct();

        }
    }
}
