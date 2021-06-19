using System;
using System.Linq;
using AutoMapper;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Intefaces;
using LibraryWorkbench.Data.Models;

namespace LibraryWorkbench.Core.Services
{
    public class GenresServices : IGenresServices
    {
        private readonly IBooksRepository _books;
        private readonly IGenresRepository _genres;
        private readonly IMapper _mapper;

        public GenresServices(IGenresRepository genresRepository, IBooksRepository booksRepository, IMapper mapper)
        {
            _genres = genresRepository;
            _books = booksRepository;
            _mapper = mapper;
        }

        public IQueryable<DimGenreDto> GetAllGenres()
        {
            return _mapper.ProjectTo<DimGenreDto>(_genres.GetAll());
        }

        public IQueryable<GenresStatisticDto> GetGenresStat()
        {
            var genreStatisticDto = _books.GetAll()
                .SelectMany(g => g.Genres.Select(n => n.GenreName)).GroupBy(g => g, (n, c) => new GenresStatisticDto
                {
                    GenreName = n,
                    GenreCount = c.Count()
                });
            return genreStatisticDto;
        }

        public void CreateGenre(DimGenreDto genre)
        {
            if (!_genres.GetAll().Any(x => x.GenreName.Equals(genre.GenreName)))
                _genres.Create(new DimGenre {GenreName = genre.GenreName});
            else
                throw new Exception($"Genre with name {genre.GenreName} already exist");
        }
    }
}