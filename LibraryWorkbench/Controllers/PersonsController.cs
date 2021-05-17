using LibraryWorkbench.Core;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LibraryWorkbench.Controllers
{
    /// <summary>
    /// Hometask 2 7.1
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
        
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            try
            {
                return new OkObjectResult(_persons.GetAll());
            }
            catch
            {
                return new NotFoundResult();
            }
            
        }
        /// <summary>
        /// 2.0.4.C
        /// </summary>
        [HttpGet]
        [Route("{id}/book")]
        public IActionResult GetPersonBooksById(int id)
        {
            try
            {
                return new OkObjectResult(_persons.Get(id).Books);
            }
            catch
            {
                return new BadRequestResult();
            }
        }
        /// <summary>
        /// Hometask 2 7.1.1
        /// </summary>
        [HttpPost]
        public IActionResult CreatePerson(Person person)
        {
            Object result = PersonsServices.CreatePerson(person, _context);
            if (result != null)
                return new ObjectResult(result);
            else
                return new BadRequestObjectResult("Person already exist");
        }
        /// <summary>
        /// Hometask 2 7.1.2
        /// </summary>
        [HttpPut]
        public Person UpdatePerson(Person person)
        {
            _persons.Update(person);
            _persons.Save();
            return person;
        }
        /// <summary>
        /// Hometask 2 7.1.6
        /// </summary>
        [HttpPut]
        [Route("{personId}/Book")]
        public Person GiveBook(int bookId, int personId)
        {

            PersonsServices.GiveBook(personId, bookId, _context);
            return _persons.Get(personId);
        }
        /// <summary>
        /// Hometask 2 7.1.7
        /// </summary>
        [HttpDelete]
        [Route("{personId}/Book")]
        public Person ReturnBook(int bookId, int personId)
        {
            PersonsServices.ReturnBook(personId, bookId, _context);
            return _persons.Get(personId);
        }
        /// <summary>
        /// Hometask 2 7.1.3
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePerson(int id)
        {
            return StatusCode(PersonsServices.DeletePersonById(id, _context));
        }
        /// <summary>
        /// Hometask 2 7.1.4
        /// </summary>
        [HttpDelete]
        [Route("byFullName")]
        public IActionResult DeletePersonsByFullName(string firstName, string lastName, string middleName)
        {
            PersonShort person = new Person() { FirstName = firstName, LastName = lastName, MiddleName = middleName };
            return StatusCode(PersonsServices.DeletePersonsByFullName(person, _context));
        }
    }
}
