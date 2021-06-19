using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LibraryWorkbench;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Services;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Intefaces;
using LibraryWorkbench.Data.Models;
using Moq;
using Xunit;

namespace LibraryWorkbenchTests.Services
{
    public class GenresServiceTests
    {
        private readonly IMapper _mapper;

        public GenresServiceTests()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            var mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }

        [Fact]
        public void GetGenres_ShouldReturn_TwoGenres()
        {
            //Arrange
            const int expectedCount = 2;
            var mockGenresRepository = new Mock<IGenresRepository>();
            mockGenresRepository.Setup(a => a.GetAll())
                .Returns(new List<DimGenre> {new DimGenre(), new DimGenre()}.AsQueryable());
            var mockBooksRepository = new Mock<IBooksRepository>();

            var genresServices = new GenresServices(mockGenresRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            var actual = genresServices.GetAllGenres();
            //Assert
            Assert.Equal(expectedCount, actual.Count());
        }

        [Fact]
        public void CreateGenre_ShouldReturn_DimGenreDto()
        {
            //Arrange
            const int expectedCount = 2;
            var dimGenreDTO = new DimGenreDto {GenreId = 2, GenreName = "Genre2"};
            var genres = new List<DimGenre> {new DimGenre {GenreId = 1, GenreName = "Genre1"}};
            var mockGenresRepository = new Mock<IGenresRepository>();
            mockGenresRepository.Setup(a => a.GetAll())
                .Returns(genres.AsQueryable());
            mockGenresRepository.Setup(a => a.Create(It.IsAny<DimGenre>()))
                .Callback(() => { genres.Add(_mapper.Map<DimGenre>(dimGenreDTO)); });

            var mockBooksRepository = new Mock<IBooksRepository>();

            var genresServices = new GenresServices(mockGenresRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            genresServices.CreateGenre(dimGenreDTO);
            //Assert
            Assert.Equal(expectedCount, genres.Count());
        }

        [Fact]
        public void CreateGenre_ShouldThrow_Exception()
        {
            //Arrange
            var dimGenreDTO = new DimGenreDto {GenreId = 2, GenreName = "Genre1"};
            var dimGenre = new DimGenre {GenreName = dimGenreDTO.GenreName};
            var genres = new List<DimGenre> {new DimGenre {GenreId = 1, GenreName = "Genre1"}};
            var mockGenresRepository = new Mock<IGenresRepository>();
            mockGenresRepository.Setup(a => a.GetAll())
                .Returns(genres.AsQueryable());
            mockGenresRepository.Setup(a => a.Create(It.IsAny<DimGenre>()))
                .Callback(() => { genres.Add(dimGenre); });
            var mockBooksRepository = new Mock<IBooksRepository>();

            var genresServices = new GenresServices(mockGenresRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            //Assert
            Assert.Throws<Exception>(() => genresServices.CreateGenre(dimGenreDTO));
        }
    }
}