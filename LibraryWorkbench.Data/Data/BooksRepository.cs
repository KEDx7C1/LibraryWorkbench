using System;
using System.Linq;
using LibraryWorkbench.Data.Intefaces;
using LibraryWorkbench.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWorkbench.Data
{
    /// <summary>
    ///     Hometask 2 6
    /// </summary>
    public class BooksRepository : IBooksRepository
    {
        private readonly DataContext _context;

        public BooksRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<Book> GetAll()
        {
            return _context.Books.Include(x => x.Author).Include(x => x.Genres);
        }

        public Book Get(int id)
        {
            var book = _context.Books.Include(b => b.Author).Include(a => a.Genres).FirstOrDefault(x => x.BookId == id);
            if (book == null)
                throw new Exception($"Book with Id {id} not found");
            return book;
        }

        public Book Create(Book book)
        {
            book.CreationDateTime = DateTimeOffset.Now;
            book.UpdationDateTime = book.CreationDateTime;
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book Update(Book book)
        {
            book.UpdationDateTime = DateTimeOffset.Now;
            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();
            return book;
        }

        public void Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.BookId == id);
            if (book == null)
                throw new Exception($"Book with Id {id} not found");
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}