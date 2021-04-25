using LibraryWorkbench.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWorkbench.Data
{
    /// <summary>
    /// 2.0
    /// </summary>
    public class BooksRepository : IBooksRepository
    {
        public List<IBook> GetAllBooks()
        {
            return Data.Books;
        }

        public async Task<List<IBook>> GetAllBooksAsync()
        {
            return await Task.Run(() => GetAllBooks());
        }

        public List<IBook> GetBooksByAuthor(string author)
        {
            return Data.Books.Where(x => x.Author.ToLower().Contains(author.ToLower()))
                .Select(x => x).ToList();
        }

        public async Task<List<IBook>> GetBooksByAuthorAsync(string author)
        {
            return await Task.Run(() => GetBooksByAuthor(author));
        }

        public IBook GetBookByAuthorAndTitle(string author, string title)
        {
            return Data.Books.Find(x => x.Author.Contains(author) && x.Title.Contains(title));
        }

        public async Task<IBook> GetBookByAuthorAndTitleAsync(string author, string title)
        {
            return await Task.Run(() => GetBookByAuthorAndTitle(author, title));
        }

        public void AddBook(IBook book)
        {
            Data.Books.Add(book);
        }

        public async Task AddBookAsync(IBook book)
        {
            await Task.Run(() => AddBook(book));
        }

        public void RemoveBook(IBook book)
        {
            Data.Books.RemoveAll(x => x.Title == book.Title && x.Author == book.Author);
        }

        public async Task RemoveBookAsync(IBook book)
        {
            await Task.Run(() => RemoveBook(book));
        }
    }
}
