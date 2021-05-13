using LibraryWorkbench.Core;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
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
        private readonly DataContext _context;
        private readonly PersonsRepository _persons;

        public PersonsController(DataContext context)
        {
            _context = context;
            _persons = new PersonsRepository(_context);
        }
        /// <summary>
        /// 2.0.4.A
        /// </summary>
        [HttpGet]
        public IEnumerable<Person> GetAllPersons()
        {
            return _persons.GetAll();
        }
        /// <summary>
        /// 2.0.4.C
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IEnumerable<Book> GetPersonBooksById(int id)
        {
            return _persons.Get(id).Books;
        }
        /// <summary>
        /// 2.0.5, 2.2.2.Б
        /// </summary>
        [HttpPost]
        public PersonShort CreatePerson(Person person)
        {
            _persons.Create(person);
            _persons.Save();
            PersonShort result = person;
            return result;
        }
        [HttpPut]
        public Person UpdatePerson(Person person)
        {
            _persons.Update(person);
            _persons.Save();
            return person;
        }

        [HttpPut]
        [Route("{personId}")]
        public Person GiveBook(int bookId, int personId)
        {
            
            PersonsServices.GiveBook(personId, bookId, _context);
            return _persons.Get(personId);
        }
        [HttpDelete]
        [Route("{personId}")]
        public Person ReturnBook(int bookId, int personId)
        {
            PersonsServices.ReturnBook(personId, bookId, _context);
            return _persons.Get(personId);
        }
        /// <summary>
        /// 2.0.6
        /// </summary>
        [HttpDelete]
        public IActionResult DeletePerson(int id)
        {
            return StatusCode(PersonsServices.DeletePersonById(id, _context));
        }
        [HttpDelete]
        [Route("byFullName")]
        public IActionResult DeletePersonsByFullName(string firstName, string lastName, string middleName)
        {
            PersonShort person = new Person() { FirstName = firstName, LastName = lastName, MiddleName = middleName };
            return StatusCode(PersonsServices.DeletePersonsByFullName(person, _context));
        }
    }
}
