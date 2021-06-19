using System;
using System.Linq;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.Data.Sqlite;
using Xunit;

namespace LibraryWorkbenchTests.Repositories
{
    [Collection("DatabaseCollection")]
    public class BooksRepositoryTests
    {
        private readonly DatabaseFixture database;

        public BooksRepositoryTests(DatabaseFixture fixture)
        {
            database = fixture;
        }

        [Fact]
        public void Create_ShouldReturn_Book()
        {
            //Arrange
            const int expectedCount = 1;
            var repository = new BooksRepository(database.Context);
            var sql = "SELECT COUNT(*) FROM book WHERE book_id=@id;";
            var book = new Book
            {
                Name = "NewBook",
                Author = new Author
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    MiddleName = "MiddleName"
                },
                Genres =
                {
                    new DimGenre {GenreName = "SomeGenre1"},
                    new DimGenre {GenreName = "SomeGenre2"}
                },
                Year = 1900
            };
            //Act
            var actual = repository.Create(book);
            //Assert
            using (var cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", book.BookId);
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                Assert.Equal(expectedCount, count);
                Assert.IsType<Book>(actual);
            }
        }

        [Fact]
        public void Get_ShouldReturn_Book()
        {
            //Arrange
            var repository = new BooksRepository(database.Context);
            var bookId = 1;

            //Act
            var book = repository.Get(bookId);

            //Assert
            Assert.Equal(bookId, book.BookId);
        }

        [Fact]
        public void Get_ShouldThrow_Exception()
        {
            //Arrange
            var repository = new BooksRepository(database.Context);
            var bookId = 100;

            //Act
            //Assert
            Assert.Throws<Exception>(() => repository.Get(bookId));
        }

        [Fact]
        public void GetAll_ShouldReturn_BookList()
        {
            //Arrange
            int expectedCount;
            var repository = new BooksRepository(database.Context);
            var sql = "SELECT COUNT(*) FROM book;";
            using (var cmd = new SqliteCommand(sql, database.Connection))
            {
                expectedCount = Convert.ToInt32(cmd.ExecuteScalar());
            }

            //Act
            var books = repository.GetAll();
            //Assert
            Assert.Equal(expectedCount, books.Count());
        }

        [Fact]
        public void Update_ShouldReturn_Book()
        {
            //Arrange
            var repository = new BooksRepository(database.Context);
            var bookId = 1;
            var name = "ChengedName";
            var sql = "SELECT name FROM book WHERE book_id=@id;";
            var book = repository.Get(bookId);
            //Act
            book.Name = name;
            var actual = repository.Update(book);
            //Assert
            using (var cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", book.BookId);
                var result = cmd.ExecuteScalar().ToString();
                Assert.Equal(result, name);
                Assert.IsType<Book>(actual);
            }
        }

        [Fact]
        public void Delete_BookWasDeleted()
        {
            //Arrange
            var repository = new BooksRepository(database.Context);
            var bookId = 2;
            var expectedCount = 0;
            var sql = "SELECT COUNT(*) FROM book WHERE book_id=@id;";
            //Act
            repository.Delete(bookId);
            //Assert
            using (var cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", bookId);
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                Assert.Equal(expectedCount, count);
            }
        }

        [Fact]
        public void Delete_ShouldThrow_Exception()
        {
            //Arrange
            var repository = new BooksRepository(database.Context);
            var bookId = 100;

            //Act
            //Assert
            Assert.Throws<Exception>(() => repository.Delete(bookId));
        }
    }
}