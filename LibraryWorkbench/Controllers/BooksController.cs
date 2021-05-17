using LibraryWorkbench.Core;
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
        private readonly DataContext _context;
        private readonly BooksRepository _books;
        public BooksController(DataContext context)
        {
            _context = context;
            _books = new BooksRepository(_context);
        }
        /// <summary>
        /// Hometask 1 2.0.4.A
        /// </summary>
        [HttpGet]
        public IEnumerable<Book> Get()
        {

            return _books.GetAll();
        }
        ///// <summary>
        ///// Hometask 2 7.2.4
        ///// </summary>

        [HttpGet]
        [Route("byAuthor")]
        public IEnumerable<Book> GetBooksByAuthor(string firstName, string lastName, string middleName)
        {

            return BooksServices.GetBooksByAuthor(firstName, lastName, middleName, _context);
        }
        ///// <summary>
        ///// Hometask 2 7.2.5
        ///// </summary>
        [HttpGet]
        [Route("byGenre/{genre}")]
        public IEnumerable<Book> GetBooksByGenre(string genre)
        {
            return BooksServices.GetBooksByGenre(genre, _context);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                return new OkObjectResult(BooksServices.GetBook(id, _context));
            }
            catch
            {
                return new BadRequestResult();
            }
        }
        /// <summary>
        /// Hometask 2 7.2.1
        /// </summary>
        [HttpPost]
        public void CreateBook(Book book)
        {
            BooksServices.CreateBook(book, _context);
        }
        ///// <summary>
        ///// Hometask 2 7.2.2
        ///// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBook(int id)
        {
            int SCode = BooksServices.DeleteBook(id, _context);
            if (SCode == 405)
                return StatusCode(SCode, "Книга у пользователя");
            else
                return StatusCode(SCode);
        }
        /// <summary>
        /// Hometask 2 7.2.3
        /// </summary>
        [HttpPut]
        public Book ChangeGanre(Book book)
        {
            return BooksServices.ChangeGanre(book, _context);
        }
    }
}
