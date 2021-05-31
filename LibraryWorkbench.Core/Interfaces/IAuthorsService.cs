using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWorkbench.Core.Interfaces
{
    public interface IAuthorsService
    {
        IEnumerable<AuthorDto> GetAuthors();
        AuthorWithBooksDto GetBooksByAuthor(int id);
        AuthorWithBooksDto CreateAuthorWithBooks(AuthorWithBooksDto authorWithBooks);
        AuthorDto CreateAuthor(AuthorDto authorDto);
        void DeleteAuthor(int authorId);
        IEnumerable<AuthorDto> GetAuthorsByYear(int year, string order);
        IEnumerable<AuthorDto> GetAuthorsByBookNamepart(string namePart);
    }
}
