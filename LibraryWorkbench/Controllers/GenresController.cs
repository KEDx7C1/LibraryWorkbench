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
    public class GenresController : ControllerBase
    {
        private readonly IGenresServices _genresServices;
        public GenresController(IGenresServices genresService)
        {
            _genresServices = genresService;
        }
        /// <summary>
        /// Hometask 2 7.4.1
        /// </summary>
        [HttpGet]
        public IEnumerable<DimGenreDTO> GetGenres()
        {
            return _genresServices.GetGenres();
        }
        /// <summary>
        /// Hometask 2 7.4.3
        /// </summary>
        [HttpGet]
        [Route("stat")]
        public IActionResult GetStatByGenre()
        {
            return new OkObjectResult(_genresServices.GetGenresStat());
        }
        /// <summary>
        /// Hometask 2 7.4.2
        /// </summary>
        [HttpPost]
        public void CreateGenre(DimGenreDTO genre)
        {

            _genresServices.CreateGenre(genre);
        }

    }
}
