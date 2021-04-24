using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWorkbench.DTO;
using LibraryWorkbench.Aggregators;

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
                return _readingUsers.GetReadingUsers().Select(x => x.User).ToList();
            });
            return persons.Cast<Person>().ToList();
            
        }
    }
}
