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
        /// Hometask 2 8.2
        /// </summary>
        [HttpGet("ByYear/{year}")]
        //[Route("ByYear/{year}")]
        public IEnumerable<AuthorDTO> GetAuthorsByYear(int year, string order = "")
        {
            return _authorsService.GetAuthorsByYear(year, order);
        }
        /// <summary>
        /// Hometask 2 8.3
        /// </summary>
        [HttpGet("ByBookName/{namePart}")]
        //[Route("ByBookName/{namePart}")]
        public IEnumerable<AuthorDTO> GetAuthorsByBookNamepart(string namePart)
        {
            return _authorsService.GetAuthorsByBookNamepart(namePart);
        }
    }
}
