using System.Linq;
using LibraryWorkbench.Core.DTO;

namespace LibraryWorkbench.Core.Interfaces
{
    public interface IPersonsService
    {
        IQueryable<PersonDto> GetAllPersons();
        PersonDto CreatePerson(PersonDto personDto);
        PersonDto UpdatePerson(PersonDto personDto);
        void DeletePersonById(int id);
        void DeletePersonsByFullName(PersonDto personDto);
        PersonExtDto GiveBook(int personId, int bookId);
        PersonExtDto ReturnBook(int personId, int bookId);
        IQueryable<BookDto> GetPersonBooksById(int personId);
    }
}