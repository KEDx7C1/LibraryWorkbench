using LibraryWorkbench.Core;
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
        [HttpGet]
        public IEnumerable<Author> GetAuthors()
        {
            return AuthorsServices.GetAuthors(_context);
        }
        [HttpGet]
        [Route("books")]
        public IActionResult GetBooksByAuthor(string firstName, string lastName, string middleName)
        {
            try
            {
                return new ObjectResult(AuthorsServices.GetBooksByAuthor(firstName, lastName, middleName, _context));
            }
            catch
            {
                return new BadRequestResult();
            }
        }
        [HttpPost]
        public IActionResult CreateAuthor(AuthorWithBooks authorWithBooks)
        {
            var result = AuthorsServices.CreateAuthorWithBooks(authorWithBooks, _context);
            if (result != null)
                return new OkObjectResult(result);
            else
                return new BadRequestResult();
        }
        [HttpDelete]
        public IActionResult DeleteAuthor([FromBody] Author author)
        {
            int operationStatus = AuthorsServices.DeleteAuthor(author, _context);
            if (operationStatus == 405)
                return StatusCode(operationStatus, "Author has books in library");
            else
                return StatusCode(operationStatus);
        }
    }
}
