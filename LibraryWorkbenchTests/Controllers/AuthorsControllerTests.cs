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
    public class AuthorsControllerTests
    {
        private readonly Mock<IAuthorsService> _mockAuthorsService;
        public AuthorsControllerTests()
        {
            _mockAuthorsService = new Mock<IAuthorsService>();
        }
        [Fact]
        public void GetAuthors_ShouldReturn_ListOfAuthorDTO()
        {
            //Arrenge
            int expectedCount = 2;
            _mockAuthorsService.Setup(a => a.GetAllAuthors()).Returns(new List<AuthorDto>() { new AuthorDto(), new AuthorDto()}.AsQueryable());
            AuthorsController authorsController = new AuthorsController(_mockAuthorsService.Object);
            //Act
            var result = authorsController.GetAuthors();
            //Assert
            Assert.Equal(expectedCount, result.Count());
        }
        [Fact]
        public void GetBooksByAuthor_ShouldReturn_OkObjectResult()
        {
            //Arrenge
            _mockAuthorsService.Setup(a => a.GetBooksByAuthor(It.IsAny<int>())).Returns(new AuthorWithBooksDto());
            AuthorsController authorsController = new AuthorsController(_mockAuthorsService.Object);
            //Act
            var result = authorsController.GetBooksByAuthor(It.IsAny<int>());
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetBooksByAuthor_ShouldThrow_Exception()
        {
            //Arrenge
            _mockAuthorsService.Setup(a => a.GetBooksByAuthor(It.IsAny<int>())).Throws(new Exception());
            AuthorsController authorsController = new AuthorsController(_mockAuthorsService.Object);
            //Act
            //Assert
            Assert.Throws<Exception>(() => authorsController.GetBooksByAuthor(It.IsAny<int>()));
        }
        [Fact]
        public void CreateAuthor_ShouldReturn_AuthorDTO()
        {
            //Arrenge
            _mockAuthorsService.Setup(a => a.CreateAuthorWithBooks(It.IsAny<AuthorWithBooksDto>())).Returns(new AuthorWithBooksDto());
            AuthorsController authorsController = new AuthorsController(_mockAuthorsService.Object);
            //Act
            var result = authorsController.CreateAuthor(It.IsAny<AuthorWithBooksDto>());
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void DeleteAuthor_ShouldReturn_OkResult()
        {
            //Arrenge
            _mockAuthorsService.Setup(a => a.DeleteAuthor(It.IsAny<int>()));
            AuthorsController authorsController = new AuthorsController(_mockAuthorsService.Object);
            //Act
            var result = authorsController.DeleteAuthor(It.IsAny<int>());
            //Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
