using System.Collections.Generic;
using System.Linq;
using LibraryWorkbench.Controllers;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using Moq;
using Xunit;

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
            //Arrange
            var expectedCount = 1;
            _mockAuthorsService.Setup(a => a.GetAuthorsByYear(It.IsAny<int>(), It.IsAny<bool>()))
                .Returns(new List<AuthorDto> {new AuthorDto()}.AsQueryable());
            var authorsExtendedController = new AuthorsExtendedController(_mockAuthorsService.Object);
            //Act
            var result = authorsExtendedController.GetAuthorsByYear(It.IsAny<int>(), It.IsAny<bool>());
            //Assert
            Assert.Equal(expectedCount, result.Count());
        }

        [Fact]
        public void GetBooksByAuthor_ShouldReturn_ListOfAuthorDto()
        {
            //Arrange
            var expectedCount = 1;
            _mockAuthorsService.Setup(a => a.GetAuthorsByBookNamepart(It.IsAny<string>()))
                .Returns(new List<AuthorDto> {new AuthorDto()}.AsQueryable());
            var authorsExtendedController = new AuthorsExtendedController(_mockAuthorsService.Object);
            //Act
            var result = authorsExtendedController.GetAuthorsByBookNamepart(It.IsAny<string>());
            //Assert
            Assert.Equal(expectedCount, result.Count());
        }
    }
}