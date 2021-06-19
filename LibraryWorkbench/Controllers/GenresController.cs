using System.Collections.Generic;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWorkbench.Controllers
{
    /// <summary>
    ///     Genre API
    /// </summary>
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
        ///     Get all genres (Hometask 2 7.4.1)
        /// </summary>
        [HttpGet]
        public IEnumerable<DimGenreDto> GetGenres()
        {
            return _genresServices.GetAllGenres();
        }

        /// <summary>
        ///     Get book's genres statistic (Hometask 2 7.4.3)
        /// </summary>
        [HttpGet("stat")]
        public IActionResult GetStatByGenre()
        {
            return new OkObjectResult(_genresServices.GetGenresStat());
        }

        /// <summary>
        ///     Create new genre (Hometask 2 7.4.2)
        /// </summary>
        /// <param name="genre">DimGenreDto</param>
        [HttpPost]
        public void CreateGenre(DimGenreDto genre)
        {
            _genresServices.CreateGenre(genre);
        }
    }
}