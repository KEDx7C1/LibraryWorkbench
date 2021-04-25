using System.Collections.Generic;
using System.Threading.Tasks;


namespace LibraryWorkbench.Interfaces
{
    /// <summary>
    /// 2.0
    /// </summary>
    interface IBooksRepository
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
