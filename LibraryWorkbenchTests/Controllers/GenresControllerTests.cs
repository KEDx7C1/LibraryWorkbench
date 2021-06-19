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
    public class GenresControllerTests
    {
        private readonly Mock<IGenresServices> _mockGenresServices;

        public GenresControllerTests()
        {
            _mockGenresServices = new Mock<IGenresServices>();
        }

        [Fact]
        public void GetGenres_ShouldReturn_ListOfDimGenresDTO()
        {
            //Arrange
            var expectedCount = 1;
            _mockGenresServices.Setup(a => a.GetAllGenres())
                .Returns(new List<DimGenreDto> {new DimGenreDto()}.AsQueryable());
            var genresController = new GenresController(_mockGenresServices.Object);
            //Act
            var result = genresController.GetGenres();
            //Assert
            Assert.Equal(expectedCount, result.Count());
        }

        [Fact]
        public void GetStatByGenre_ShouldReturn_OkObjectResult()
        {
            //Arrange
            _mockGenresServices.Setup(a => a.GetGenresStat()).Returns(new List<GenresStatisticDto>().AsQueryable());
            var genresController = new GenresController(_mockGenresServices.Object);
            //Act
            var result = genresController.GetStatByGenre();
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CreateGenre_WasExecuted()
        {
            //Arrange
            _mockGenresServices.Setup(a => a.CreateGenre(It.IsAny<DimGenreDto>())).Verifiable();
            var genresController = new GenresController(_mockGenresServices.Object);
            //Act
            genresController.CreateGenre(It.IsAny<DimGenreDto>());
        }
    }
}