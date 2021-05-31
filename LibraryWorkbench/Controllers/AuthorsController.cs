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
        public IEnumerable<AuthorDto> GetAuthors()
        {
            return _authorsService.GetAuthors();
        }
        /// <summary>
        /// Hometask 2 7.3.2
        /// </summary>
        [HttpGet("{id}/books")]
        public IActionResult GetBooksByAuthor(int id)
        {
            return new OkObjectResult(_authorsService.GetBooksByAuthor(id));
        }
        /// <summary>
        /// Hometask 2 7.3.3
        /// </summary>
        [HttpPost]
        public IActionResult CreateAuthor(AuthorWithBooksDto authorWithBooks)
        {
            var result = _authorsService.CreateAuthorWithBooks(authorWithBooks);
            return new OkObjectResult(result);
        }
        /// <summary>
        /// Hometask 2 7.3.4
        /// </summary>
        [HttpDelete("{authorId}")]
        public IActionResult DeleteAuthor(int authorId)
        {
            _authorsService.DeleteAuthor(authorId);
            return new OkResult();
        }
    }
}
