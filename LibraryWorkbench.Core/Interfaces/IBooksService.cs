using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWorkbench.Core.Interfaces
{
    public interface IBooksService
    {
        BookDto CreateBook(BookDto bookDto);
        BookDto GetBook(int id);
        IEnumerable<BookDto> GetAllBooks();
        int DeleteBook(int id);
        BookDto ChangeGanre(BookDto bookDto);
        IEnumerable<BookDto> GetBooksByAuthor(string firstName, string lastName, string middleName);
        IEnumerable<BookDto> GetBooksByGenre(string genre);
    }
}
