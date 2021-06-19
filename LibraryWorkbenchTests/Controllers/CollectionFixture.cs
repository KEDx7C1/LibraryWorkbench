using System;
using System.Collections.Generic;
using LibraryWorkbench.Core.DTO;
using Xunit;

namespace LibraryWorkbenchTests.Controllers
{
    public class CollectionFixture : IDisposable
    {
        public CollectionFixture()
        {
            Books = new List<BookDto>
            {
                new BookDto
                {
                    BookId = 1,
                    Name = "Book1",
                    Genres = new List<DimGenreDto>
                    {
                        new DimGenreDto(), new DimGenreDto()
                    },
                    Author = new AuthorDto
                    {
                        AuthorId = 1,
                        FirstName = "FirstName",
                        LastName = "LastName",
                        MiddleName = "MiddleName"
                    },
                    Year = 1900
                }
            };
        }

        public IEnumerable<BookDto> Books { get; }

        public void Dispose()
        {
        }

        [CollectionDefinition("DtoCollection")]
        public class BookDtoCollection : ICollectionFixture<CollectionFixture>
        {
        }
    }
}