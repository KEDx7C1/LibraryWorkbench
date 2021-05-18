using LibraryWorkbench.Core;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Core.Models;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryWorkbench.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly DataContext _context;
        public AuthorsController(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// HomeTask 2 7.3.1
        /// </summary>
        [HttpGet]
        public IEnumerable<Author> GetAuthors()
        {
            return AuthorsService.GetAuthors(_context);
        }
        /// <summary>
        /// Hometask 2 7.3.2
        /// </summary>
        [HttpGet]
        [Route("books")]
        public IActionResult GetBooksByAuthor(string firstName, string lastName, string middleName)
        {
            try
            {
                return new ObjectResult(AuthorsService.GetBooksByAuthor(firstName, lastName, middleName, _context));
            }
            catch
            {
                return new BadRequestResult();
            }
        }
        /// <summary>
        /// Hometask 2 7.3.3
        /// </summary>
        [HttpPost]
        public IActionResult CreateAuthor(AuthorWithBooks authorWithBooks)
        {
            var result = AuthorsService.CreateAuthorWithBooks(authorWithBooks, _context);
            if (result != null)
                return new OkObjectResult(result);
            else
                return new BadRequestResult();
        }
        /// <summary>
        /// Hometask 2 7.3.4
        /// </summary>
        [HttpDelete]
        public IActionResult DeleteAuthor([FromBody] Author author)
        {
            int operationStatus = AuthorsService.DeleteAuthor(author, _context);
            if (operationStatus == 405)
                return StatusCode(operationStatus, "Author has books in library");
            else
                return StatusCode(operationStatus);
        }
    }
}
