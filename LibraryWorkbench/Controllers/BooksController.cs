using LibraryWorkbench.Data;
using LibraryWorkbench.DTO;
using LibraryWorkbench.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWorkbench.Controllers
{
    /// <summary>
    /// 2.0.3
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _books = new BooksRepository();
        /// <summary>
        /// 2.0.4.A
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<IBook>> Get()
        {
            List<IBook> books = await _books.GetAllBooksAsync();
            return books;
        }
        /// <summary>
        /// 2.0.4.B
        /// </summary>
        [Route("{author}")]
        [HttpGet]
        public async Task<IEnumerable<IBook>> GetByAuthor(string author)
        {
            List<IBook> books = await _books.GetBooksByAuthorAsync(author);
            return books;
        }
        /// <summary>
        /// 2.0.5, 2.2.2.A
        /// </summary>
        [HttpPost]
        public async Task<IEnumerable<Book>> Add(BookDTO book)
        {
            List<IBook> books = await Task.Run(() =>
            {
                _books.AddBook((IBook)book);
                return _books.GetAllBooks();
            });
            return books.Cast<Book>().ToList();
        }
        /// <summary>
        /// 2.0.6
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Remove(string author, string title)
        {
            if (author == null || title == null)
                return BadRequest();
            else
            {
                IBook book = await _books.GetBookByAuthorAndTitleAsync(author, title);
                if (book != null)
                {
                    await _books.RemoveBookAsync(book);
                    return Ok();
                }
                else return NotFound();
            }
            
        }
    }
}
