using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LibraryWorkbench;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Services;
using LibraryWorkbench.Data.Intefaces;
using LibraryWorkbench.Data.Models;
using Moq;
using Xunit;

namespace LibraryWorkbenchTests.Services
{
    public class PersonsServiceTests
    {
        private readonly Book _book;
        private readonly IMapper _mapper;
        private readonly PersonDto _personDto;
        private readonly List<Person> _persons;

        public PersonsServiceTests()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            var mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

            _persons = new List<Person>
            {
                new Person
                {
                    PersonId = 1,
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    MiddleName = "MiddleName1",
                    Birthday = new DateTime(1985, 1, 1)
                },
                new Person
                {
                    PersonId = 2,
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    MiddleName = "MiddleName2",
                    Birthday = new DateTime(1984, 2, 5)
                }
            };
            _personDto = new PersonDto
            {
                PersonId = 3,
                FirstName = "FirstName3",
                LastName = "LastName3",
                MiddleName = "MiddleName3",
                Birthday = new DateTime(1981, 7, 9)
            };
            _book = new Book
            {
                BookId = 1,
                Name = "Book1",
                Author = new Author(),
                Genres = new List<DimGenre> {new DimGenre(), new DimGenre()},
                Year = 1900
            };
        }

        [Fact]
        public void GetAllPersons_ShouldReturn_ListOfPersonDto()
        {
            //Arrange
            var expectedCount = _persons.Count();

            var mockBooksRepository = new Mock<IBooksRepository>();
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.GetAll())
                .Returns(_persons.AsQueryable());

            var genresServices = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            var actual = genresServices.GetAllPersons();
            //Assert
            Assert.Equal(expectedCount, actual.Count());
        }

        [Fact]
        public void CreatePerson_ShouldReturn_PersonDto()
        {
            //Arrange
            var mockBooksRepository = new Mock<IBooksRepository>();
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.GetAll())
                .Returns(_persons.AsQueryable());
            mockPersonsRepository.Setup(a => a.Create(It.IsAny<Person>())).Callback(() =>
                _persons.Add(_mapper.Map<Person>(_personDto))).Returns(() => _persons.Last());

            var personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            var actual = personsService.CreatePerson(_personDto);
            //Assert
            Assert.IsType<PersonDto>(actual);
            Assert.Equal(_personDto.PersonId, _persons.Last().PersonId);
        }

        [Fact]
        public void CreatePerson_ShouldThrow_Exception()
        {
            //Arrange
            var mockBooksRepository = new Mock<IBooksRepository>();
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.GetAll())
                .Returns(_persons.AsQueryable());
            _persons.Add(_mapper.Map<Person>(_personDto));
            var personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            //Assert
            Assert.Throws<Exception>(() => personsService.CreatePerson(_personDto));
        }

        [Fact]
        public void UpdatePerson_ShouldReturn_PersonDto()
        {
            //Arrange
            var personDto = new PersonDto
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
                .Returns(_persons.FirstOrDefault(x => x.PersonId == personDto.PersonId));
            mockPersonsRepository.Setup(a => a.Update(It.IsAny<Person>())).Callback<Person>(p =>
            {
                var person = _persons.FirstOrDefault(x => x.PersonId == p.PersonId);
                person = _mapper.Map<Person>(personDto);
            });
            var personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            var actual = personsService.UpdatePerson(personDto);
            //Assert
            Assert.IsType<PersonDto>(actual);
            Assert.Equal(personDto.FirstName,
                _persons.Where(x => x.PersonId == personDto.PersonId).Select(x => x.FirstName).FirstOrDefault());
        }

        [Fact]
        public void DeletePersonById_PersonWasDeleted()
        {
            //Arrange
            var personId = 2;
            var mockBooksRepository = new Mock<IBooksRepository>();
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.Delete(It.IsAny<int>()))
                .Callback(() => _persons.Remove(_persons.FirstOrDefault(x => x.PersonId == personId)));
            var personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            personsService.DeletePersonById(personId);
            //Assert
            Assert.Null(_persons.FirstOrDefault(x => x.PersonId == personId));
        }

        [Fact]
        public void DeletePersonsByFullName_PersonWasDeleted()
        {
            //Arrange
            var personDto = new PersonDto
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
                .Callback(() =>
                    _persons.Remove(_persons.Where(x => x.PersonId == personDto.PersonId).FirstOrDefault()));
            var personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            personsService.DeletePersonsByFullName(personDto);
            //Assert
            Assert.Null(_persons.FirstOrDefault(x => x.PersonId == personDto.PersonId));
        }

        [Fact]
        public void GiveBook_ShouldReturn_PersonExtDto()
        {
            //Arrange
            var mockBooksRepository = new Mock<IBooksRepository>();
            mockBooksRepository.Setup(a => a.Get(It.IsAny<int>()))
                .Returns(_book);
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.Get(It.IsAny<int>()))
                .Returns(_persons.First());
            mockPersonsRepository.Setup(a => a.GetWithBooks(It.IsAny<int>()))
                .Returns(_persons.First());
            var personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            var actual = personsService.GiveBook(It.IsAny<int>(), It.IsAny<int>());
            //Assert
            Assert.IsType<PersonExtDto>(actual);
            Assert.NotNull(actual.Books);
        }

        [Fact]
        public void ReturnBook_ShouldReturn_PersonExtDto()
        {
            //Arrange
            _persons.First().Books = new List<Book>();
            _persons.First().Books.Add(_book);
            var mockBooksRepository = new Mock<IBooksRepository>();
            mockBooksRepository.Setup(a => a.Get(It.IsAny<int>()))
                .Returns(_book);
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.Get(It.IsAny<int>()))
                .Returns(_persons.First());
            mockPersonsRepository.Setup(a => a.GetWithBooks(It.IsAny<int>()))
                .Returns(_persons.First());
            var personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            var actual = personsService.ReturnBook(It.IsAny<int>(), It.IsAny<int>());
            //Assert
            Assert.IsType<PersonExtDto>(actual);
            Assert.Empty(actual.Books);
        }

        [Fact]
        public void GetPersonBooksById_ShouldReturn_TwoBooks()
        {
            //Arrange
            var expectedCount = 2;
            _persons.First().Books = new List<Book>();
            _persons.First().Books.Add(_book);
            _persons.First().Books.Add(_book);
            var mockBooksRepository = new Mock<IBooksRepository>();
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            mockPersonsRepository.Setup(a => a.Get(It.IsAny<int>()))
                .Returns(_persons.First());
            mockPersonsRepository.Setup(a => a.GetWithBooks(It.IsAny<int>()))
                .Returns(_persons.First());
            var personsService = new PersonsService(mockPersonsRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            var actual = personsService.GetPersonBooksById(_persons.First().PersonId);
            //Assert
            Assert.Equal(expectedCount, actual.Count());
        }
    }
}