using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LibraryWorkbench.Data.Intefaces;

namespace LibraryWorkbench.Core
{
    public class GenresServices : IGenresServices
    {
        private readonly DataContext _context;
        private readonly IGenresRepository _genres;
        private readonly IMapper _mapperGenre;
        public GenresServices(DataContext context)
        {
            _context = context;
            _genres = new GenresRepository(_context);
            _mapperGenre = new MapperConfiguration(c => c.CreateMap<DimGenre, DimGenreDTO>()).CreateMapper();
        }
        public IEnumerable<DimGenreDTO> GetGenres()
        {
            return _mapperGenre.Map<IEnumerable<DimGenreDTO>>(_genres.GetAll());
        }

        public Object GetGenresStat()
        {
            IBooksRepository books = new BooksRepository(_context);
            var result = books.GetAll().SelectMany(g => g.Genres.Select(n => n.GenreName)).GroupBy(g => g, (n, c) => new
            {
                genreName = n,
                genreCount = c.Count()
            });
            return result;
        }

        public void CreateGenre(DimGenreDTO genre)
        {
            if (!_genres.GetAll().Any(x => x.GenreName.Equals(genre.GenreName)))
                _genres.Create(new DimGenre() { GenreName = genre.GenreName});
            _genres.Save();
        }
    }
}
