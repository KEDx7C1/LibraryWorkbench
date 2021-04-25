using LibraryWorkbench.Data;
using LibraryWorkbench.DTO;
using LibraryWorkbench.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWorkbench.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _books = new BooksRepository();

        [HttpGet]
        public async Task<IEnumerable<IBook>> Get()
        {
            List<IBook> books = await _books.GetAllBooksAsync();
            return books;
        }

        [Route("{author}")]
        [HttpGet]
        public async Task<IEnumerable<IBook>> GetByAuthor(string author)
        {
            List<IBook> books = await _books.GetBooksByAuthorAsync(author);
            return books;
        }

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

        [HttpDelete]
        public async Task<IActionResult> Remove(string author, string title)
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
