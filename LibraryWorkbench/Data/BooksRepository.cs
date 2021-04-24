using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWorkbench.DTO;
using LibraryWorkbench.Interfaces;

namespace LibraryWorkbench.Data
{
    /// <summary>
    /// 2.0
    /// </summary>
    public class BooksRepository : IBooksRepository
    {
        public List<BookDTO> Get()
        {
            return Data.Books;
        }

        public List<BookDTO> GetByAuthor(string author)
        {
            return Data.Books.Where(x => x.Author.ToLower().Contains(author.ToLower()))
                .Select(x => x).ToList();
        }

        public BookDTO GetByAuthorAndTitle(string author, string title)
        {
            return Data.Books.Find(x => x.Author.Contains(author) && x.Title.Contains(title));
        }

        public void Add(BookDTO book)
        {
            Data.Books.Add(book);
        }

        public void Remove(BookDTO book)
        {
            Data.Books.RemoveAll(x=> x == book);
        }
    }
}
