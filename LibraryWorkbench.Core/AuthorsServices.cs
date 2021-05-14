using LibraryWorkbench.Core.Models;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryWorkbench.Core
{
    public class AuthorsServices
    {
        public static IEnumerable<Author> GetAuthors(DataContext context)
        {
            return context.Authors;
        }

        public static Object GetBooksByAuthor(string firstName, string lastName, string middleName, DataContext context)
        {
            try
            {
                Author author = context.Authors.Where(x => (x.FirstName.Equals(firstName) || firstName == null) &&
                    (x.LastName.Equals(lastName) || lastName == null) &&
                    (x.MiddleName.Equals(middleName) || middleName == null)).First();
                Object result = new
                {
                    author,
                    books = context.Books.Include(x => x.Genres).Where(x => x.Author == author)
                };
                return result;
            }
            
            catch
            {
                throw new ArgumentException();
            }
        }
        public static AuthorWithBooks CreateAuthorWithBooks(AuthorWithBooks authorWithBooks, DataContext context)
        {
            Author author = authorWithBooks.Author;
            List<Book> books = authorWithBooks.Books;
            try
            {
                CreateAuthor(author, context);
                if (books != null)
                    foreach (var b in books)
                    {
                        BooksServices.CreateBook(b, context);
                    }
                return authorWithBooks;
            }
            catch
            {
                return null;
            }
        }
        private static void CreateAuthor(Author author, DataContext context)
        {
            
            AuthorsRepository authors = new AuthorsRepository(context);
            if (!context.Authors.Any(x => x.FirstName.Equals(author.FirstName)
                && x.LastName.Equals(author.LastName) && x.MiddleName.Equals(author.MiddleName)))
            {
                authors.Create(author);
                authors.Save();
            } 
        }
        public static int DeleteAuthor(Author author, DataContext context)
        {
            Author authorToDelete = context.Authors.Where(x => x.FirstName.Equals(author.FirstName)
                && x.LastName.Equals(author.LastName) && x.MiddleName.Equals(author.MiddleName)).FirstOrDefault();
            if (authorToDelete == null)
                return StatusCodes.Status404NotFound;
            if (context.Books.Any(x => x.Author.Equals(authorToDelete)))
                return StatusCodes.Status405MethodNotAllowed;
            else
            {
                AuthorsRepository authors = new AuthorsRepository(context);
                authors.Delete(authorToDelete.AuthorId);
                authors.Save();
                return StatusCodes.Status200OK;
            }
        }
        public static IEnumerable<Author> GetAuthorsByYear(int year, string order, DataContext context)
        {
            if (order.ToLower() != "desc" && order.ToLower() != "asc")
                order = "asc";
            AuthorsRepository authors = new AuthorsRepository(context);
            return authors.GetAuthorByYear(year, order);
        }
        public static IEnumerable<Author> GetAuthorsByBookNamepart(string namePart, DataContext context)
        {
            AuthorsRepository authorsRepos = new AuthorsRepository(context);
            IEnumerable<Author> authors = authorsRepos.GetAuthorsByBookNamepart(namePart);
            return authors;
        }
    }
}
