using System.Collections.Generic;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWorkbench.Controllers
{
    /// <summary>
    ///     Author extended API
    /// </summary>
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
        ///     Get books by year (Hometask 2 8.2)
        /// </summary>
        [HttpGet("ByYear/{year}")]
        public IEnumerable<AuthorDto> GetAuthorsByYear(int year, bool isOrderByDesc = false)
        {
            return _authorsService.GetAuthorsByYear(year, isOrderByDesc);
        }

        /// <summary>
        ///     Get book by part of the name (Hometask 2 8.3)
        /// </summary>
        [HttpGet("ByBookName/{namePart}")]
        public IEnumerable<AuthorDto> GetAuthorsByBookNamepart(string namePart)
        {
            return _authorsService.GetAuthorsByBookNamepart(namePart);
        }
    }
}