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
        [HttpGet]
        [Route("ByYear/{year}")]
        public IEnumerable<Author> GetAuthorsByYear(int year, string order = "")
        {
            return AuthorsServices.GetAuthorsByYear(year, order, _context);
        }
        [Route("ByBookName/{namePart}")]
        public IEnumerable<Author> GetAuthorsByBookNamepart(string namePart)
        {
            return AuthorsServices.GetAuthorsByBookNamepart(namePart, _context);
        }
    }
}
