using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LibraryWorkbench;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Core.Services;
using LibraryWorkbench.Data.Intefaces;
using LibraryWorkbench.Data.Models;
using Moq;
using Xunit;

namespace LibraryWorkbenchTests.Services
{
    public class AuthorsServiceTests
    {
        private readonly Author _author1;
        private readonly Author _author2;
        private readonly Book _book1;
        private readonly Book _book2;
        private readonly Book _book3;
        private readonly IMapper _mapper;
        private readonly Mock<IAuthorsRepository> _mockAuthorsRepository;
        private readonly Mock<IBooksService> _mockBookService;
        private readonly Mock<IBooksRepository> _mockBooksRepository;

        public AuthorsServiceTests()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            var mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
            _mockAuthorsRepository = new Mock<IAuthorsRepository>();
            _mockBooksRepository = new Mock<IBooksRepository>();
            _mockBookService = new Mock<IBooksService>();
            _author1 = new Author {AuthorId = 1, FirstName = "fn1", LastName = "ln1"};
            _author2 = new Author {AuthorId = 2, FirstName = "fn2", LastName = "ln2"};
            _book1 = new Book
            {
                BookId = 1,
                Name = "Book1",
                Author = _author1,
                Year = 1900
            };
            _book2 = new Book
            {
                BookId = 2,
                Name = "Book2",
                Author = _author2,
                Year = _book1.Year
            };
            _book3 = new Book
            {
                BookId = 3,
                Name = "Book3",
                Author = _author2,
                Year = _book1.Year
            };
        }

        [Fact]
        public void GetAuthors_ShouldReturn_TwoAuthorDto()
        {
            //Arrange
            var expectedCount = 2;
            _mockAuthorsRepository.Setup(a => a.GetAll())
                .Returns(new List<Author> {new Author(), new Author()}.AsQueryable);
            var authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper,
                _mockBookService.Object);
            //Act
            var actual = authorsService.GetAllAuthors();
            //Assert
            Assert.Equal(expectedCount, actual.Count());
            Assert.IsType<AuthorDto>(actual.FirstOrDefault());
        }

        [Fact]
        public void GetBooksByAuthor_ShouldReturn_AuthorWithBooksDto()
        {
            //Arrange
            _mockAuthorsRepository.Setup(a => a.Get(It.IsAny<int>())).Returns(new Author());
            _mockBooksRepository.Setup(a => a.GetAll()).Returns(new List<Book>().AsQueryable());
            var authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper,
                _mockBookService.Object);
            //Act
            var actual = authorsService.GetBooksByAuthor(It.IsAny<int>());
            //Assert
            Assert.IsType<AuthorWithBooksDto>(actual);
        }

        [Fact]
        public void CreateAuthorWithBooks_ShouldReturn_AuthorWithBooksDto()
        {
            //Arrange
            var books = new List<BookDto>
            {
                new BookDto
                {
                    BookId = 1, Name = "Name", Author = _mapper.Map<AuthorDto>(_author1),
                    Genres = new List<DimGenreDto> {new DimGenreDto {GenreId = 1, GenreName = "genre"}}
                }
            };
            var authorWithBooks = new AuthorWithBooksDto {Author = _mapper.Map<AuthorDto>(_author1), Books = books};
            _mockAuthorsRepository.Setup(a => a.GetAll()).Returns(new List<Author> {_author2}.AsQueryable());
            _mockAuthorsRepository.Setup(a => a.Create(It.IsAny<Author>())).Returns(_author1);

            _mockBookService.Setup(a => a.GetBooksByAuthor(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(books.AsQueryable());

            var authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper,
                _mockBookService.Object);
            //Act
            var actual = authorsService.CreateAuthorWithBooks(authorWithBooks);
            //Assert
            Assert.IsType<AuthorWithBooksDto>(actual);
        }

        [Fact]
        public void CreateAuthor_ShouldReturn_AuthorDto()
        {
            //Arrange
            _mockAuthorsRepository.Setup(a => a.GetAll()).Returns(new List<Author> {_author2}.AsQueryable());
            _mockAuthorsRepository.Setup(a => a.Create(It.IsAny<Author>())).Returns(_author1);

            var authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper,
                _mockBookService.Object);
            //Act
            var actual = authorsService.CreateAuthor(_mapper.Map<AuthorDto>(_author1));
            //Assert
            Assert.IsType<AuthorDto>(actual);
        }

        [Fact]
        public void CreateAuthor_ShouldThrow_Exception()
        {
            //Arrange
            _mockAuthorsRepository.Setup(a => a.GetAll()).Returns(new List<Author> {_author1}.AsQueryable());
            _mockAuthorsRepository.Setup(a => a.Create(It.IsAny<Author>())).Verifiable();

            var authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper,
                _mockBookService.Object);
            //Act
            //Assert
            Assert.Throws<Exception>(() => authorsService.CreateAuthor(_mapper.Map<AuthorDto>(_author1)));
        }

        [Fact]
        public void DeleteAuthor_AuthorWasDeleted()
        {
            //Arrange
            var authors = new List<Author> {_author1};
            _mockAuthorsRepository.Setup(a => a.Get(It.IsAny<int>())).Returns(authors.FirstOrDefault());
            _mockAuthorsRepository.Setup(a => a.Delete(It.IsAny<int>())).Callback(() =>
                    authors.Remove(authors.FirstOrDefault(x => x.AuthorId == _author1.AuthorId)))
                .Verifiable();
            var authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper,
                _mockBookService.Object);
            //Act
            authorsService.DeleteAuthor(It.IsAny<int>());
            //Assert
            Assert.Null(authors.FirstOrDefault(x => x.AuthorId == _author1.AuthorId));
        }

        [Fact]
        public void DeleteAuthor_ShouldThrow_Exception()
        {
            //Arrange
            _mockAuthorsRepository.Setup(a => a.Get(It.IsAny<int>())).Returns(It.IsAny<Author>());
            _mockAuthorsRepository.Setup(a => a.Delete(It.IsAny<int>())).Verifiable();
            var authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper,
                _mockBookService.Object);
            //Act
            //Assert
            Assert.Throws<Exception>(() => authorsService.DeleteAuthor(It.IsAny<int>()));
        }

        [Fact]
        public void GetAuthorsByYear_ShouldReturn_TwoAuthorDto()
        {
            //Arrange
            var expectedCount = 2;
            var isOrderByDesc = false;
            _mockBooksRepository.Setup(a => a.GetAll()).Returns(new List<Book> {_book1, _book2, _book3}.AsQueryable());

            var authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper,
                _mockBookService.Object);
            //Act
            var actual = authorsService.GetAuthorsByYear(_book1.Year, isOrderByDesc);
            //Assert
            Assert.Equal(expectedCount, actual.Count());
        }
    }
}