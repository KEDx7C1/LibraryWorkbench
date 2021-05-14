using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWorkbench.Core
{
    public class BooksServices
    {
        public static void CreateBook(Book book, DataContext context)
        {
            Author author = context.Authors.Where(x => x.FirstName.Equals(book.Author.FirstName)
                && x.LastName.Equals(book.Author.LastName))
                .FirstOrDefault();
            if (author != null)
                book.Author = author;
            List<DimGenre> genres = new List<DimGenre>();
            foreach (var g in book.Genres)
            {
                var genre = context.DimGenres.Where(x => x.GenreName.Equals(g.GenreName)).FirstOrDefault();
                if (genre != null)
                {
                    genres.Add(genre);
                }
                else
                    genres.Add(g);
            }
            book.Genres = genres;
            BooksRepository books = new BooksRepository(context);
            books.Create(book);
            books.Save();
        }

        public static Book GetBook(int id, DataContext context)
        {
            BooksRepository books = new BooksRepository(context);
            var book = books.Get(id);

            return book;
        }
        public static int DeleteBook(int id, DataContext context)
        {
            BooksRepository books = new BooksRepository(context);
            Book book;
            try
            {
                book = books.Get(id);
            }
            catch
            {
                return StatusCodes.Status404NotFound;
            }

            if (!context.Persons.Any(x => x.Books.Contains(book)))
            {
                books.Delete(id);
                books.Save();
                return StatusCodes.Status200OK;
            }
            else
                return StatusCodes.Status400BadRequest;
        }
        public static Book ChangeGanre(Book book, DataContext context)
        {
            BooksRepository books = new BooksRepository(context);
            Book bookToUpdate = context.Books.Where(x => x.Name.ToLower().Equals(book.Name.ToLower()) && x.Author.FirstName.Equals(book.Author.FirstName)
                && x.Author.MiddleName.Equals(book.Author.MiddleName)).Include(x => x.Genres).FirstOrDefault();

            bookToUpdate.Genres.RemoveAll(g => !book.Genres.Exists(gg => gg.GenreName.ToLower().Equals(g.GenreName.ToLower())));
            bookToUpdate.Genres.AddRange(book.Genres.Where(x => !bookToUpdate.Genres.Any(y => y.GenreName.ToLower().Equals(x.GenreName.ToLower()))));

            books.Update(bookToUpdate);
            books.Save();
            return context.Books.Where(x => x.BookId == bookToUpdate.BookId).Include(g => g.Genres).Include(a => a.Author).FirstOrDefault();
        }
        public static IEnumerable<Book> GetBooksByAuthor(string firstName, string lastName, string middleName, DataContext context)
        {
            return context.Books.Where(x => (x.Author.FirstName.Equals(firstName) || firstName == null) &&
                (x.Author.LastName.Equals(lastName) || lastName == null) &&
                (x.Author.MiddleName.Equals(middleName) || middleName == null));
        }

        public static IEnumerable<Book> GetBooksByGenre(string genre, DataContext context)
        {
            return context.Books.Include(x => x.Author).Include(x => x.Genres).Where(x => x.Genres.Any(y => y.GenreName.Equals(genre)));
        }
    }
}
