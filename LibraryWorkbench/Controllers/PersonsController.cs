using LibraryWorkbench.Core;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
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
        private readonly IPersonsService _personsService;

        public PersonsController(DataContext context, IPersonsService personsService)
        {
            _context = context;
            _persons = new PersonsRepository(_context);
            _personsService = personsService;
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
                return new OkObjectResult(_personsService.GetPersonBooksById(id));
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
        public IActionResult CreatePerson(PersonDTO personDto)
        {
            PersonDTO result = _personsService.CreatePerson(personDto);
            if (result != null)
                return new ObjectResult(result);
            else
                return new BadRequestObjectResult("Person already exist");
        }
        /// <summary>
        /// Hometask 2 7.1.2
        /// </summary>
        [HttpPut]
        public PersonDTO UpdatePerson(PersonDTO personDto)
        {
            return _personsService.UpdatePerson(personDto);
        }
        /// <summary>
        /// Hometask 2 7.1.6
        /// </summary>
        [HttpPut]
        [Route("{personId}/Book")]
        public PersonDTO GiveBook(int bookId, int personId)
        {
            return _personsService.GiveBook(personId, bookId);
        }
        /// <summary>
        /// Hometask 2 7.1.7
        /// </summary>
        [HttpDelete]
        [Route("{personId}/Book")]
        public PersonDTO ReturnBook(int bookId, int personId)
        {
            return _personsService.ReturnBook(personId, bookId);
        }
        /// <summary>
        /// Hometask 2 7.1.3
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePerson(int id)
        {
            return StatusCode(_personsService.DeletePersonById(id));
        }
        /// <summary>
        /// Hometask 2 7.1.4
        /// </summary>
        [HttpDelete]
        [Route("byFullName")]
        public IActionResult DeletePersonsByFullName([FromBody]PersonDTO personDto)
        {
            return StatusCode(_personsService.DeletePersonsByFullName(personDto));
        }
    }
}
