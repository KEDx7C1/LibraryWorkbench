using LibraryWorkbench.Core;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryWorkbench.Controllers
{
    /// <summary>
    /// 2.0.3
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        /// <summary>
        /// Books API
        /// </summary>
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        /// <summary>
        /// Get all books (Hometask 1 2.0.4.A)
        /// </summary>
        [HttpGet]
        public IEnumerable<BookDTO> GetAllBooks()
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
        public IEnumerable<BookDTO> GetBooksByAuthor(string firstName, string lastName, string middleName)
        {

            return _booksService.GetBooksByAuthor(firstName, lastName, middleName);
        }
        /// <summary>
        /// Get books by genre (Hometask 2 7.2.5)
        /// </summary>
        /// <param name="genre">GenreName</param>
        [HttpGet("byGenre/{genre}")]
        public IEnumerable<BookDTO> GetBooksByGenre(string genre)
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
            try
            {
                return new OkObjectResult(_booksService.GetBook(id));
            }
            catch
            {
                return new BadRequestResult();
            }
        }
        /// <summary>
        /// Create new book (Hometask 2 7.2.1)
        /// </summary>
        /// <param name="bookDto">BookDTO</param>
        [HttpPost]
        public BookDTO CreateBook(BookDTO bookDto)
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
            int SCode = _booksService.DeleteBook(id);
            if (SCode == 405)
                return StatusCode(SCode, "Книга у пользователя");
            else
                return StatusCode(SCode);
        }
        /// <summary>
        /// Change genre for existing book (Hometask 2 7.2.3)
        /// </summary>
        /// <param name="bookDto">BookDTO</param>
        [HttpPut]
        public BookDTO ChangeGanre(BookDTO bookDto)
        {
            return _booksService.ChangeGanre(bookDto);
        }
    }
}
