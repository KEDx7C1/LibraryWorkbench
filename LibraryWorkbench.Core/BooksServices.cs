using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                book.Author=author;
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
            Book book = books.Get(id);
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
            Book bookToUpdate = context.Books.Where(x => x.Name.Equals(book.Name)).FirstOrDefault();
            var genresOld = bookToUpdate.Genres;
            var genresNew = book.Genres;
            genresOld.RemoveAll(g => !genresNew.Exists(gg => gg.GenreName == g.GenreName));
            
            books.Update(bookToUpdate);
            books.Save();
            return context.Books.Where(x=>x.BookId==bookToUpdate.BookId).Include(g=>g.Genres).FirstOrDefault();
        }
    }
}
