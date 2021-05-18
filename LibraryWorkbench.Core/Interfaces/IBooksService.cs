using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWorkbench.Core.Interfaces
{
    public interface IBooksService
    {
        BookDTO CreateBook(BookDTO bookDto);
        BookDTO GetBook(int id);
        IEnumerable<BookDTO> GetAllBooks();
        int DeleteBook(int id);
        BookDTO ChangeGanre(BookDTO bookDto);
        IEnumerable<BookDTO> GetBooksByAuthor(string firstName, string lastName, string middleName);
        IEnumerable<BookDTO> GetBooksByGenre(string genre);
    }
}
