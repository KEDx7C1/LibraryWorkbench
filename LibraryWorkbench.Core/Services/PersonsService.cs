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

namespace LibraryWorkbench.Core.Services
{
    public class PersonsService : IPersonsService
    {
        private readonly IPersonsRepository _persons;
        private readonly IBooksRepository _books;
        private readonly IMapper _mapper;
        public PersonsService(IPersonsRepository personsRepository, IBooksRepository booksRepository, IMapper mapper)
        {
            _persons = personsRepository;
            _books = booksRepository;
            _mapper = mapper;
        }
        public IEnumerable<PersonDTO> GetAllPersons()
        {
            return _mapper.Map<IEnumerable<PersonDTO>>(_persons.GetAll());
        }
        public PersonDTO CreatePerson(PersonDTO personDto)
        {
            if (!_persons.GetAll().Any(x => x.FirstName.Equals(personDto.FirstName) && x.LastName.Equals(personDto.LastName)
            && x.MiddleName.Equals(personDto.MiddleName) && x.Birthday.Equals(personDto.Birthday)))
            {
                Person person = new Person
                {
                    FirstName = personDto.FirstName,
                    LastName = personDto.LastName,
                    MiddleName = personDto.MiddleName,
                    Birthday = personDto.Birthday
                };
                _persons.Create(person);
                _persons.Save();
               
                return _mapper.Map<PersonDTO>(_persons.Get(person.PersonId));
            }
            else
                throw new Exception($"Person {personDto.FirstName} {personDto.LastName} {personDto.MiddleName} birth {personDto.Birthday} already exist");
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
            return _mapper.Map<PersonDTO>(person);
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
            
            return _mapper.Map<PersonExtDTO>(_persons.GetWithBooks(person.PersonId));
        }
        public PersonExtDTO ReturnBook(int personId, int bookId)
        {
            Book book = _books.Get(bookId);
            Person person = _persons.Get(personId);

            person.Books.Remove(book);
            _persons.Update(person);
            _persons.Save();

            return _mapper.Map<PersonExtDTO>(_persons.GetWithBooks(person.PersonId));
        }
        public IEnumerable<BookDTO> GetPersonBooksById (int personId)
        {
            var bookDtos = _mapper.Map<IEnumerable<BookDTO>>(_persons.Get(personId).Books);
            return bookDtos;
        }
        public void Dispose()
        {
            _persons.Dispose();
        }
    }
}
