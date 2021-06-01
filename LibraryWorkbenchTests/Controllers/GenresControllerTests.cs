using Xunit;
using Moq;
using System.Collections.Generic;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            //Arrenge
            int expectedCount = 1;
            _mockGenresServices.Setup(a => a.GetAllGenres()).Returns(new List<DimGenreDto>() { new DimGenreDto()}.AsQueryable());
            GenresController genresController = new GenresController(_mockGenresServices.Object);
            //Act
            var result = genresController.GetGenres();
            //Assert
            Assert.Equal(expectedCount, result.Count());
        }
        [Fact]
        public void GetStatByGenre_ShouldReturn_OkObjectResult()
        {
            //Arrenge
            _mockGenresServices.Setup(a => a.GetGenresStat()).Returns(new List<GenresStatisticDto>().AsQueryable());
            GenresController genresController = new GenresController(_mockGenresServices.Object);
            //Act
            var result = genresController.GetStatByGenre();
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void CreateGenre_WasExecuted()
        {
            //Arrenge
            _mockGenresServices.Setup(a => a.CreateGenre(It.IsAny<DimGenreDto>())).Verifiable();
            GenresController genresController = new GenresController(_mockGenresServices.Object);
            //Act
            genresController.CreateGenre(It.IsAny<DimGenreDto>());
        }
    }
}
