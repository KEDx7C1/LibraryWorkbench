using LibraryWorkbench.Data.Intefaces;
using LibraryWorkbench.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWorkbench.Data
{
    /// <summary>
    /// Hometask 2 6
    /// </summary>
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly DataContext _context;

        public AuthorsRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<Author> GetAll()
        {
            return _context.Authors;
        }
        public Author Get(int id)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.AuthorId == id);
            if (author == null)
                throw new Exception($"Author with Id {id} not found");
            return author;
        }
        public Author Create(Author author)
        {
            author.CreationDateTime = DateTimeOffset.Now;
            author.UpdationDateTime = author.CreationDateTime;
            author.Version = 1;
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }
        public Author Update(Author author)
        {
            author.UpdationDateTime = DateTimeOffset.Now;
            author.Version++;
            _context.Entry(author).State = EntityState.Modified;
            _context.SaveChanges();
            return author;
        }
        public void Delete(int id)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.AuthorId == id);
            if (author == null)
                throw new Exception($"Author with Id {id} not found");
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
