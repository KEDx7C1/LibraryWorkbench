using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Linq;
using Xunit;
using Moq;
using System.Collections.Generic;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core;
using LibraryWorkbench.Data.Intefaces;
using AutoMapper;
using LibraryWorkbench;

namespace LibraryWorkbenchTests.Repositories
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
        public void GetGenresStat_ShouldReturn_One()
        {
            //Arrange
            const int expectedCount = 1;
            var mockBooksRepository = new Mock<IBooksRepository>();
            mockBooksRepository.Setup(a => a.GetAll())
                .Returns(new List<Book>() { 
                new Book()
                {
                    BookId = 1,
                    Name = "Name1",
                    Genres = new List<DimGenre>()
                    {
                        new DimGenre()
                        {
                            GenreId = 1,
                            GenreName = "Genre1"
                        }
                    }
                },
                new Book()
                {
                    BookId = 2,
                    Name = "Name2",
                    Genres = new List<DimGenre>()
                    {   
                        new DimGenre()
                        {
                            GenreId = 2,
                            GenreName = "Genre2"
                        }
                    }
                }
                }.AsQueryable());
            var mockGenresRepository = new Mock<IGenresRepository>();
            GenresServices genresServices = new GenresServices(mockGenresRepository.Object, mockBooksRepository.Object, _mapper);
            //Act
            var result = genresServices.GetGenresStat();
            Assert.Equal(expectedCount, result.Where(x=>x.GenreName == "Genre1").Select(x=>x.GenreCount).FirstOrDefault());
        }
        [Fact]
        public void GenreWasCreated()
        {
            const int expectedCount = 2;
            DimGenreDTO dimGenreDTO = new DimGenreDTO() { GenreId = 2, GenreName = "Genre2" };
            DimGenre dimGenre = new DimGenre() { GenreName = dimGenreDTO.GenreName };
            List<DimGenre> genres = new List<DimGenre>() { new DimGenre()
            {
                GenreId = 1,
                GenreName = "Genre1"
            }
            };
            var mockGenresRepository = new Mock<IGenresRepository>();
            mockGenresRepository.Setup(a => a.GetAll())
                .Returns(genres.AsQueryable());
            mockGenresRepository.Setup(a => a.Create(dimGenre))
                .Callback(() =>
                {
                    genres.Add(dimGenre);
                });
                
            var mockBooksRepository = new Mock<IBooksRepository>();
            GenresServices genresServices = new GenresServices(mockGenresRepository.Object, mockBooksRepository.Object, _mapper);

            genresServices.CreateGenre(dimGenreDTO);

            Assert.Equal(expectedCount, genres.Count());
        }
    }
}