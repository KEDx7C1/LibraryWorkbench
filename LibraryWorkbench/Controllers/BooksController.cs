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
        /// 2.0.4.A
        /// </summary>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            
            return _books.GetAll();
        }
        ///// <summary>
        ///// 2.0.4.B
        ///// </summary>
        //[Route("{author}")]
        //[HttpGet]
        //public async Task<IEnumerable<IBook>> GetByAuthor(string author)
        //{
        //    List<IBook> books = await _books.GetBooksByAuthorAsync(author);
        //    return books;
        //}
        ///// <summary>
        ///// 2.0.5, 2.2.2.A
        ///// </summary>
        [HttpGet]
        [Route("{id}")]
        public Book GetBookById(int id)
        {
            return BooksServices.GetBook(id, _context);
        }
        [HttpPost]
        public void CreateBook(Book book)
        {
            BooksServices.CreateBook(book, _context);
        }
        ///// <summary>
        ///// 2.0.6
        ///// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBook(int id)
        {
            
            return StatusCode(BooksServices.DeleteBook(id, _context));
        }

        [HttpPut]
        public Book ChangeGanre (Book book)
        {
            
            return BooksServices.ChangeGanre(book, _context);
        }
    }
}
