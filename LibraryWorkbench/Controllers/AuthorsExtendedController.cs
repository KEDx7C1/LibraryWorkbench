using LibraryWorkbench.Core;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
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
        private readonly IAuthorsService _authorsService;

        public AuthorsExtendedController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }
        /// <summary>
        /// Get books by year (Hometask 2 8.2)
        /// </summary>
        [HttpGet("ByYear/{year}")]
        public IEnumerable<AuthorDto> GetAuthorsByYear(int year, string order = "")
        {
            return _authorsService.GetAuthorsByYear(year, order);
        }
        /// <summary>
        /// Get book by name (Hometask 2 8.3)
        /// </summary>
        [HttpGet("ByBookName/{namePart}")]
        public IEnumerable<AuthorDto> GetAuthorsByBookNamepart(string namePart)
        {
            return _authorsService.GetAuthorsByBookNamepart(namePart);
        }
    }
}
