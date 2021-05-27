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
        private readonly IGenresRepository _genres;
        private readonly IBooksRepository _books;
        private readonly IMapper _mapper;
        public GenresServices(IGenresRepository genresRepository, IBooksRepository booksRepository, IMapper mapper)
        {
            _genres = genresRepository;
            _books = booksRepository;
            _mapper = mapper;
        }
        public IEnumerable<DimGenreDTO> GetGenres()
        {
            return _mapper.ProjectTo<DimGenreDTO>(_genres.GetAll());
        }

        public IEnumerable<GenresStatisticDTO> GetGenresStat()
        {
            IEnumerable<GenresStatisticDTO> genreStatistic = _books.GetAll().SelectMany(g => g.Genres.Select(n => n.GenreName)).GroupBy(g => g, (n, c) => new GenresStatisticDTO()
            {
                GenreName = n,
                GenreCount = c.Count()
            });
            return genreStatistic;
        }

        public void CreateGenre(DimGenreDTO genre)
        {
            if (!_genres.GetAll().Any(x => x.GenreName.Equals(genre.GenreName)))
                _genres.Create(new DimGenre() { GenreName = genre.GenreName });
            else
                throw new Exception($"Genre with name {genre.GenreName} already exist");
            _genres.Save();
        }
    }
}
