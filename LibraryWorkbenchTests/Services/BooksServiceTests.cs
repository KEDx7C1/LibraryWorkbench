using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using System;
using System.Linq;
using Xunit;
using Moq;
using System.Collections.Generic;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Services;
using LibraryWorkbench.Data.Intefaces;
using AutoMapper;
using LibraryWorkbench;

namespace LibraryWorkbenchTests.Services
{
    public class BooksServiceTests
    {
        private readonly IMapper _mapper;
        private readonly List<Book> _books;
        private readonly List<Person> _persons;
        private readonly AuthorDto _authorDto;
        private readonly DimGenreDto _genre1Dto;
        private readonly DimGenreDto _genre2Dto;
        private readonly BookDto _bookDto1;
        private readonly BookDto _bookDto2;
        private readonly BookDto _bookDto3;
        private readonly Mock<IGenresRepository> _mockGenresRepository;
        private readonly Mock<IPersonsRepository>  _mockPersonsRepository;
        private readonly Mock<IBooksRepository> _mockBooksRepository;
        private readonly Mock<IAuthorsRepository> _mockAuthorsRepository;
        public BooksServiceTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
            _authorDto = new AuthorDto()
            {
                AuthorId = 1,
                FirstName = "FirstName1",
                LastName = "LastName1",
                MiddleName = "MiddleName1"
            };
            _genre1Dto = new DimGenreDto()
            {
                GenreId = 1,
                GenreName = "Genre1"
            };
            _genre2Dto = new DimGenreDto()
            {
                GenreId = 2,
                GenreName = "Genre2"
            };
            _bookDto1 = new BookDto()
            {
                BookId = 1,
                Author = _authorDto,
                Name = "BookName1",
                Year = 1900,
                Genres = new List<DimGenreDto>() { _genre1Dto, _genre2Dto }
            };
            _bookDto2 = new BookDto()
            {
                BookId = 2,
                Author = _authorDto,
                Name = "BookName2",
                Year = 1900,
                Genres = new List<DimGenreDto>() { _genre1Dto, _genre2Dto }
            };
            _bookDto3 = new BookDto()
            {
                BookId = 3,
                Author = _authorDto,
                Name = "BookName3",
                Year = 1900,
                Genres = new List<DimGenreDto>() { _genre1Dto, _genre2Dto }
            };
            _books = new List<Book>()
            {
            _mapper.Map<Book>(_bookDto1),
            _mapper.Map<Book>(_bookDto2)
            };
            _persons = new List<Person> {new Person()
            {
                PersonId = 1,
                FirstName = "FirstName1",
                LastName = "LastName1",
                MiddleName = "MiddleName1"
            } };
            _mockGenresRepository = new Mock<IGenresRepository>();
            _mockPersonsRepository = new Mock<IPersonsRepository>();
            _mockBooksRepository = new Mock<IBooksRepository>();
            _mockAuthorsRepository = new Mock<IAuthorsRepository>();
        }
        [Fact]
        public void CreateBook_ShouldReturn_BookDto()
        {
            //Arrange
            int expectedCount = _books.Count() + 1;
            
            BooksService booksServices = new BooksService(_mockBooksRepository.Object, _mockPersonsRepository.Object,
                _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);
            _mockBooksRepository.Setup(a => a.Create(It.IsAny<Book>())).Callback<Book>(p => _books.Add(p));
            _mockGenresRepository.Setup(a => a.GetAll()).Returns((new List<DimGenre> { _mapper.Map<DimGenre>(_genre1Dto)}).AsQueryable);
            //Act
            var actual = booksServices.CreateBook(_bookDto3);
            //Assert
            Assert.Equal(expectedCount, _books.Count());
            Assert.IsType<BookDto>(actual);
        }
        [Fact]
        public void GetBook_ShouldReturn_BookDto()
        {
            //Arrange
            _mockBooksRepository.Setup(a => a.Get(It.IsAny<int>())).Returns(_mapper.Map<Book>(_bookDto1));

            BooksService booksServices = new BooksService(_mockBooksRepository.Object, 
                _mockPersonsRepository.Object, _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);
            //Act
            var actual = booksServices.GetBook(It.IsAny<int>());
            //Assert
            Assert.IsType<BookDto>(actual);
            Assert.Equal(_bookDto1.Name, actual.Name);
        }
        [Fact]
        public void GetAllBooks_ShouldReturn_BooksCount()
        {
            //Arrange
            int expectedCount = _books.Count();
            _mockBooksRepository.Setup(a => a.GetAll()).Returns(_books.AsQueryable());

            BooksService booksServices = new BooksService(_mockBooksRepository.Object,
                _mockPersonsRepository.Object, _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);
            //Act
            var actual = booksServices.GetAllBooks();
            //Assert
            Assert.Equal(expectedCount, actual.Count());
        }
        [Fact]
        public void DeleteBook_ShouldReturn_Status200()
        {
            //Arrange
            int bookId = 2;
            _mockBooksRepository.Setup(a => a.Get(It.IsAny<int>())).Returns(_books.First());
            _mockBooksRepository.Setup(a => a.Delete(It.IsAny<int>()))
                .Callback(() => _books.Remove(_books.FirstOrDefault(x => x.BookId == bookId)));
            _mockPersonsRepository.Setup(a => a.GetAll()).Returns(_persons.AsQueryable);

            BooksService booksServices = new BooksService(_mockBooksRepository.Object,
                _mockPersonsRepository.Object, _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);
            //Act
            booksServices.DeleteBook(bookId);
            //Assert
            Assert.Null(_books.FirstOrDefault(x => x.BookId == bookId));
        }
        [Fact]
        public void DeleteBook_ShouldThrow_Exception()
        {
            //Arrange
            _mockBooksRepository.Setup(a => a.Get(It.IsAny<int>())).Throws(new Exception());
            _mockBooksRepository.Setup(a => a.Delete(It.IsAny<int>()));
            _mockPersonsRepository.Setup(a => a.GetAll()).Returns(_persons.AsQueryable);

            BooksService booksServices = new BooksService(_mockBooksRepository.Object,
                _mockPersonsRepository.Object, _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);
            //Act
            //Assert
            Assert.Throws<Exception>(() => booksServices.DeleteBook(It.IsAny<int>()));

        }
        [Fact]
        public void ChangeGanre_ShouldReturn_BookDto()
        {
            //Arrange
            _mockGenresRepository.Setup(a => a.GetAll()).Returns(new List<DimGenre>()
            {
                _mapper.Map<DimGenre>(_genre1Dto),
                _mapper.Map<DimGenre>(_genre2Dto),
            }.AsQueryable);
            _mockBooksRepository.Setup(a => a.Get(It.IsAny<int>())).Returns(_books.First());
            _mockBooksRepository.Setup(a => a.Update(It.IsAny<Book>())).Verifiable();
            BooksService booksServices = new BooksService(_mockBooksRepository.Object,
                _mockPersonsRepository.Object, _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);
            //Act
            var actual = booksServices.ChangeGanre(_bookDto1);
            //Assert
            Assert.IsType<BookDto>(actual);
        }
        [Fact]
        public void GetBooksByAuthor_ShouldReturn_ListOfBookDto()
        {
            //Arrange
            int expecterCount = _books.Count();
            string firstName = _authorDto.FirstName;
            string lastName = _authorDto.LastName;
            string middleName = _authorDto.MiddleName;

            _mockBooksRepository.Setup(a => a.GetAll()).Returns(_books.AsQueryable());

            BooksService booksServices = new BooksService(_mockBooksRepository.Object,
                _mockPersonsRepository.Object, _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);
            //Act
            var actual = booksServices.GetBooksByAuthor(firstName, lastName, middleName);
            //Assert
            Assert.Equal(expecterCount, actual.Count());
        }
        [Fact]
        public void GetBooksByGenre_ShouldReturn_ListOfBookDto()
        {
            //Arrange
            int expecterCount = _books.Count();
            string genreName = _genre1Dto.GenreName;
            _mockBooksRepository.Setup(a => a.GetAll()).Returns(_books.AsQueryable());
            BooksService booksServices = new BooksService(_mockBooksRepository.Object,
                _mockPersonsRepository.Object, _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);
            //Act
            var actual = booksServices.GetBooksByGenre(genreName);
            //Assert
            Assert.Equal(expecterCount, actual.Count());
        }
    }
}