using LibraryWorkbench.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWorkbench.Data
{
    /// <summary>
    /// Hometask 2 6
    /// </summary>
    public class GenresRepository : IGenresRepository
    {
        private readonly DataContext _context;

        public GenresRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<DimGenre> GetAll()
        {
            return _context.DimGenres;
        }
        public DimGenre Get(int id)
        {
            var genre = _context.DimGenres.Where(x=>x.GenreId == id).FirstOrDefault();
            if (genre == null)
            {
                throw new Exception($"Genre with Id {id} not found");
            }
            return genre;
        }
        public void Create(DimGenre genre)
        {
            genre.CreationDateTime = DateTimeOffset.Now;
            genre.UpdationDateTime = DateTimeOffset.Now;
            genre.Version = 1;
            _context.DimGenres.Add(genre);
        }
        public void Update(DimGenre genre)
        {

            genre.UpdationDateTime = DateTimeOffset.Now;
            genre.Version++;
            _context.Entry(genre).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            DimGenre genre = _context.DimGenres.Where(x=>x.GenreId == id).FirstOrDefault();
            if (genre == null)
                throw new Exception($"Genre with Id {id} not found");
            _context.DimGenres.Remove(genre);

        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
