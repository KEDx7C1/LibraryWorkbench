using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using System;
using System.Linq;
using Xunit;
using Moq;
using System.Collections.Generic;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Services;
using LibraryWorkbench.Data.Intefaces;
using AutoMapper;
using LibraryWorkbench;
using LibraryWorkbench.Core.Interfaces;

namespace LibraryWorkbenchTests.Services
{
    public class AuthorsServiceTests
    {
        private static IMapper _mapper;
        private static Mock<IAuthorsRepository> _mockAuthorsRepository;
        private static Mock<IBooksRepository> _mockBooksRepository;
        private static Mock<IBooksService> _mockBookService;
        public AuthorsServiceTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            if(_mockAuthorsRepository == null)
            {
                _mockAuthorsRepository = new Mock<IAuthorsRepository>();
            }
            if (_mockBooksRepository == null)
            {
                _mockBooksRepository = new Mock<IBooksRepository>();
            }
            if (_mockBookService == null)
            {
                _mockBookService = new Mock<IBooksService>();
            }
        }
        [Fact]
        public void GetAuthors_ShouldReturn_TwoAuthorDTO()
        {
            //Arrenge
            int expectedCount = 2;
            _mockAuthorsRepository.Setup(a => a.GetAll()).Returns(new List<Author>() { new Author(), new Author() }.AsQueryable);
            AuthorsService authorsService = new AuthorsService(_mockAuthorsRepository.Object, _mockBooksRepository.Object, _mapper, _mockBookService.Object);
            //Act
            var result = authorsService.GetAuthors();
            //Assert
            Assert.Equal(expectedCount, result.Count());
        }
    }
}
