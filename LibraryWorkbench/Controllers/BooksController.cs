using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWorkbench.DTO;
using LibraryWorkbench.Data;
using LibraryWorkbench.Interfaces;

namespace LibraryWorkbench.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _books = new BooksRepository();

        [HttpGet]
        public async Task<IEnumerable<BookDTO>> Get()
        {
            List<BookDTO> books = await Task.Run(() => _books.Get());
            return books;
        }

        [Route("{author}")]
        [HttpGet]
        public async Task<IEnumerable<BookDTO>> GetByAuthor(string author)
        {
            List<BookDTO> books = await Task.Run(() => _books.GetByAuthor(author));
            return books;
        }

        [HttpPost]
        public async Task<IEnumerable<Book>> Add(BookDTO book)
        {
            List<BookDTO> books = await Task.Run(() =>
            {
                _books.Add(book);
                return _books.Get();
            });
            return books.Cast<Book>().ToList();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string author, string title)
        {
            BookDTO book = await Task.Run(() => _books.GetByAuthorAndTitle(author, title));
            if (book != null)
            {
                IActionResult actionResult = await Task.Run(()=>
                {
                    _books.Remove(book);
                    return Ok();
                });
                return actionResult;
                
            }
            else return NotFound();
        }
    }
}
