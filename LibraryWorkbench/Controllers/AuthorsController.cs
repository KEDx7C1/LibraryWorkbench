using LibraryWorkbench.Core;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Intefaces;
using LibraryWorkbench.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryWorkbench.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;
        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }
        /// <summary>
        /// HomeTask 2 7.3.1
        /// </summary>
        [HttpGet]
        public IEnumerable<AuthorDTO> GetAuthors()
        {
            return _authorsService.GetAuthors();
        }
        /// <summary>
        /// Hometask 2 7.3.2
        /// </summary>
        [HttpGet]
        [Route("books")]
        public IActionResult GetBooksByAuthor([FromBody]AuthorDTO authorDto)
        {
            try
            {
                return new ObjectResult(_authorsService.GetBooksByAuthor(authorDto));
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
        public IActionResult CreateAuthor(AuthorWithBooksDTO authorWithBooks)
        {
            var result = _authorsService.CreateAuthorWithBooks(authorWithBooks);
            if (result != null)
                return new OkObjectResult(result);
            else
                return new BadRequestResult();
        }
        /// <summary>
        /// Hometask 2 7.3.4
        /// </summary>
        [HttpDelete]
        public IActionResult DeleteAuthor([FromBody] AuthorDTO author)
        {
            int operationStatus = _authorsService.DeleteAuthor(author);
            if (operationStatus == 405)
                return StatusCode(operationStatus, "Author has books in library");
            else
                return StatusCode(operationStatus);
        }
    }
}
