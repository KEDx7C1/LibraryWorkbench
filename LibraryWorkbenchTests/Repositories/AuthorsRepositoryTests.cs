using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Linq;
using Xunit;


namespace LibraryWorkbenchTests.Repositories
{
    [Collection("DatabaseCollection")]
    public class AuthorsRepositoryTests
    {
        DatabaseFixture database;
        public AuthorsRepositoryTests(DatabaseFixture fixture)
        {
            database = fixture;
        }
        [Fact]
        public void AuthorWasCreated()
        {
            //Arrange
            const int expectedCount = 1;
            var repository = new AuthorsRepository(database.Context);
            string sql = "SELECT COUNT(*) FROM author WHERE author_id=@id;";
            Author author = new Author() { 
                FirstName = "FirstName",
                LastName = "LastName",
                MiddleName = "MiddleName"
            };
            //Act
            repository.Create(author);
            //Assert
            using (SqliteCommand cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", author.AuthorId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                Assert.Equal(expectedCount, count);
            }
        }
        [Fact]
        public void Get_ShouldReturn_Author()
        {
            //Arrange
            var repository = new AuthorsRepository(database.Context);
            int authorId = 1;

            //Act
            Author author = repository.Get(authorId);

            //Assert
            Assert.Equal(authorId, author.AuthorId);
        }
        [Fact]
        public void Get_ShouldThrow_Exception()
        {
            //Arrange
            var repository = new AuthorsRepository(database.Context);
            int authorId = 100;

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
            string sql = "SELECT COUNT(*) FROM author;";
            using (SqliteCommand cmd = new SqliteCommand(sql, database.Connection))
            {
                expectedCount = Convert.ToInt32(cmd.ExecuteScalar());

            }
            //Act
            var authors = repository.GetAll();
            //Assert
            Assert.Equal(expectedCount, authors.Count());
        }
        [Fact]
        public void AuthorWasUpdated()
        {
            //Arrange
            var repository = new AuthorsRepository(database.Context);
            int authorId = 1;
            string firstName = "ChengedFirstName";
            string sql = "SELECT first_name FROM author WHERE author_id=@id;";
            Author author = repository.Get(authorId);
            //Act
            author.FirstName = firstName;
            repository.Update(author);
            //Assert
            using (SqliteCommand cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", author.AuthorId);
                string result = cmd.ExecuteScalar().ToString();
                Assert.Equal(result, firstName);
            }
        }
        [Fact]
        public void AuthorWasDeleted()
        {
            //Arrange
            var repository = new AuthorsRepository(database.Context);
            int authorId = 2;
            int expectedCount = 0;
            string sql = "SELECT COUNT(*) FROM author WHERE author_id=@id;";
            //Act
            repository.Delete(authorId);
            //Assert
            using (SqliteCommand cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", authorId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                Assert.Equal(expectedCount, count);
            }
        }
        [Fact]
        public void Delete_ShouldThrow_Exception()
        {
            //Arrange
            var repository = new AuthorsRepository(database.Context);
            int authorId = 100;

            //Act
            //Assert
            Assert.Throws<Exception>(() => repository.Delete(authorId));
        }
    }
}
