using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWorkbench.Controllers
{
    /// <summary>
    ///     Person API (Hometask 2 7.1)
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
        ///     Get all persons
        /// </summary>
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return new OkObjectResult(_personsService.GetAllPersons());
        }

        /// <summary>
        ///     Get person's book (Hometask 2.0.4.C)
        /// </summary>
        /// <param name="id">PersonId</param>
        [HttpGet("{id}/book")]
        public IActionResult GetPersonBooksById(int id)
        {
            return new OkObjectResult(_personsService.GetPersonBooksById(id));
        }

        /// <summary>
        ///     Create new peson (Hometask 2 7.1.1)
        /// </summary>
        /// <param name="personDto">PersonDTO</param>
        [HttpPost]
        public IActionResult CreatePerson(PersonDto personDto)
        {
            var result = _personsService.CreatePerson(personDto);
            if (result != null)
                return new OkObjectResult(result);
            return new BadRequestObjectResult("Person already exist");
        }

        /// <summary>
        ///     Update existing person (Hometask 2 7.1.2)
        /// </summary>
        [HttpPut]
        public PersonDto UpdatePerson(PersonDto personDto)
        {
            return _personsService.UpdatePerson(personDto);
        }

        /// <summary>
        ///     Give book to person (Hometask 2 7.1.6)
        /// </summary>
        /// <param name="bookId">BookId</param>
        /// <param name="personId">PersonId</param>
        [HttpPut("{personId}/Book")]
        public PersonDto GiveBook(int bookId, int personId)
        {
            return _personsService.GiveBook(personId, bookId);
        }

        /// <summary>
        ///     Return person book (Hometask 2 7.1.7)
        /// </summary>
        /// <param name="personId">PersonId</param>
        /// <param name="bookId">BookId</param>
        [HttpDelete("{personId}/Book")]
        public PersonDto ReturnBook(int bookId, int personId)
        {
            return _personsService.ReturnBook(personId, bookId);
        }

        /// <summary>
        ///     Delete person by Id (Hometask 2 7.1.3)
        /// </summary>
        /// <param name="id">PersonId</param>
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            _personsService.DeletePersonById(id);
            return new OkResult();
        }

        /// <summary>
        ///     Delete persons by fullname (Hometask 2 7.1.4)
        /// </summary>
        /// <param name="personDto">PersonDto</param>
        [HttpDelete("byFullName")]
        public IActionResult DeletePersonsByFullName([FromBody] PersonDto personDto)
        {
            _personsService.DeletePersonsByFullName(personDto);
            return new OkResult();
        }
    }
}