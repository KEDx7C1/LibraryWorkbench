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
            //Arrenge
            _mockPersonsService.Setup(a => a.GetAllPersons()).Returns(new List<PersonDto>().AsQueryable());
            PersonsController personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.GetAllPersons();
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetPersonBooksById_ShouldReturn_OkObjectResult()
        {
            //Arrenge
            _mockPersonsService.Setup(a => a.GetPersonBooksById(It.IsAny<int>())).Returns(new List<BookDto>().AsQueryable());
            PersonsController personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.GetPersonBooksById(It.IsAny<int>());
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetPersonBooksById_ShouldThrow_Exception()
        {
            //Arrenge
            _mockPersonsService.Setup(a => a.GetPersonBooksById(It.IsAny<int>())).Throws(new Exception());
            PersonsController personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            //Assert
            Assert.Throws<Exception>(() => personsController.GetPersonBooksById(It.IsAny<int>()));
        }
        [Fact]
        public void CreatePerson_ShouldReturn_OkObjectResult()
        {
            //Arrenge
            _mockPersonsService.Setup(a => a.CreatePerson(It.IsAny<PersonDto>())).Returns(new PersonDto());
            PersonsController personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.CreatePerson(It.IsAny<PersonDto>());
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void CreatePerson_ShouldReturn_NotFoundResult()
        {
            //Arrenge
            _mockPersonsService.Setup(a => a.CreatePerson(It.IsAny<PersonDto>())).Returns(It.IsAny<PersonDto>());
            PersonsController personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.CreatePerson(It.IsAny<PersonDto>());
            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public void GiveBook_ShouldReturn_PersonExtDTO()
        {
            //Arrenge
            _mockPersonsService.Setup(a => a.GiveBook(It.IsAny<int>(), It.IsAny<int>())).Returns(new PersonExtDto());
            PersonsController personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.GiveBook(It.IsAny<int>(), It.IsAny<int>());
            //Assert
            Assert.IsType<PersonExtDto>(result);
        }
        [Fact]
        public void ReturnBook_ShouldReturn_PersonExtDTO()
        {
            //Arrenge
            _mockPersonsService.Setup(a => a.ReturnBook(It.IsAny<int>(), It.IsAny<int>())).Returns(new PersonExtDto());
            PersonsController personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.ReturnBook(It.IsAny<int>(), It.IsAny<int>());
            //Assert
            Assert.IsType<PersonExtDto>(result);
        }
        [Fact]
        public void DeletePerson_ShouldReturn_OkResult()
        {
            //Arrenge
            _mockPersonsService.Setup(a => a.DeletePersonById(It.IsAny<int>()));
            PersonsController personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.DeletePerson(It.IsAny<int>());
            //Assert
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void DeletePersonsByFullName_ShouldReturn_OkResult()
        {
            //Arrenge
            _mockPersonsService.Setup(a => a.DeletePersonsByFullName(It.IsAny<PersonDto>()));
            PersonsController personsController = new PersonsController(_mockPersonsService.Object);
            //Act
            var result = personsController.DeletePersonsByFullName(It.IsAny<PersonDto>());
            //Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
