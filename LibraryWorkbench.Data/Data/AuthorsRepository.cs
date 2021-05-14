using LibraryWorkbench.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

        public IEnumerable<Author> GetAuthorByYear(int year, string order)
        {
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Author> authors = new List<Author>();
                connection.Open();
                string query = ("SELECT book.AuthorId, author.first_name AS FirstName," +
                    " author.last_name AS LastName, author.middle_name AS MiddleName FROM dbo.book" +
                    " INNER JOIN author ON book.AuthorId = author.author_id WHERE Year = @year" +
                    " GROUP BY book.AuthorId, first_name, last_name, middle_name ORDER BY last_name " + order);
                SqlCommand command = new SqlCommand(query, connection);
                SqlParameter yearParam = new SqlParameter("@year", year);
                command.Parameters.Add(yearParam);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    authors.Add(new Author()
                    {
                        AuthorId = (int)reader["AuthorId"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        MiddleName = reader["MiddleName"].ToString()
                    });
                }
                connection.Close();
                return authors;
            }
        }
        public IEnumerable<Author> GetAuthorsByBookNamepart(string namePart)
        {
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Author> authors = new List<Author>();
                connection.Open();
                string query = ("SELECT book.AuthorId, author.first_name AS FirstName," +
                    " author.last_name AS LastName, author.middle_name AS MiddleName FROM dbo.book" +
                    " INNER JOIN author ON book.AuthorId = author.author_id WHERE name LIKE N'%" + namePart + "%'");
                SqlCommand command = new SqlCommand(query, connection);
                SqlParameter nameParam = new SqlParameter("@namePart", namePart);
                command.Parameters.Add(nameParam);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    authors.Add(new Author()
                    {
                        AuthorId = (int)reader["AuthorId"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        MiddleName = reader["MiddleName"].ToString()
                    });
                }
                connection.Close();
                return authors;
            }
        }



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
