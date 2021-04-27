using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryWorkbench.Data.Models.Interfaces;


namespace LibraryWorkbench.Data.Data.Interfaces
{
    /// <summary>
    /// 2.0
    /// </summary>
    public interface IBooksRepository
    {
        List<IBook> GetAllBooks();
        Task<List<IBook>> GetAllBooksAsync();
        List<IBook> GetBooksByAuthor(string author);
        Task<List<IBook>> GetBooksByAuthorAsync(string author);
        void AddBook(IBook book);
        Task AddBookAsync(IBook book);
        IBook GetBookByAuthorAndTitle(string author, string title);
        Task<IBook> GetBookByAuthorAndTitleAsync(string author, string title);
        void RemoveBook(IBook book);
        Task RemoveBookAsync(IBook book);
    }
}
