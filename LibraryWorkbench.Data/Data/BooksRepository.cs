using LibraryWorkbench.Data.Data.Interfaces;
using LibraryWorkbench.Data.Models.Interfaces;
using LibraryWorkbench.DataTables;
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
            return DataTables.DataTables.Books;
        }

        public async Task<List<IBook>> GetAllBooksAsync()
        {
            return await Task.Run(() => GetAllBooks());
        }

        public List<IBook> GetBooksByAuthor(string author)
        {
            return DataTables.DataTables.Books.Where(x => x.Author.ToLower().Contains(author.ToLower())).ToList();
        }

        public async Task<List<IBook>> GetBooksByAuthorAsync(string author)
        {
            return await Task.Run(() => GetBooksByAuthor(author));
        }

        public IBook GetBookByAuthorAndTitle(string author, string title)
        {
            return DataTables.DataTables.Books.Find(x => x.Author ==author && x.Title == title);
        }

        public async Task<IBook> GetBookByAuthorAndTitleAsync(string author, string title)
        {
            return await Task.Run(() => GetBookByAuthorAndTitle(author, title));
        }

        public void AddBook(IBook book)
        {
            DataTables.DataTables.Books.Add(book);
        }

        public async Task AddBookAsync(IBook book)
        {
            await Task.Run(() => AddBook(book));
        }

        public void RemoveBook(IBook book)
        {
            DataTables.DataTables.Books.RemoveAll(x => x.Title == book.Title && x.Author == book.Author);
        }

        public async Task RemoveBookAsync(IBook book)
        {
            await Task.Run(() => RemoveBook(book));
        }
    }
}
