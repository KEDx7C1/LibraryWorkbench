using System;
using System.Linq;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.Data.Sqlite;
using Xunit;

namespace LibraryWorkbenchTests.Repositories
{
    [Collection("DatabaseCollection")]
    public class AuthorsRepositoryTests
    {
        private readonly DatabaseFixture database;

        public AuthorsRepositoryTests(DatabaseFixture fixture)
        {
            database = fixture;
        }

        [Fact]
        public void Create_ShouldReturn_Author()
        {
            //Arrange
            const int expectedCount = 1;
            var repository = new AuthorsRepository(database.Context);
            var sql = "SELECT COUNT(*) FROM author WHERE author_id=@id;";
            var author = new Author
            {
                FirstName = "FirstName",
                LastName = "LastName",
                MiddleName = "MiddleName"
            };
            //Act
            var actual = repository.Create(author);
            //Assert
            using (var cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", author.AuthorId);
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                Assert.Equal(expectedCount, count);
                Assert.IsType<Author>(actual);
            }
        }

        [Fact]
        public void Get_ShouldReturn_Author()
        {
            //Arrange
            var repository = new AuthorsRepository(database.Context);
            var authorId = 1;

            //Act
            var author = repository.Get(authorId);

            //Assert
            Assert.Equal(authorId, author.AuthorId);
        }

        [Fact]
        public void Get_ShouldThrow_Exception()
        {
            //Arrange
            var repository = new AuthorsRepository(database.Context);
            var authorId = 100;

            //Act
            //Assert
            Assert.Throws<Exception>(() => repository.Get(authorId));
        }

        [Fact]
        public void GetAll_ShouldReturn_AuthorList()
        {
            //Arrange
            int expectedCount;
            var repository = new AuthorsRepository(database.Context);
            var sql = "SELECT COUNT(*) FROM author;";
            using (var cmd = new SqliteCommand(sql, database.Connection))
            {
                expectedCount = Convert.ToInt32(cmd.ExecuteScalar());
            }

            //Act
            var authors = repository.GetAll();
            //Assert
            Assert.Equal(expectedCount, authors.Count());
        }

        [Fact]
        public void Update_ShouldReturn_Author()
        {
            //Arrange
            var repository = new AuthorsRepository(database.Context);
            var authorId = 1;
            var firstName = "ChengedFirstName";
            var sql = "SELECT first_name FROM author WHERE author_id=@id;";
            var author = repository.Get(authorId);
            author.FirstName = firstName;
            //Act
            var actual = repository.Update(author);
            //Assert
            using (var cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", author.AuthorId);
                var result = cmd.ExecuteScalar().ToString();
                Assert.Equal(result, firstName);
                Assert.IsType<Author>(actual);
            }
        }

        [Fact]
        public void Delete_AuthorWasDeleted()
        {
            //Arrange
            var repository = new AuthorsRepository(database.Context);
            var authorId = 2;
            var expectedCount = 0;
            var sql = "SELECT COUNT(*) FROM author WHERE author_id=@id;";
            //Act
            repository.Delete(authorId);
            //Assert
            using (var cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", authorId);
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                Assert.Equal(expectedCount, count);
            }
        }

        [Fact]
        public void Delete_ShouldThrow_Exception()
        {
            //Arrange
            var repository = new AuthorsRepository(database.Context);
            var authorId = 100;

            //Act
            //Assert
            Assert.Throws<Exception>(() => repository.Delete(authorId));
        }
    }
}