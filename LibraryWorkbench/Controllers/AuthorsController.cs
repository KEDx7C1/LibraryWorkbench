using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryWorkbench.Controllers
{
    /// <summary>
    /// Author API
    /// </summary>
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
        /// Get all authors (HomeTask 2 7.3.1)
        /// </summary>
        [HttpGet]
        public IEnumerable<AuthorDto> GetAuthors()
        {
            return _authorsService.GetAllAuthors();
        }
        /// <summary>
        /// Get author by Id (Hometask 2 7.3.2)
        /// </summary>
        /// <param name="id">AuthorId</param>
        [HttpGet("{id}/books")]
        public IActionResult GetBooksByAuthor(int id)
        {
            return new OkObjectResult(_authorsService.GetBooksByAuthor(id));
        }
        /// <summary>
        /// Create author with books (Hometask 2 7.3.3)
        /// </summary>
        /// <param name="authorWithBooks">AuthorWithBooksDto</param>
        [HttpPost]
        public IActionResult CreateAuthor(AuthorWithBooksDto authorWithBooks)
        {
            return new OkObjectResult(_authorsService.CreateAuthorWithBooks(authorWithBooks));
        }
        /// <summary>
        /// Delete author by Id (Hometask 2 7.3.4)
        /// </summary>
        /// <param name="authorId">AuthorId</param>
        [HttpDelete("{authorId}")]
        public IActionResult DeleteAuthor(int authorId)
        {
            _authorsService.DeleteAuthor(authorId);
            return new OkResult();
        }
    }
}
