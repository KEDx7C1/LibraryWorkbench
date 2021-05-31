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
        public IEnumerable<PersonDto> GetAllPersons()
        {
            return _mapper.Map<IEnumerable<PersonDto>>(_persons.GetAll());
        }
        public PersonDto CreatePerson(PersonDto personDto)
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
                return _mapper.Map<PersonDto>(_persons.Get(person.PersonId));
            }
            else
                throw new Exception($"Person {personDto.FirstName} {personDto.LastName} {personDto.MiddleName} birth {personDto.Birthday} already exist");
        }
        public PersonDto UpdatePerson (PersonDto personDto)
        {
            Person person = _persons.Get(personDto.PersonId);
            person.FirstName = personDto.FirstName;
            person.LastName = personDto.LastName;
            person.MiddleName = personDto.MiddleName;
            person.Birthday = personDto.Birthday;
            _persons.Update(person);
            return _mapper.Map<PersonDto>(person);
        }
        public int DeletePersonById(int id)
        {
            try
            {
                _persons.Delete(id);
                return StatusCodes.Status200OK;
            }
            catch
            {
                return StatusCodes.Status404NotFound;
            }
        }
        public int DeletePersonsByFullName(PersonDto personDto)
        {
            List<Person> personsToDelete = _persons.GetAll().Where(x => x.FirstName == personDto.FirstName
            && x.LastName == personDto.LastName && x.MiddleName == personDto.MiddleName).ToList();
            if (personsToDelete != null && personsToDelete.Any())
            {
                foreach (var p in personsToDelete)
                    _persons.Delete(p.PersonId);
                return StatusCodes.Status200OK;
            }
            else
                return StatusCodes.Status404NotFound;
        }
        public PersonExtDto GiveBook(int personId, int bookId)
        {
            Book book = _books.Get(bookId);
            Person person = _persons.Get(personId);
            
            person.Books.Add(book);
            _persons.Update(person);
            
            return _mapper.Map<PersonExtDto>(_persons.GetWithBooks(person.PersonId));
        }
        public PersonExtDto ReturnBook(int personId, int bookId)
        {
            Book book = _books.Get(bookId);
            Person person = _persons.Get(personId);

            person.Books.Remove(book);
            _persons.Update(person);

            return _mapper.Map<PersonExtDto>(_persons.GetWithBooks(person.PersonId));
        }
        public IEnumerable<BookDto> GetPersonBooksById (int personId)
        {
            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(_persons.Get(personId).Books);
            return bookDtos;
        }
    }
}
