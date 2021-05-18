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
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        /// <summary>
        /// Hometask 1 2.0.4.A
        /// </summary>
        [HttpGet]
        public IEnumerable<BookDTO> GetAllBooks()
        {

            return _booksService.GetAllBooks();
        }
        ///// <summary>
        ///// Hometask 2 7.2.4
        ///// </summary>

        [HttpGet]
        [Route("byAuthor")]
        public IEnumerable<BookDTO> GetBooksByAuthor(string firstName, string lastName, string middleName)
        {

            return _booksService.GetBooksByAuthor(firstName, lastName, middleName);
        }
        ///// <summary>
        ///// Hometask 2 7.2.5
        ///// </summary>
        [HttpGet]
        [Route("byGenre/{genre}")]
        public IEnumerable<BookDTO> GetBooksByGenre(string genre)
        {
            return _booksService.GetBooksByGenre(genre);
        }
        [HttpGet]
        [Route("{id}")]
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
        /// Hometask 2 7.2.1
        /// </summary>
        [HttpPost]
        public BookDTO CreateBook(BookDTO bookDto)
        {
            return _booksService.CreateBook(bookDto);
        }
        ///// <summary>
        ///// Hometask 2 7.2.2
        ///// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBook(int id)
        {
            int SCode = _booksService.DeleteBook(id);
            if (SCode == 405)
                return StatusCode(SCode, "Книга у пользователя");
            else
                return StatusCode(SCode);
        }
        /// <summary>
        /// Hometask 2 7.2.3
        /// </summary>
        [HttpPut]
        public BookDTO ChangeGanre(BookDTO bookDto)
        {
            return _booksService.ChangeGanre(bookDto);
        }
    }
}
