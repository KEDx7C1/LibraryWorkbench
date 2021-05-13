using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
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

        public static IEnumerable<Book> GetBooksByAuthor(string firstName, string lastName, string middleName, DataContext context)
        {
            return context.Books.Include(x=>x.Author).Include(x=>x.Genres).Where(x => (x.Author.FirstName.Equals(firstName) || firstName == null) &&
                (x.Author.LastName.Equals(lastName) || lastName == null) &&
                (x.Author.MiddleName.Equals(middleName) || middleName == null));
        }
    }
}
