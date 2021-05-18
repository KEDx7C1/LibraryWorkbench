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
        AuthorWithBooksDTO GetBooksByAuthor(AuthorDTO authorDto);
        AuthorWithBooksDTO CreateAuthorWithBooks(AuthorWithBooksDTO authorWithBooks);
        Author CreateAuthor(AuthorDTO authorDto);
        int DeleteAuthor(AuthorDTO authorDto);
        IQueryable<AuthorDTO> GetAuthorsByYear(int year, string order);
        IQueryable<AuthorDTO> GetAuthorsByBookNamepart(string namePart);
    }
}
