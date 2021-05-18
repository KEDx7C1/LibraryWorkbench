using LibraryWorkbench.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWorkbench.Core.Interfaces
{
    public interface IPersonsService
    {
        PersonDTO CreatePerson(PersonDTO personDto);
        PersonDTO UpdatePerson(PersonDTO personDto);
        int DeletePersonById(int id);
        int DeletePersonsByFullName(PersonDTO personDto);
        PersonExtDTO GiveBook(int personId, int bookId);
        PersonExtDTO ReturnBook(int personId, int bookId);
        IEnumerable<BookDTO> GetPersonBooksById(int personId);
        void Dispose();
    }
}
