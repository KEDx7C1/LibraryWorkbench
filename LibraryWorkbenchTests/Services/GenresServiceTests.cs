using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.Data.Sqlite;
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

namespace LibraryWorkbenchTests.Services
{
    public class GenresServiceTests
    {
        private static IMapper _mapper;
        public GenresServiceTests()
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
        }
        [Fact]
        public void GetGenres_ShouldReturn_TwoGenres()
        {
            //Arrange
            const int expectedCount = 2;
            var mockGenresRepository = new Mock<IGenresRepository>();
            mockGenresRepository.Setup(a => a.GetAll())
                .Returns(new List<DimGenre>() { new DimGenre(), new DimGenre() }.AsQueryable());
            var mockBooksRepository = new Mock<IBooksRepository>();
            GenresServices genresServices = new GenresServices(mockGenresRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            var result = genresServices.GetGenres();
            //Assert
            Assert.Equal(expectedCount, result.Count());
        }
        [Fact]
        public void PersonWasCreated()
        {
            //Arrange
            const int expectedCount = 2;
            DimGenreDTO dimGenreDTO = new DimGenreDTO() { GenreId = 2, GenreName = "Genre2" };
            List<DimGenre> genres = new List<DimGenre>() { new DimGenre() { GenreId = 1, GenreName = "Genre1" } };
            var mockGenresRepository = new Mock<IGenresRepository>();
            mockGenresRepository.Setup(a => a.GetAll())
                .Returns(genres.AsQueryable());
            mockGenresRepository.Setup(a => a.Create(It.IsAny<DimGenre>()))
                .Callback(() =>
                {
                    genres.Add(_mapper.Map<DimGenre>(dimGenreDTO));
                });
                
            var mockBooksRepository = new Mock<IBooksRepository>();
            GenresServices genresServices = new GenresServices(mockGenresRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            genresServices.CreateGenre(dimGenreDTO);
            //Assert
            Assert.Equal(expectedCount, genres.Count());
        }
        [Fact]
        public void CreateGenre_ShouldThrow_Exception()
        {  
            //Arrange
            DimGenreDTO dimGenreDTO = new DimGenreDTO() { GenreId = 2, GenreName = "Genre1" };
            DimGenre dimGenre = new DimGenre() { GenreName = dimGenreDTO.GenreName };
            List<DimGenre> genres = new List<DimGenre>() { new DimGenre() { GenreId = 1, GenreName = "Genre1" } };
            var mockGenresRepository = new Mock<IGenresRepository>();
            mockGenresRepository.Setup(a => a.GetAll())
                .Returns(genres.AsQueryable());
            mockGenresRepository.Setup(a => a.Create(It.IsAny<DimGenre>()))
                .Callback(() =>
                {
                    genres.Add(dimGenre);
                });

            var mockBooksRepository = new Mock<IBooksRepository>();
            GenresServices genresServices = new GenresServices(mockGenresRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            //Assert
            Assert.Throws<Exception>(() => genresServices.CreateGenre(dimGenreDTO));
        }
    }
}