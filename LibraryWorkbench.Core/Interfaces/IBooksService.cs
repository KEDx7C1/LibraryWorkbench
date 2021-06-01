using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryWorkbench.Core.Interfaces
{
    public interface IBooksService
    {
        BookDto CreateBook(BookDto bookDto);
        BookDto GetBook(int id);
        IQueryable<BookDto> GetAllBooks();
        void DeleteBook(int id);
        BookDto ChangeGanre(BookDto bookDto);
        IQueryable<BookDto> GetBooksByAuthor(string firstName, string lastName, string middleName);
        IQueryable<BookDto> GetBooksByGenre(string genre);
    }
}
