using System;
using System.Linq;
using LibraryWorkbench.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWorkbench.Data
{
    /// <summary>
    ///     Hometask 2 6
    /// </summary>
    public class GenresRepository : IGenresRepository
    {
        private readonly DataContext _context;

        public GenresRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<DimGenre> GetAll()
        {
            IQueryable<DimGenre> genres = _context.DimGenres;
            return genres;
        }

        public DimGenre Get(int id)
        {
            var genre = _context.DimGenres.FirstOrDefault(x => x.GenreId == id);
            if (genre == null) throw new Exception($"Genre with Id {id} not found");
            return genre;
        }

        public DimGenre Create(DimGenre genre)
        {
            genre.CreationDateTime = DateTimeOffset.Now;
            genre.UpdationDateTime = DateTimeOffset.Now;
            _context.DimGenres.Add(genre);
            _context.SaveChanges();
            return genre;
        }

        public DimGenre Update(DimGenre genre)
        {
            genre.UpdationDateTime = DateTimeOffset.Now;
            _context.Entry(genre).State = EntityState.Modified;
            _context.SaveChanges();
            return genre;
        }

        public void Delete(int id)
        {
            var genre = _context.DimGenres.FirstOrDefault(x => x.GenreId == id);
            if (genre == null)
                throw new Exception($"Genre with Id {id} not found");
            _context.DimGenres.Remove(genre);
            _context.SaveChanges();
        }
    }
}