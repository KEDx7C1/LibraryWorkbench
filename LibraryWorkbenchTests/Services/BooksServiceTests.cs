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

namespace LibraryWorkbenchTests.Services
{
    public class BooksServiceTests
    {
        private static IMapper _mapper;
        public BooksServiceTests()
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
        public void CreateBook_ShouldReturn_BookDTO()
        {

            //Arrange
            List<Book> books = new List<Book>();
            AuthorDTO author = new AuthorDTO()
            {
                AuthorId = 1,
                FirstName = "FirstName1",
                LastName = "LastName1",
                MiddleName = "MiddleName1",
            };
            DimGenreDTO genre1 = new DimGenreDTO()
            {
                GenreId = 1,
                GenreName = "Genre1"
            };
            DimGenreDTO genre2 = new DimGenreDTO()
            {
                GenreId = 2,
                GenreName = "Genre2"
            };
            BookDTO bookDTO = new BookDTO()
            {
                Author = author,
                Name = "BookName1",
                Year = 1900,
                Genres = new List<DimGenreDTO>() { genre1, genre2 }
            };
            var mockGenresRepository = new Mock<IGenresRepository>();
            var mockPersonsRepository = new Mock<IPersonsRepository>();
            var mockBooksRepository = new Mock<IBooksRepository>();
            var mockAuthorsRepository = new Mock<IAuthorsRepository>();
            mockGenresRepository.Setup(a => a.GetAll())
                .Returns(new List<DimGenre>() { new DimGenre(), new DimGenre() }.AsQueryable());
            
            BooksService booksServices = new BooksService(mockBooksRepository.Object, mockPersonsRepository.Object,
                mockGenresRepository.Object, mockAuthorsRepository.Object, _mapper);
            mockBooksRepository.Setup(a => a.Create(It.IsAny<Book>())).Callback<Book>(p => books.Add(p));
            mockGenresRepository.Setup(a => a.GetAll()).Returns((new List<DimGenre> { _mapper.Map<DimGenre>(genre1)}).AsQueryable);
            //Act
            var result = booksServices.CreateBook(bookDTO);
            //Assert
            Assert.NotEmpty(books);
            Assert.IsType<BookDTO>(result);
        }
    }
}