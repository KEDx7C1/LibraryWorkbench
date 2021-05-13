using LibraryWorkbench.Data.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryWorkbench.Data
{
    /// <summary>
    /// 2.0
    /// </summary>
    public class GenresRepository : IRepository<DimGenre>
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
            return _context.DimGenres.Find(id);
        }
        public void Create(DimGenre genre)
        {
            _context.DimGenres.Add(genre);
        }
        public void Update(DimGenre genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            DimGenre genre = _context.DimGenres.Find(id);
            if (genre != null)
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
