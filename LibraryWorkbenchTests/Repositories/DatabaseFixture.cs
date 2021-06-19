using System;
using System.Collections.Generic;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LibraryWorkbenchTests.Repositories
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            Connection = new SqliteConnection("DataSource=:memory:");
            Connection.Open();

            var option = new DbContextOptionsBuilder<DataContext>().UseSqlite(Connection).Options;
            Context = new DataContext(option);
            if (Context != null)
            {
                Context.Database.EnsureDeleted();
                Context.Database.EnsureCreated();
            }

            var genre1 = new DimGenre {GenreName = "Стихи"};
            var genre2 = new DimGenre {GenreName = "Ужасы"};
            var genre3 = new DimGenre {GenreName = "Фантастика"};
            Context.DimGenres.AddRange(genre1, genre2, genre3);

            var author1 = new Author
            {
                FirstName = "Author1_FirstName",
                LastName = "Author1_LastName",
                MiddleName = "Author1_MiddleName"
            };

            var author2 = new Author
            {
                FirstName = "Author2_FirstName",
                LastName = "Author2_LastName",
                MiddleName = "Author2_MiddleName"
            };

            var author3 = new Author
            {
                FirstName = "Author3_FirstName",
                LastName = "Author3_LastName",
                MiddleName = "Author3_MiddleName"
            };
            Context.Authors.AddRange(author1, author2, author3);

            var book1 = new Book {Name = "Book1", Genres = new List<DimGenre> {genre1, genre2}, Author = author1};
            var book2 = new Book {Name = "Book2", Genres = new List<DimGenre> {genre2}, Author = author2};
            Context.Books.AddRange(book1, book2);

            var person1 = new Person
            {
                FirstName = "Person1_FirstName",
                LastName = "Person1_LastName",
                MiddleName = "Person1_MiddleName"
            };
            var person2 = new Person
            {
                FirstName = "Person2_FirstName",
                LastName = "Person2_LastName",
                MiddleName = "Person2_MiddleName"
            };
            var person3 = new Person
            {
                FirstName = "Person3_FirstName",
                LastName = "Person3_LastName",
                MiddleName = "Person3_MiddleName"
            };
            Context.Persons.AddRange(person1, person2, person3);
        }

        public DataContext Context { get; }

        public SqliteConnection Connection { get; }

        public void Dispose()
        {
            Context.Dispose();
        }

        [CollectionDefinition("DatabaseCollection")]
        public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
        {
        }
    }
}