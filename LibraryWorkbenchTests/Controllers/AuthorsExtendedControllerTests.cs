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
    public class AuthorsExtendedControllerTests
    {
        private readonly Mock<IAuthorsService> _mockAuthorsService;
        public AuthorsExtendedControllerTests()
        {
            _mockAuthorsService = new Mock<IAuthorsService>();
        }
        [Fact]
        public void GetAuthorsByYear_ShouldReturn_ListOfAuthorDTO()
        {
            //Arrenge
            _mockAuthorsService.Setup(a => a.GetAuthorsByYear(It.IsAny<int>(), It.IsAny<string>())).Returns(new List<AuthorDto>());
            AuthorsExtendedController authorsExtendedController = new AuthorsExtendedController(_mockAuthorsService.Object);
            //Act
            var result = authorsExtendedController.GetAuthorsByYear(It.IsAny<int>(), It.IsAny<string>());
            //Assert
            Assert.IsType<List<AuthorDto>>(result);
        }
        [Fact]
        public void GetBooksByAuthor_ShouldReturn_OkObjectResult()
        {
            //Arrenge
            _mockAuthorsService.Setup(a => a.GetAuthorsByBookNamepart(It.IsAny<string>())).Returns(new List<AuthorDto>());
            AuthorsExtendedController authorsExtendedController = new AuthorsExtendedController(_mockAuthorsService.Object);
            //Act
            var result = authorsExtendedController.GetAuthorsByBookNamepart(It.IsAny<string>());
            //Assert
            Assert.IsType<List<AuthorDto>>(result);
        }
    }
}
