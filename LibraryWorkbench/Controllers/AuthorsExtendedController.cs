using LibraryWorkbench.Core;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryWorkbench.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsExtendedController : ControllerBase
    {
        private readonly DataContext _context;
        public AuthorsExtendedController(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Hometask 2 8.2
        /// </summary>
        [HttpGet]
        [Route("ByYear/{year}")]
        public IEnumerable<Author> GetAuthorsByYear(int year, string order = "")
        {
            return AuthorsService.GetAuthorsByYear(year, order, _context);
        }
        /// <summary>
        /// Hometask 2 8.3
        /// </summary>
        [Route("ByBookName/{namePart}")]
        public IEnumerable<Author> GetAuthorsByBookNamepart(string namePart)
        {
            return AuthorsService.GetAuthorsByBookNamepart(namePart, _context);
        }
    }
}
