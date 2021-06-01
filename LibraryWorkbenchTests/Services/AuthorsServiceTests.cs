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
using LibraryWorkbench.Core.Interfaces;

namespace LibraryWorkbenchTests.Services
{
    public class AuthorsServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAuthorsRepository> _mockAuthorsRepository;
        private readonly Mock<IBooksRepository> _mockBooksRepository;
        private readonly Mock<IBooksService> _mockBookService;
        private readonly Book _book1;
        private readonly Book _book2;
        private readonly Book _book3;
        private readonly Author _author1;
        private readonly Author _author2;

        public AuthorsServiceTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
            _mockAuthorsRepository = new Mock<IAuthorsRepository>();
            _mockBooksRepository = new Mock<IBooksRepository>();
            _mockBookService = new Mock<IBooksService>();
            _author1 = new Author() { AuthorId = 1, FirstName = "fn1", LastName = "ln1" };
            _author2 = new Author() { AuthorId = 2, FirstName = "fn2", LastName = "ln2" };
            _book1 = new Book()
            {
                BookId = 1,
                Name = "Book1",
                Author = _author1,
                Year = 1900
            };
            _book2 = new Book()
            {
                BookId = 2,
                Name = "Book2",
                Author = _author2,
                Year = _book1.Year
            };
            _book3 = new Book()
            {
                BookId = 3,
                Name = "Book3",
                Author = _author2,
                Year = _book1.Year
            };
        }
        [Fact]
        public void GetAuthors_ShouldReturn_TwoAuthorDTO()
        {
            //Arrenge
            int expectedCount = 2;
            _mockAuthorsRepository.Setup(a => a.GetAll()).Returns(new List<Author>() { new Author(), new Author() }.AsQueryable);
            AuthorsService authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper, _mockBookService.Object);
            //Act
            var result = authorsService.GetAllAuthors();
            //Assert
            Assert.Equal(expectedCount, result.Count());
            Assert.IsType<AuthorDto>(result.FirstOrDefault());
        }
        [Fact]
        public void GetBooksByAuthor_ShouldReturn_AuthorWithBooksDto()
        {
            _mockAuthorsRepository.Setup(a => a.Get(It.IsAny<int>())).Returns(new Author());
            _mockBooksRepository.Setup(a => a.GetAll()).Returns(new List<Book>().AsQueryable());
            AuthorsService authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper, _mockBookService.Object);

            var result = authorsService.GetBooksByAuthor(It.IsAny<int>());

            Assert.IsType<AuthorWithBooksDto>(result);
        }
        [Fact]
        public void CreateAuthorWithBooks_ShouldReturn_AuthorWithBooksDto()
        {

        }
        [Fact]
        public void CreateAuthor_ShouldReturn_AuthorDto()
        {
            _mockAuthorsRepository.Setup(a => a.GetAll()).Returns(new List<Author>() { _author2 }.AsQueryable());
            _mockAuthorsRepository.Setup(a => a.Create(It.IsAny<Author>())).Returns(_author1);

            AuthorsService authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper, _mockBookService.Object);

            var result = authorsService.CreateAuthor(_mapper.Map<AuthorDto>(_author1));

            Assert.IsType<AuthorDto>(result);
        }
        [Fact]
        public void CreateAuthor_ShouldThrow_Exception()
        {
            _mockAuthorsRepository.Setup(a => a.GetAll()).Returns(new List<Author>() { _author1 }.AsQueryable());
            _mockAuthorsRepository.Setup(a => a.Create(It.IsAny<Author>())).Verifiable();

            AuthorsService authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper, _mockBookService.Object);

            Assert.Throws<Exception>(() => authorsService.CreateAuthor(_mapper.Map<AuthorDto>(_author1)));
        }
        [Fact]
        public void AuthorWasDeleted()
        {
            _mockAuthorsRepository.Setup(a => a.Get(It.IsAny<int>())).Returns(_author1);
            _mockAuthorsRepository.Setup(a => a.Delete(It.IsAny<int>())).Verifiable();
            AuthorsService authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper, _mockBookService.Object);

            authorsService.DeleteAuthor(It.IsAny<int>());
        }
        [Fact]
        public void DeleteAuthor_ShouldThrow_Exception()
        {
            _mockAuthorsRepository.Setup(a => a.Get(It.IsAny<int>())).Returns(It.IsAny<Author>());
            _mockAuthorsRepository.Setup(a => a.Delete(It.IsAny<int>())).Verifiable();
            AuthorsService authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper, _mockBookService.Object);

            Assert.Throws<Exception>(() => authorsService.DeleteAuthor(It.IsAny<int>()));
        }
        [Fact]
        public void GetAuthorsByYear_ShouldReturn_TwoAuthorDto()
        {
            int expectedCount = 2;
            bool isOrderByDesc = false;
            _mockBooksRepository.Setup(a => a.GetAll()).Returns(new List<Book>() { _book1, _book2, _book3 }.AsQueryable());

            AuthorsService authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper, _mockBookService.Object);

            var result = authorsService.GetAuthorsByYear(_book1.Year, isOrderByDesc);

            Assert.Equal(expectedCount, result.Count());
        }
    }
}
