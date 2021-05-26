using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Linq;
using Xunit;

namespace LibraryWorkbenchTests.Repositories
{
    [Collection("DatabaseCollection")]
    public class GenresRepositoryTests
    {
        DatabaseFixture database;
        public GenresRepositoryTests(DatabaseFixture fixture)
        {
            database = fixture;
        }
        [Fact]
        public void GenreWasCreated()
        {
            //Arrange
            const int expectedCount = 1;
            var repository = new GenresRepository(database.Context);
            string sql = "SELECT COUNT(*) FROM dim_genre WHERE genre_id=@id;";
            DimGenre genre = new DimGenre() { GenreName = "Роман" };
            //Act
            repository.Create(genre);
            repository.Save();
            //Assert
            using (SqliteCommand cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", genre.GenreId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                Assert.Equal(expectedCount, count);
            }
        }
        [Fact]
        public void Get_ShouldReturn_Genre()
        {
            //Arrange
            var repository = new GenresRepository(database.Context);
            int genreId = 1;

            //Act
            DimGenre genre = repository.Get(genreId);

            //Assert
            Assert.Equal(genreId, genre.GenreId);
        }
        [Fact]
        public void Get_ShouldThrow_Exception()
        {
            //Arrange
            var repository = new GenresRepository(database.Context);
            int genreId = 100;

            //Act
            //Assert
            Assert.Throws<Exception>(() => repository.Get(genreId));
        }
        [Fact]
        public void GetAll_ShouldReturn_GenreList()
        {
            //Arrange
            int expectedCount;
            var repository = new GenresRepository(database.Context);
            string sql = "SELECT COUNT(*) FROM dim_genre;";
            using (SqliteCommand cmd = new SqliteCommand(sql, database.Connection))
            {
                expectedCount = Convert.ToInt32(cmd.ExecuteScalar());
                
            }
            //Act
            var genres = repository.GetAll();
            //Assert
            Assert.Equal(expectedCount, genres.Count());
        }
        [Fact]
        public void GenreWasUpdated()
        {
            //Arrange
            var repository = new GenresRepository(database.Context);
            int genreId = 1;
            string genreName = "Пьеса";
            string sql = "SELECT genre_name FROM dim_genre WHERE genre_id=@id;";
            DimGenre genre = repository.Get(genreId);
            //Act
            genre.GenreName = genreName;
            repository.Update(genre);
            repository.Save();
            //Assert
            using (SqliteCommand cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", genre.GenreId);
                string result = cmd.ExecuteScalar().ToString();
                Assert.Equal(result, genreName);
            }
        }
        [Fact]
        public void GenreWasDeleted()
        {
            //Arrange
            var repository = new GenresRepository(database.Context);
            int genreId = 3;
            int expectedCount = 0;
            string sql = "SELECT COUNT(*) FROM dim_genre WHERE genre_id=@id;";
            //Act
            repository.Delete(genreId);
            repository.Save();
            //Assert
            using (SqliteCommand cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", genreId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                Assert.Equal(expectedCount, count);
            }
        }
        [Fact]
        public void Delete_ShouldThrow_Exception()
        {
            //Arrange
            var repository = new GenresRepository(database.Context);
            int genreId = 100;

            //Act
            //Assert
            Assert.Throws<Exception>(() => repository.Delete(genreId));
        }
    }
}
