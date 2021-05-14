﻿using LibraryWorkbench.Core;
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
        private readonly DataContext _context;
        public GenresController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<DimGenre> GetGenres()
        {
            return GenresServices.GetGenres(_context);
        }
        [HttpGet]
        [Route("stat")]
        public IActionResult GetStatByGenre()
        {
            return new OkObjectResult(GenresServices.GetGenresStat(_context));
        }
        [HttpPost]
        public void CreateGenre(DimGenre genre)
        {
            GenresServices.CreateGenre(genre, _context);
        }

    }
}
