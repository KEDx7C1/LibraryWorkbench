using LibraryWorkbench.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWorkbench.Core.Interfaces
{
    public interface IPersonsService
    {
        IEnumerable<PersonDto> GetAllPersons();
        PersonDto CreatePerson(PersonDto personDto);
        PersonDto UpdatePerson(PersonDto personDto);
        int DeletePersonById(int id);
        int DeletePersonsByFullName(PersonDto personDto);
        PersonExtDto GiveBook(int personId, int bookId);
        PersonExtDto ReturnBook(int personId, int bookId);
        IEnumerable<BookDto> GetPersonBooksById(int personId);
    }
}
