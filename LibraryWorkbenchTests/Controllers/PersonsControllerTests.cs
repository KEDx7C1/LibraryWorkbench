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
    public class PersonsControllerTests
    {
        private readonly Mock<IPersonsService> _mockPersonsService;

        public PersonsControllerTests()
        {
            _mockPersonsService = new Mock<IPersonsService>();
        }

        [Fact]
        public void GetGenres_ShouldReturn_ListOfDimGenresDTO()
        {
            //Arrange
            _mockPersonsService.Setup(a => a.GetAllPersons()).Returns(new List<PersonDto>().AsQueryable());
            var personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.GetAllPersons();
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetPersonBooksById_ShouldReturn_OkObjectResult()
        {
            //Arrange
            _mockPersonsService.Setup(a => a.GetPersonBooksById(It.IsAny<int>()))
                .Returns(new List<BookDto>().AsQueryable());
            var personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.GetPersonBooksById(It.IsAny<int>());
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetPersonBooksById_ShouldThrow_Exception()
        {
            //Arrange
            _mockPersonsService.Setup(a => a.GetPersonBooksById(It.IsAny<int>())).Throws(new Exception());
            var personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            //Assert
            Assert.Throws<Exception>(() => personsController.GetPersonBooksById(It.IsAny<int>()));
        }

        [Fact]
        public void CreatePerson_ShouldReturn_OkObjectResult()
        {
            //Arrange
            _mockPersonsService.Setup(a => a.CreatePerson(It.IsAny<PersonDto>())).Returns(new PersonDto());
            var personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.CreatePerson(It.IsAny<PersonDto>());
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CreatePerson_ShouldReturn_NotFoundResult()
        {
            //Arrange
            _mockPersonsService.Setup(a => a.CreatePerson(It.IsAny<PersonDto>())).Returns(It.IsAny<PersonDto>());
            var personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.CreatePerson(It.IsAny<PersonDto>());
            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void GiveBook_ShouldReturn_PersonExtDTO()
        {
            //Arrange
            _mockPersonsService.Setup(a => a.GiveBook(It.IsAny<int>(), It.IsAny<int>())).Returns(new PersonExtDto());
            var personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.GiveBook(It.IsAny<int>(), It.IsAny<int>());
            //Assert
            Assert.IsType<PersonExtDto>(result);
        }

        [Fact]
        public void ReturnBook_ShouldReturn_PersonExtDTO()
        {
            //Arrange
            _mockPersonsService.Setup(a => a.ReturnBook(It.IsAny<int>(), It.IsAny<int>())).Returns(new PersonExtDto());
            var personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.ReturnBook(It.IsAny<int>(), It.IsAny<int>());
            //Assert
            Assert.IsType<PersonExtDto>(result);
        }

        [Fact]
        public void DeletePerson_ShouldReturn_OkResult()
        {
            //Arrange
            _mockPersonsService.Setup(a => a.DeletePersonById(It.IsAny<int>()));
            var personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.DeletePerson(It.IsAny<int>());
            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeletePersonsByFullName_ShouldReturn_OkResult()
        {
            //Arrange
            _mockPersonsService.Setup(a => a.DeletePersonsByFullName(It.IsAny<PersonDto>()));
            var personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.DeletePersonsByFullName(It.IsAny<PersonDto>());
            //Assert
            Assert.IsType<OkResult>(result);
        }
    }
}