using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LibraryWorkbench.Core
{
    public class PersonsServices
    {
        public static int DeletePersonById(int id, DataContext context)
        {
            PersonsRepository persons = new PersonsRepository(context);
            Person person = persons.Get(id);
            if (person != null)
            {
                persons.Delete(id);
                persons.Save();
                return StatusCodes.Status200OK;
            }
            else
                return StatusCodes.Status404NotFound;
        }

        public static int DeletePersonsByFullName(PersonShort person, DataContext context)
        {
            PersonsRepository persons = new PersonsRepository(context);
            List<Person> personsToDelete = persons.GetAll().Where(x => x.FirstName == person.FirstName
            && x.LastName == person.LastName && x.MiddleName == person.MiddleName).ToList();
            if (personsToDelete != null && personsToDelete.Any())
            {
                foreach (var p in personsToDelete)
                    persons.Delete(p.PersonId);
                persons.Save();
                return StatusCodes.Status200OK;
            }
            else
                return StatusCodes.Status404NotFound;
        }
        public static void GiveBook(int personId, int bookId, DataContext context)
        {
            BooksRepository books = new BooksRepository(context);
            Book book = books.Get(bookId);

            PersonsRepository persons = new PersonsRepository(context);
            Person person = persons.Get(personId);

            person.Books.Add(book);
            persons.Update(person);
            persons.Save();
        }
        public static void ReturnBook(int personId, int bookId, DataContext context)
        {
            BooksRepository books = new BooksRepository(context);
            Book book = books.Get(bookId);

            PersonsRepository persons = new PersonsRepository(context);
            Person person = persons.Get(personId);

            person.Books.Remove(book);
            persons.Update(person);
            persons.Save();
        }
    }
}
