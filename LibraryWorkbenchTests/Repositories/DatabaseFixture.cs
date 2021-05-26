using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LibraryWorkbenchTests.Repositories
{
    public class DatabaseFixture : IDisposable
    {
        DataContext context;
        SqliteConnection connection;
        public DatabaseFixture()
        {
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var option = new DbContextOptionsBuilder<DataContext>().UseSqlite(connection).Options;
            context = new DataContext(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            var genre1 = new DimGenre() { GenreName = "Стихи" };
            var genre2 = new DimGenre() { GenreName = "Ужасы" };
            var genre3 = new DimGenre() { GenreName = "Фантастика" };
            context.DimGenres.AddRange(genre1, genre2, genre3);

            var author1 = new Author() { 
                FirstName = "Author1_FirstName", 
                LastName = "Author1_LastName", 
                MiddleName = "Author1_MiddleName"
            };

            var author2 = new Author()
            {
                FirstName = "Author2_FirstName",
                LastName = "Author2_LastName",
                MiddleName = "Author2_MiddleName"
            };

            var author3 = new Author()
            {
                FirstName = "Author3_FirstName",
                LastName = "Author3_LastName",
                MiddleName = "Author3_MiddleName"
            };
            context.Authors.AddRange(author1, author2, author3);

            var book1 = new Book() { Name = "Book1", Genres = new List<DimGenre>() { genre1, genre2 }, Author =  author1};
            var book2 = new Book() { Name = "Book2", Genres = new List<DimGenre>() { genre2 }, Author = author2 };
            context.Books.AddRange(book1, book2);
        }
        public DataContext Context => context;
        public SqliteConnection Connection => connection;
        public void Dispose()
        {
            context.Dispose();
        }
        [CollectionDefinition("DatabaseCollection")]
        public class DatabaseCollection : ICollectionFixture<DatabaseFixture> { }

    }
}
