using LibraryWorkbench.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWorkbench.Data
{
    /// <summary>
    /// 2.0
    /// </summary>
    public class BooksRepository : IRepository<Book>
    {
        private readonly DataContext _context;

        public BooksRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }
        public Book Get(int id)
        {

            return _context.Books.Include(b => b.Author).Include(a => a.Genres).Where(x => x.BookId == id).First();
        }
        public void Create(Book book)
        {
            book.CreationDateTime = DateTimeOffset.Now;
            book.Version = 1;
            _context.Books.Add(book);
        }
        public void Update(Book book)
        {
            book.UpdationDateTime = DateTimeOffset.Now;
            book.Version++;
            _context.Entry(book).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Book book = _context.Books.Find(id);
            if (book != null)
                _context.Books.Remove(book);
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
