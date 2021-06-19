using System;
using System.Collections.Generic;
using System.Linq;
using LibraryWorkbench.Controllers;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LibraryWorkbenchTests.Controllers
{
    [Collection("DtoCollection")]
    public class BooksControllerTests
    {
        private readonly CollectionFixture _collectionFixture;
        private readonly Mock<IBooksService> _mockBooksService;

        public BooksControllerTests(CollectionFixture collectionFixture)
        {
            _mockBooksService = new Mock<IBooksService>();
            _collectionFixture = collectionFixture;
        }


        [Fact]
        public void GetAllBooks_ShouldReturn_ListOfBookDTO()
        {
            //Arrange
            var expectedCount = _collectionFixture.Books.Count();
            _mockBooksService.Setup(a => a.GetAllBooks()).Returns(_collectionFixture.Books.AsQueryable()).Verifiable();
            var booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.GetAllBooks();
            //Assert
            Assert.Equal(expectedCount, result.Count());
        }

        [Fact]
        public void GetBooksByAuthor_ShouldReturn_OneBookDTO()
        {
            var expectedCount = 1;
            var book = _collectionFixture.Books.First();
            var firstName = book.Author.FirstName;
            var lastName = book.Author.LastName;
            var middleNmae = book.Author.MiddleName;
            //Arrange
            _mockBooksService.Setup(a => a.GetBooksByAuthor(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_collectionFixture.Books.Where(x => x.Author.FirstName == firstName).AsQueryable());
            var booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.GetBooksByAuthor(firstName, lastName, middleNmae);
            //Assert
            Assert.Equal(expectedCount, result.Count());
        }

        [Fact]
        public void GetBooksByGenre_ShouldReturn_OneBookDTO()
        {
            //Arrange
            var expectedCount = 1;
            _mockBooksService.Setup(a => a.GetBooksByGenre(It.IsAny<string>()))
                .Returns(new List<BookDto> {new BookDto()}.AsQueryable()).Verifiable();
            var booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.GetBooksByGenre(It.IsAny<string>());
            //Assert
            Assert.Equal(expectedCount, result.Count());
        }

        [Fact]
        public void GetBookById_ShouldReturn_OkObjectResult()
        {
            //Arrange
            _mockBooksService.Setup(a => a.GetBook(It.IsAny<int>())).Returns(new BookDto()).Verifiable();
            var booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.GetBookById(It.IsAny<int>());
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetBookById_ShouldThrow_Exception()
        {
            //Arrange
            _mockBooksService.Setup(a => a.GetBook(It.IsAny<int>())).Throws(new Exception()).Verifiable();
            var booksController = new BooksController(_mockBooksService.Object);
            //Act
            //Assert
            Assert.Throws<Exception>(() => booksController.GetBookById(It.IsAny<int>()));
        }

        [Fact]
        public void CreateBook_ShouldReturn_BookDTO()
        {
            //Arrange
            _mockBooksService.Setup(a => a.CreateBook(It.IsAny<BookDto>())).Returns(new BookDto()).Verifiable();
            var booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.CreateBook(It.IsAny<BookDto>());
            //Assert
            Assert.IsType<BookDto>(result);
        }

        [Fact]
        public void DeleteBook_ShouldReturn_OkResult()
        {
            //Arrange
            _mockBooksService.Setup(a => a.DeleteBook(It.IsAny<int>()));
            var booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.DeleteBook(It.IsAny<int>());
            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteBook_ShouldThrow_Exception()
        {
            //Arrange
            _mockBooksService.Setup(a => a.DeleteBook(It.IsAny<int>())).Throws(new Exception());
            var booksController = new BooksController(_mockBooksService.Object);
            //Act
            //Assert
            Assert.Throws<Exception>(() => booksController.DeleteBook(It.IsAny<int>()));
        }

        [Fact]
        public void ChangeGanre_ShouldReturn_BookDTO()
        {
            //Arrange
            _mockBooksService.Setup(a => a.ChangeGanre(It.IsAny<BookDto>())).Returns(new BookDto()).Verifiable();
            var booksController = new BooksController(_mockBooksService.Object);
            //Act
            var result = booksController.ChangeGanre(It.IsAny<BookDto>());
            //Assert
            Assert.IsType<BookDto>(result);
        }
    }
}