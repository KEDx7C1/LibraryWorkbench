using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWorkbench.Core.Interfaces
{
    public interface IAuthorsService : IDisposable
    {
        IEnumerable<AuthorDTO> GetAuthors();
        AuthorWithBooksDTO GetBooksByAuthor(int id);
        AuthorWithBooksDTO CreateAuthorWithBooks(AuthorWithBooksDTO authorWithBooks);
        Author CreateAuthor(AuthorDTO authorDto);
        int DeleteAuthor(AuthorDTO authorDto);
        IEnumerable<AuthorDTO> GetAuthorsByYear(int year, string order);
        IEnumerable<AuthorDTO> GetAuthorsByBookNamepart(string namePart);
    }
}
