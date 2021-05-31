using System;
using System.Linq;
using Xunit;
using Moq;
using System.Collections.Generic;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWorkbenchTests.Controllers
{
    public class BooksControllerTests
    {
        private readonly Mock<IBooksService> _mockBooksService;
        private readonly IEnumerable<BookDto> _books;
        public BooksControllerTests()
        {
            _mockBooksService = new Mock<IBooksService>();
            _books = new List<BookDto>()
            {
                new BookDto()
                {
                    BookId = 1,
                    Name = "Book1",
                    Genres = new List<DimGenreDto>()
                    {
                        new DimGenreDto(), new DimGenreDto()
                    },
                    Author = new AuthorDto()
                    {
                        AuthorId = 1,
                        FirstName = "FirstName",
                        LastName = "LastName",
                        MiddleName = "MiddleName"
                    },
                    Year = 1900
                }
            };
        }


        [Fact]
        public void GetAllBooks_ShouldReturn_ListOfBookDTO()
        {
            //Arrange
            int expectedCount = _books.Count();
            _mockBooksService.Setup(a => a.GetAllBooks()).Returns(_books).Verifiable();
            BooksController booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.GetAllBooks();
            //Assert
            Assert.Equal(expectedCount, result.Count());
            Assert.IsType<List<BookDto>>(result);
        }
        [Fact]
        public void GetBooksByAuthor_ShouldReturn_OneBookDTO()
        {
            int expectedCount = 1;
            BookDto book = _books.First();
            string firstName = book.Author.FirstName;
            string lastName = book.Author.LastName;
            string middleNmae = book.Author.MiddleName;
            //Arrange
            _mockBooksService.Setup(a => a.GetBooksByAuthor(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_books.Where(x => x.Author.FirstName == firstName));
            BooksController booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.GetBooksByAuthor(firstName, lastName, middleNmae);
            //Assert
            Assert.Equal(expectedCount, result.Count());
        }
        [Fact]
        public void GetBooksByGenre_ShouldReturn_OneBookDTO()
        {
            //Arrenge
            int expectedCount = 1;
            _mockBooksService.Setup(a => a.GetBooksByGenre(It.IsAny<string>())).Returns(new List<BookDto>() { new BookDto()}).Verifiable();
            BooksController booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.GetBooksByGenre(It.IsAny<string>());
            //Assert
            Assert.Equal(expectedCount, result.Count());
        }
        [Fact]
        public void GetBookById_ShouldReturn_OkObjectResult()
        {
            //Arrenge
            _mockBooksService.Setup(a => a.GetBook(It.IsAny<int>())).Returns(new BookDto()).Verifiable();
            BooksController booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.GetBookById(It.IsAny<int>());
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetBookById_ShouldReturn_BadRequestResult()
        {
            //Arrenge
            _mockBooksService.Setup(a => a.GetBook(It.IsAny<int>())).Throws(new Exception()).Verifiable();
            BooksController booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.GetBookById(It.IsAny<int>());
            //Assert
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public void CreateBook_ShouldReturn_BookDTO()
        {
            //Arrenge
            _mockBooksService.Setup(a => a.CreateBook(It.IsAny<BookDto>())).Returns(new BookDto()).Verifiable();
            BooksController booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.CreateBook(It.IsAny<BookDto>());
            //Assert
            Assert.IsType<BookDto>(result);
        }
        [Fact]
        public void DeleteBook_ShouldReturn_OkResult()
        {
            //Arrenge
            int okStatusCode = 200;
            _mockBooksService.Setup(a => a.DeleteBook(It.IsAny<int>())).Returns(okStatusCode).Verifiable();
            BooksController booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.DeleteBook(It.IsAny<int>());
            //Assert
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void DeleteBook_ShouldReturn_BadRequestObjectResult()
        {
            //Arrenge
            int BadRequestStatusCode = 405;
            _mockBooksService.Setup(a => a.DeleteBook(It.IsAny<int>())).Returns(BadRequestStatusCode).Verifiable();
            BooksController booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.DeleteBook(It.IsAny<int>());
            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public void ChangeGanre_ShouldReturn_BookDTO()
        {
            //Arrenge
            _mockBooksService.Setup(a => a.ChangeGanre(It.IsAny<BookDto>())).Returns(new BookDto()).Verifiable();
            BooksController booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.ChangeGanre(It.IsAny<BookDto>());
            //Assert
            Assert.IsType<BookDto>(result);
        }
    }
}
