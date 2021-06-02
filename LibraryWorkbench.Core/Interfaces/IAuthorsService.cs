using LibraryWorkbench.Core.DTO;
using System.Linq;

namespace LibraryWorkbench.Core.Interfaces
{
    public interface IAuthorsService
    {
        IQueryable<AuthorDto> GetAllAuthors();
        AuthorWithBooksDto GetBooksByAuthor(int id);
        AuthorWithBooksDto CreateAuthorWithBooks(AuthorWithBooksDto authorWithBooks);
        AuthorDto CreateAuthor(AuthorDto authorDto);
        void DeleteAuthor(int authorId);
        IQueryable<AuthorDto> GetAuthorsByYear(int year, bool isOrderByDesc);
        IQueryable<AuthorDto> GetAuthorsByBookNamepart(string namePart);
    }
}
