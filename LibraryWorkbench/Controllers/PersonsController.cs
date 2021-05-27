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
        private readonly IPersonsService _personsService;

        public PersonsController(IPersonsService personsService)
        {
            _personsService = personsService;
        }
        /// <summary>
        /// Get all persons
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            try
            {
                return new OkObjectResult(_personsService.GetAllPersons());
            }
            catch
            {
                return new NotFoundResult();
            }
            
        }
        /// <summary>
        /// Get person's book (Hometask 2.0.4.C)
        /// </summary>
        /// <param name="id">PersonId</param>
        [HttpGet("{id}/book")]
        public IActionResult GetPersonBooksById(int id)
        {
            try
            {
                return new OkObjectResult(_personsService.GetPersonBooksById(id));
            }
            catch
            {
                return new NotFoundResult();
            }
        }
        /// <summary>
        /// Create new peson (Hometask 2 7.1.1)
        /// </summary>
        /// <param name="personDto">PersonDTO</param>
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
        /// Update existing person (Hometask 2 7.1.2)
        /// </summary>
        [HttpPut]
        public PersonDTO UpdatePerson(PersonDTO personDto)
        {
            return _personsService.UpdatePerson(personDto);
        }
        /// <summary>
        /// Give book to person (Hometask 2 7.1.6)
        /// </summary>
        /// <param name="bookId">BookId</param>
        /// <param name="personId">PersonId</param>
        [HttpPut("{personId}/Book")]
        public PersonDTO GiveBook(int bookId, int personId)
        {
            return _personsService.GiveBook(personId, bookId);
        }
        /// <summary>
        /// Return person book (Hometask 2 7.1.7)
        /// </summary>
        /// <param name="personId">PersonId</param>
        /// <param name="bookId">BookId</param>
        [HttpDelete("{personId}/Book")]
        public PersonDTO ReturnBook(int bookId, int personId)
        {
            return _personsService.ReturnBook(personId, bookId);
        }
        /// <summary>
        /// Delete person by Id (Hometask 2 7.1.3)
        /// </summary>
        /// <param name="id">PersonId</param>
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            return StatusCode(_personsService.DeletePersonById(id));
        }
        /// <summary>
        /// Delete persons by fullname (Hometask 2 7.1.4)
        /// </summary>
        /// <param name="personDto">PersonDto</param>
        [HttpDelete("byFullName")]
        public IActionResult DeletePersonsByFullName([FromBody]PersonDTO personDto)
        {
            return StatusCode(_personsService.DeletePersonsByFullName(personDto));
        }
    }
}
