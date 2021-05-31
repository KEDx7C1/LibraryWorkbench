using Xunit;
using Moq;
using System.Collections.Generic;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Controllers;
using Microsoft.AspNetCore.Mvc;

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
            _mockGenresServices.Setup(a => a.GetGenres()).Returns(new List<DimGenreDto>());
            GenresController genresController = new GenresController(_mockGenresServices.Object);
            //Act
            var result = genresController.GetGenres();
            //Assert
            Assert.IsType<List<DimGenreDto>>(result);
        }
        [Fact]
        public void GetStatByGenre_ShouldReturn_OkObjectResult()
        {
            //Arrenge
            _mockGenresServices.Setup(a => a.GetGenresStat()).Returns(new List<GenresStatisticDto>());
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
