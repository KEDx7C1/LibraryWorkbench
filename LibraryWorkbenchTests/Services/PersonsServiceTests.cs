using AutoMapper;
using LibraryWorkbench;
using LibraryWorkbench.Core.Services;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Data.Intefaces;
using LibraryWorkbench.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LibraryWorkbenchTests.Services
{
    public class PersonsServiceTests
    {
        private static IMapper _mapper;
        private List<Person> _persons;
        public PersonsServiceTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _persons = new List<Person>()
                {
                    new Person()
                {
                    PersonId = 1,
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    MiddleName = "MiddleName1",
                    Birthday = new DateTime(1985, 1, 1)
                }
                , new Person()
                {
                    PersonId = 2,
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    MiddleName = "MiddleName2",
                    Birthday = new DateTime(1984, 2, 5)
                }};
        }

        [Fact]
        public void GetPersons_ShouldReturn_TwoPersons()
        {
            //Arrange
            const int expectedCount = 2;
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.GetAll())
                .Returns(_persons.AsQueryable());
            var mockBooksRepository = new Mock<IBooksRepository>();
            PersonsService genresServices = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            var result = genresServices.GetAllPersons();
            //Assert
            Assert.Equal(expectedCount, result.Count());
        }
        [Fact]
        public void CreatePerson_ShouldReturn_PersonDTO()
        {
            //Arrage
            var personDto = new PersonDto()
            {
                PersonId = 3,
                FirstName = "FirstName3",
                LastName = "LastName3",
                MiddleName = "MiddleName3",
                Birthday = new DateTime(1981, 7, 9)
            };
            var mockBooksRepository = new Mock<IBooksRepository>();
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.GetAll())
                .Returns(_persons.AsQueryable());
            mockPersonsRepository.Setup(a => a.Create(It.IsAny<Person>())).Callback<Person>(p =>
            {
                _persons.Add(p);
            });
            mockPersonsRepository.Setup(a => a.Get(It.IsAny<int>()))
                .Returns(_persons.Where(x => x.PersonId == _persons.Count()).FirstOrDefault());
            PersonsService personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            var result = personsService.CreatePerson(personDto);

            //Assert
            Assert.IsType<PersonDto>(result);
            Assert.Equal(personDto.PersonId, _persons.Count());
        }
        [Fact]
        public void CreatePerson_ShouldThrow_Exception()
        {
            //Arrage
            var personDto = new PersonDto()
            {
                PersonId = 3,
                FirstName = "FirstName1",
                LastName = "LastName1",
                MiddleName = "MiddleName1",
                Birthday = new DateTime(1985, 1, 1)
            };
            var mockBooksRepository = new Mock<IBooksRepository>();
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.GetAll())
                .Returns(_persons.AsQueryable());
            mockPersonsRepository.Setup(a => a.Create(It.IsAny<Person>())).Callback<Person>(p =>
            {
                _persons.Add(p);
            });
            mockPersonsRepository.Setup(a => a.Get(It.IsAny<int>()))
                .Returns(_persons.Where(x => x.PersonId == _persons.Count()).FirstOrDefault());
            PersonsService personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            //Assert
            Assert.Throws<Exception>(() => personsService.CreatePerson(personDto));
        }
        [Fact]
        public void UpdatePerson_ShouldReturn_PersonDTO()
        {
            //Arrage
            var personDto = new PersonDto()
            {
                PersonId = 1,
                FirstName = "NewFirstName1",
                LastName = "NewLastName1",
                MiddleName = "NewMiddleName1",
                Birthday = new DateTime(1981, 7, 9)
            };
            var mockBooksRepository = new Mock<IBooksRepository>();
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.Get(It.IsAny<int>()))
                .Returns(_persons.Where(x=>x.PersonId == personDto.PersonId).FirstOrDefault());
            mockPersonsRepository.Setup(a => a.Update(It.IsAny<Person>())).Callback<Person>(p =>
            {
                Person person = _persons.Where(x => x.PersonId == p.PersonId).FirstOrDefault();
                person = _mapper.Map<Person>(personDto);
            });
            PersonsService personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            var result = personsService.UpdatePerson(personDto);

            //Assert
            Assert.IsType<PersonDto>(result);
            Assert.Equal(personDto.FirstName, _persons.Where(x => x.PersonId == personDto.PersonId).Select(x => x.FirstName).FirstOrDefault());
        }
        [Fact]
        public void PersonWasDeletedById()
        {
            int personId = 2;
            var mockBooksRepository = new Mock<IBooksRepository>();
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.Delete(It.IsAny<int>()))
                .Callback(() => _persons.Remove(_persons.Where(x => x.PersonId == personId).FirstOrDefault()));
            PersonsService personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            personsService.DeletePersonById(personId);
            //Assert
            Assert.Null(_persons.Where(x => x.PersonId == personId).FirstOrDefault());
        }
        [Fact]
        public void PersonWasDeletedByFullName()
        {
            int ok = 200;
            PersonDto personDto = new PersonDto()
            {
                PersonId = 10,
                FirstName = "FirstName10",
                LastName = "LastName10",
                MiddleName = "MiddleName10",
                Birthday = new DateTime(1981, 7, 9)
            };
            _persons.Add(_mapper.Map<Person>(personDto));
            var mockBooksRepository = new Mock<IBooksRepository>();
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.GetAll())
                .Returns(_persons.AsQueryable());
            mockPersonsRepository.Setup(a => a.Delete(It.IsAny<int>()))
                .Callback(() => _persons.Remove(_persons.Where(x => x.PersonId == personDto.PersonId).FirstOrDefault()));
            PersonsService personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            int result = personsService.DeletePersonsByFullName(personDto);
            //Assert
            Assert.Null(_persons.Where(x => x.PersonId == personDto.PersonId).FirstOrDefault());
            Assert.Equal(ok, result);
        }
        [Fact]
        public void GiveBook_ShouldReturn_PersonExtDTO()
        {
            
            var mockBooksRepository = new Mock<IBooksRepository>();
            mockBooksRepository.Setup(a => a.Get(It.IsAny<int>()))
                .Returns(new Book()
                {
                    Name = "Book1",
                    Author = new Author(),
                    Genres = new List<DimGenre>() { new DimGenre(), new DimGenre() },
                    Year = 1900
                });
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.Get(It.IsAny<int>()))
                .Returns(_persons.First());
            mockPersonsRepository.Setup(a => a.GetWithBooks(It.IsAny<int>()))
                .Returns(_persons.First());

            PersonsService personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);

            var result = personsService.GiveBook(It.IsAny<int>(), It.IsAny<int>());
            Assert.IsType<PersonExtDto>(result);
            Assert.NotNull(result.Books);
        }
        [Fact]
        public void ReturnBook_ShouldReturn_PersonExtDTO()
        {
            Book book = new Book()
            {
                BookId = 1,
                Name = "Book1",
                Author = new Author(),
                Genres = new List<DimGenre>() { new DimGenre(), new DimGenre() },
                Year = 1900
            };
            _persons.First().Books.Add(book);
            var mockBooksRepository = new Mock<IBooksRepository>();
            mockBooksRepository.Setup(a => a.Get(It.IsAny<int>()))
                .Returns(book);
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.Get(It.IsAny<int>()))
                .Returns(_persons.First());
            mockPersonsRepository.Setup(a => a.GetWithBooks(It.IsAny<int>()))
                .Returns(_persons.First());

            PersonsService personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);

            var result = personsService.ReturnBook(It.IsAny<int>(), It.IsAny<int>());
            Assert.IsType<PersonExtDto>(result);
            Assert.Empty(result.Books);
        }
        [Fact]
        public void GetPersonBooksById_ShouldReturn_TwoBooks()
        {
            int expectedCount = 2;
            Book book1 = new Book()
            {
                BookId = 1,
                Name = "Book1",
                Author = new Author(),
                Genres = new List<DimGenre>() { new DimGenre(), new DimGenre() },
                Year = 1900
            };
            Book book2 = new Book()
            {
                BookId = 1,
                Name = "Book1",
                Author = new Author(),
                Genres = new List<DimGenre>() { new DimGenre(), new DimGenre() },
                Year = 1900
            };
            _persons.First().Books.Add(book1);
            _persons.First().Books.Add(book2);
            var mockBooksRepository = new Mock<IBooksRepository>();
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.Get(It.IsAny<int>()))
                .Returns(_persons.First());
            mockPersonsRepository.Setup(a => a.GetWithBooks(It.IsAny<int>()))
                .Returns(_persons.First());

            PersonsService personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);

            var result = personsService.GetPersonBooksById(_persons.First().PersonId);
            Assert.IsType<List<BookDto>>(result);
            Assert.Equal(expectedCount, result.Count());
        }
    }
    
}
