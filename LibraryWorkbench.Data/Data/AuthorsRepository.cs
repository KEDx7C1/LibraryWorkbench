using LibraryWorkbench.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWorkbench.Data
{
    /// <summary>
    /// 2.0
    /// </summary>
    public class AuthorsRepository : IRepository<Author>
    {
        private readonly DataContext _context;

        public AuthorsRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors;
        }
        public Author Get(int id)
        {
            return _context.Authors.Find(id);
        }
        public void Create(Author author)
        {
            author.CreationDateTime = DateTimeOffset.Now;
            author.Version = 1;
            _context.Authors.Add(author);
        }
        public void Update(Author author)
        {
            author.UpdationDateTime = DateTimeOffset.Now;
            author.Version++;
            _context.Entry(author).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Author author = _context.Authors.Find(id);
            if (author != null)
                _context.Authors.Remove(author);
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
