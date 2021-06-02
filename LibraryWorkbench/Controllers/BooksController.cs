using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryWorkbench.Controllers
{
    /// <summary>
    /// Books API (Hometask 1 2.0.3)
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        /// <summary>
        /// Get all books (Hometask 1 2.0.4.A)
        /// </summary>
        [HttpGet]
        public IEnumerable<BookDto> GetAllBooks()
        {

            return _booksService.GetAllBooks();
        }
        /// <summary>
        /// Get books by author fullname (Hometask 2 7.2.4)
        /// </summary>
        ///<param name="firstName">Authors firstname</param>
        ///<param name="lastName">Authors lastname</param>
        ///<param name="middleName">Authors middlename</param>

        [HttpGet("byAuthor")]
        public IEnumerable<BookDto> GetBooksByAuthor(string firstName, string lastName, string middleName)
        {

            return _booksService.GetBooksByAuthor(firstName, lastName, middleName);
        }
        /// <summary>
        /// Get books by genre (Hometask 2 7.2.5)
        /// </summary>
        /// <param name="genre">GenreName</param>
        [HttpGet("byGenre/{genre}")]
        public IEnumerable<BookDto> GetBooksByGenre(string genre)
        {
            return _booksService.GetBooksByGenre(genre);
        }
        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id">BookId</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            return new OkObjectResult(_booksService.GetBook(id));
        }
        /// <summary>
        /// Create new book (Hometask 2 7.2.1)
        /// </summary>
        /// <param name="bookDto">BookDTO</param>
        [HttpPost]
        public BookDto CreateBook(BookDto bookDto)
        {
            return _booksService.CreateBook(bookDto);
        }
        /// <summary>
        /// Delete book by id (Hometask 2 7.2.2)
        /// </summary>
        /// <param name="id">BookId</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _booksService.DeleteBook(id);
            return new OkResult();
        }
        /// <summary>
        /// Change genre for existing book (Hometask 2 7.2.3)
        /// </summary>
        /// <param name="bookDto">BookDTO</param>
        [HttpPut]
        public BookDto ChangeGanre(BookDto bookDto)
        {
            return _booksService.ChangeGanre(bookDto);
        }
    }
}
