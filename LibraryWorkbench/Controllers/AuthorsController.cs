using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using LibraryWorkbench.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWorkbench.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly DataContext _context;
        public AuthorsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Author> GetAuthors()
        {
            return  AuthorsServices.GetAuthors(_context);
        }
        [HttpGet]
        [Route("books")]
        public IEnumerable<Book> GetBooksByAuthor(string firstName, string lastName, string middleName)
        {
            return AuthorsServices.GetBooksByAuthor(firstName, lastName, middleName, _context);
        }
        
    }
}
