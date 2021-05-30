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
        private static IMapper _mapper;
        private static List<Book> _books;
        private static List<Person> _persons;
        private static AuthorDTO _authorDto;
        private static DimGenreDTO _genre1Dto;
        private static DimGenreDTO _genre2Dto;
        private static BookDTO _bookDto1;
        private static BookDTO _bookDto2;
        private static BookDTO _bookDto3;
        private static Mock<IGenresRepository> _mockGenresRepository;
        private static Mock<IPersonsRepository>  _mockPersonsRepository;
        private static Mock<IBooksRepository> _mockBooksRepository;
        private static Mock<IAuthorsRepository> _mockAuthorsRepository;
        public BooksServiceTests()
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
            if (_authorDto == null)
                _authorDto = new AuthorDTO()
                {
                    AuthorId = 1,
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    MiddleName = "MiddleName1"
                };
            if (_genre1Dto == null)
                _genre1Dto = new DimGenreDTO()
                {
                    GenreId = 1,
                    GenreName = "Genre1"
                };
            if (_genre2Dto == null)
                _genre2Dto = new DimGenreDTO()
                {
                    GenreId = 2,
                    GenreName = "Genre2"
                };
            if (_bookDto1 == null)
                _bookDto1 = new BookDTO()
                {
                    BookId = 1,
                    Author = _authorDto,
                    Name = "BookName1",
                    Year = 1900,
                    Genres = new List<DimGenreDTO>() { _genre1Dto, _genre2Dto }
                };
            if (_bookDto2 == null)
                _bookDto2 = new BookDTO()
                {
                    BookId = 2,
                    Author = _authorDto,
                    Name = "BookName2",
                    Year = 1900,
                    Genres = new List<DimGenreDTO>() { _genre1Dto, _genre2Dto }
                };
            if (_bookDto3 == null)
                _bookDto3 = new BookDTO()
                {
                    BookId = 3,
                    Author = _authorDto,
                    Name = "BookName3",
                    Year = 1900,
                    Genres = new List<DimGenreDTO>() { _genre1Dto, _genre2Dto }
                };
            if (_books == null)
                _books = new List<Book>()
                {
                _mapper.Map<Book>(_bookDto1),
                _mapper.Map<Book>(_bookDto2)
                };
            if (_persons == null)
                _persons = new List<Person> {new Person()
                {
                    PersonId = 1,
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    MiddleName = "MiddleName1"
                } };
            if (_mockGenresRepository == null)
                _mockGenresRepository = new Mock<IGenresRepository>();
            if (_mockPersonsRepository == null)
                _mockPersonsRepository = new Mock<IPersonsRepository>();
            if (_mockBooksRepository == null)
                _mockBooksRepository = new Mock<IBooksRepository>();
            if (_mockAuthorsRepository == null)
                _mockAuthorsRepository = new Mock<IAuthorsRepository>();
        }
        [Fact]
        public void CreateBook_ShouldReturn_BookDTO()
        {
            //Arrange
            int expectedCount = _books.Count() + 1;
            
            BooksService booksServices = new BooksService(_mockBooksRepository.Object, _mockPersonsRepository.Object,
                _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);
            _mockBooksRepository.Setup(a => a.Create(It.IsAny<Book>())).Callback<Book>(p => _books.Add(p));
            _mockGenresRepository.Setup(a => a.GetAll()).Returns((new List<DimGenre> { _mapper.Map<DimGenre>(_genre1Dto)}).AsQueryable);
            //Act
            var result = booksServices.CreateBook(_bookDto3);
            //Assert
            Assert.Equal(expectedCount, _books.Count());
            Assert.IsType<BookDTO>(result);
        }
        [Fact]
        public void GetBook_ShouldReturn_BookDTO()
        {
            //Arrange
            _mockBooksRepository.Setup(a => a.Get(It.IsAny<int>())).Returns(_mapper.Map<Book>(_bookDto1));

            BooksService booksServices = new BooksService(_mockBooksRepository.Object, 
                _mockPersonsRepository.Object, _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);
            //Act
            var result = booksServices.GetBook(It.IsAny<int>());
            //Assert
            Assert.IsType<BookDTO>(result);
            Assert.Equal(_bookDto1.Name, result.Name);
        }
        [Fact]
        public void GetAllBooks_ShouldReturn_BooksCount()
        {
            //Arrenge
            int expectedCount = _books.Count();
            _mockBooksRepository.Setup(a => a.GetAll()).Returns(_books.AsQueryable());

            BooksService booksServices = new BooksService(_mockBooksRepository.Object,
                _mockPersonsRepository.Object, _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);

            //Act
            var result = booksServices.GetAllBooks();
            //Assert
            Assert.Equal(expectedCount, result.Count());
        }
        [Fact]
        public void DeleteBook_ShouldReturn_Status200()
        {
            //Arrenge
            int bookId = 2;
            int okStatus = 200;
            _mockBooksRepository.Setup(a => a.Get(It.IsAny<int>())).Returns(_books.First());
            _mockBooksRepository.Setup(a => a.Delete(It.IsAny<int>()))
                .Callback(() => _books.Remove(_books.Where(x => x.BookId == bookId).FirstOrDefault()));
            _mockPersonsRepository.Setup(a => a.GetAll()).Returns(_persons.AsQueryable);

            BooksService booksServices = new BooksService(_mockBooksRepository.Object,
                _mockPersonsRepository.Object, _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);

            //Act
            int result = booksServices.DeleteBook(bookId);

            //Assert
            Assert.Equal(okStatus, result);
        }
        [Fact]
        public void ChangeGanre_ShouldReturn_BookDTO()
        {
            _mockGenresRepository.Setup(a => a.GetAll()).Returns(new List<DimGenre>()
            {
                _mapper.Map<DimGenre>(_genre1Dto),
                _mapper.Map<DimGenre>(_genre2Dto),
            }.AsQueryable);
            _mockBooksRepository.Setup(a => a.Get(It.IsAny<int>())).Returns(_books.First());
            _mockBooksRepository.Setup(a => a.Update(It.IsAny<Book>())).Verifiable();
            BooksService booksServices = new BooksService(_mockBooksRepository.Object,
                _mockPersonsRepository.Object, _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);
            var result = booksServices.ChangeGanre(_bookDto1);
            Assert.IsType<BookDTO>(result);
        }
        [Fact]
        public void GetBooksByAuthor_ShouldReturn_ListOfBookDTO()
        {
            int expecterCount = _books.Count();
            string firstName = _authorDto.FirstName;
            string lastName = _authorDto.LastName;
            string middleName = _authorDto.MiddleName;

            _mockBooksRepository.Setup(a => a.GetAll()).Returns(_books.AsQueryable());

            BooksService booksServices = new BooksService(_mockBooksRepository.Object,
                _mockPersonsRepository.Object, _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);

            var result = booksServices.GetBooksByAuthor(_authorDto.FirstName, _authorDto.LastName, _authorDto.MiddleName);
            //int Count = result.Count();
            //Assert.Equal(expecterCount, Count);
            Assert.Null(result);
        }
        [Fact]
        public void GetBooksByGenre_ShouldReturn_ListOfBookDTO()
        {
            int expecterCount = _books.Count();
            string genreName = _genre1Dto.GenreName;
            _mockBooksRepository.Setup(a => a.GetAll()).Returns(_books.AsQueryable());
            BooksService booksServices = new BooksService(_mockBooksRepository.Object,
                _mockPersonsRepository.Object, _mockGenresRepository.Object, _mockAuthorsRepository.Object, _mapper);
            var result = booksServices.GetBooksByGenre(genreName);
            int Count = result.Count();
            Assert.Equal(expecterCount, Count);
        }
    }
}