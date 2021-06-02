using AutoMapper;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Data.Intefaces;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IQueryable<PersonDto> GetAllPersons()
        {
            return _mapper.ProjectTo<PersonDto>(_persons.GetAll());
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
                return _mapper.Map<PersonDto>(person);
            }
            else
                throw new Exception($"Person {personDto.FirstName} {personDto.LastName} {personDto.MiddleName} birth {personDto.Birthday} already exist");
        }
        public PersonDto UpdatePerson(PersonDto personDto)
        {
            Person person = _persons.Get(personDto.PersonId);
            person.FirstName = personDto.FirstName;
            person.LastName = personDto.LastName;
            person.MiddleName = personDto.MiddleName;
            person.Birthday = personDto.Birthday;
            _persons.Update(person);
            return _mapper.Map<PersonDto>(person);
        }
        public void DeletePersonById(int id)
        {
            _persons.Delete(id);
        }
        public void DeletePersonsByFullName(PersonDto personDto)
        {
            List<Person> personsToDelete = _persons.GetAll().Where(x => x.FirstName == personDto.FirstName
            && x.LastName == personDto.LastName && x.MiddleName == personDto.MiddleName).ToList();
            if (personsToDelete != null && personsToDelete.Any())
            {
                foreach (var p in personsToDelete)
                    _persons.Delete(p.PersonId);
            }
            else
                throw new Exception("Persons with same fullname not found");
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
        public IQueryable<BookDto> GetPersonBooksById(int personId)
        {
            var books = _persons.Get(personId).Books;
            return _mapper.ProjectTo<BookDto>(books.AsQueryable());
        }
    }
}
