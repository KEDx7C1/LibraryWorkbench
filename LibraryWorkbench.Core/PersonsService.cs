using AutoMapper;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryWorkbench.Data.Intefaces;

namespace LibraryWorkbench.Core
{
    public class PersonsService : IPersonsService
    {
        private readonly DataContext _context;
        private readonly IPersonsRepository _persons;
        private readonly IBooksRepository _books;
        private readonly IMapper _mapperPerson;
        private readonly IMapper _mapperBook;
        private readonly IMapper _mapperPersonExt;
        public PersonsService(DataContext context)
        {
            _context = context;
            _persons = new PersonsRepository(_context);
            _books = new BooksRepository(_context);
            _mapperPerson = new MapperConfiguration(c => c.CreateMap<Person, PersonDTO>()).CreateMapper();
            _mapperBook = new MapperConfiguration(c =>
            {
                c.CreateMap<Book, BookDTO>();
                c.CreateMap<Author, AuthorDTO>();
                c.CreateMap<DimGenre, DimGenreDTO>();
            }).CreateMapper();
            _mapperPersonExt = new MapperConfiguration(c =>
            {
                c.CreateMap<Person, PersonExtDTO>();
                c.CreateMap<Book, BookDTO>();
                c.CreateMap<Author, AuthorDTO>();
                c.CreateMap<DimGenre, DimGenreDTO>();
            }).CreateMapper();
        }
        public PersonDTO CreatePerson(PersonDTO personDto)
        {
            if (!_context.Persons.Any(x => x.FirstName.Equals(personDto.FirstName) && x.LastName.Equals(personDto.LastName)
            && x.MiddleName.Equals(personDto.MiddleName) && x.Birthday.Equals(personDto.Birthday)))
            {
                PersonsRepository persons = new PersonsRepository(_context);
                Person person = new Person
                {
                    FirstName = personDto.FirstName,
                    LastName = personDto.LastName,
                    MiddleName = personDto.MiddleName,
                    Birthday = personDto.Birthday
                };
                persons.Create(person);
                persons.Save();
               
                return _mapperPerson.Map<PersonDTO>(persons.Get(person.PersonId));
            }
            else
                return null;
        }
        public PersonDTO UpdatePerson (PersonDTO personDto)
        {
            Person person = _persons.Get(personDto.PersonId);
            person.FirstName = personDto.FirstName;
            person.LastName = personDto.LastName;
            person.MiddleName = personDto.MiddleName;
            person.Birthday = personDto.Birthday;
            _persons.Update(person);
            _persons.Save();
            return _mapperPerson.Map<PersonDTO>(person);
        }
        public int DeletePersonById(int id)
        {
            try
            {
                _persons.Delete(id);
                _persons.Save();
                return StatusCodes.Status200OK;
            }
            catch
            {
                return StatusCodes.Status404NotFound;
            }
        }
        public int DeletePersonsByFullName(PersonDTO personDto)
        {
            List<Person> personsToDelete = _persons.GetAll().Where(x => x.FirstName == personDto.FirstName
            && x.LastName == personDto.LastName && x.MiddleName == personDto.MiddleName).ToList();
            if (personsToDelete != null && personsToDelete.Any())
            {
                foreach (var p in personsToDelete)
                    _persons.Delete(p.PersonId);
                _persons.Save();
                return StatusCodes.Status200OK;
            }
            else
                return StatusCodes.Status404NotFound;
        }
        public PersonExtDTO GiveBook(int personId, int bookId)
        {
            Book book = _books.Get(bookId);
            Person person = _persons.Get(personId);

            person.Books.Add(book);
            _persons.Update(person);
            _persons.Save();
            
            return _mapperPersonExt.Map<PersonExtDTO>(_persons.GetWithBooks(person.PersonId));
        }
        public PersonExtDTO ReturnBook(int personId, int bookId)
        {
            Book book = _books.Get(bookId);

            Person person = _persons.Get(personId);

            person.Books.Remove(book);
            _persons.Update(person);
            _persons.Save();

            return _mapperPersonExt.Map<PersonExtDTO>(_persons.GetWithBooks(person.PersonId));
        }
        public IEnumerable<BookDTO> GetPersonBooksById (int personId)
        {
            var bookDtos = _mapperBook.Map<IEnumerable<BookDTO>>(_persons.Get(personId).Books);
            return bookDtos;
        }
        public void Dispose()
        {
            _persons.Dispose();
        }
    }
}
