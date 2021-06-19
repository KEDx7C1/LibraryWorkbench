using System;
using System.Linq;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.Data.Sqlite;
using Xunit;

namespace LibraryWorkbenchTests.Repositories
{
    [Collection("DatabaseCollection")]
    public class GenresRepositoryTests
    {
        private readonly DatabaseFixture database;

        public GenresRepositoryTests(DatabaseFixture fixture)
        {
            database = fixture;
        }

        [Fact]
        public void Create_ShoulReturn_DimGenre()
        {
            //Arrange
            const int expectedCount = 1;
            var repository = new GenresRepository(database.Context);
            var sql = "SELECT COUNT(*) FROM dim_genre WHERE genre_id=@id;";
            var genre = new DimGenre {GenreName = "Роман"};
            //Act
            var actual = repository.Create(genre);
            //Assert
            using (var cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", genre.GenreId);
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                Assert.Equal(expectedCount, count);
                Assert.IsType<DimGenre>(actual);
            }
        }

        [Fact]
        public void Get_ShouldReturn_DimGenre()
        {
            //Arrange
            var repository = new GenresRepository(database.Context);
            var genreId = 1;

            //Act
            var genre = repository.Get(genreId);

            //Assert
            Assert.Equal(genreId, genre.GenreId);
        }

        [Fact]
        public void Get_ShouldThrow_Exception()
        {
            //Arrange
            var repository = new GenresRepository(database.Context);
            var genreId = 100;

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
            var sql = "SELECT COUNT(*) FROM dim_genre;";
            using (var cmd = new SqliteCommand(sql, database.Connection))
            {
                expectedCount = Convert.ToInt32(cmd.ExecuteScalar());
            }

            //Act
            var genres = repository.GetAll();
            //Assert
            Assert.Equal(expectedCount, genres.Count());
        }

        [Fact]
        public void Update_ShouldRetunr_DimGenre()
        {
            //Arrange
            var repository = new GenresRepository(database.Context);
            var genreId = 1;
            var genreName = "Пьеса";
            var sql = "SELECT genre_name FROM dim_genre WHERE genre_id=@id;";
            var genre = repository.Get(genreId);
            //Act
            genre.GenreName = genreName;
            var actual = repository.Update(genre);
            //Assert
            using (var cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", genre.GenreId);
                var result = cmd.ExecuteScalar().ToString();
                Assert.Equal(result, genreName);
                Assert.IsType<DimGenre>(actual);
            }
        }

        [Fact]
        public void Delete_GenreWasDeleted()
        {
            //Arrange
            var repository = new GenresRepository(database.Context);
            var genreId = 3;
            var expectedCount = 0;
            var sql = "SELECT COUNT(*) FROM dim_genre WHERE genre_id=@id;";
            //Act
            repository.Delete(genreId);
            //Assert
            using (var cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", genreId);
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                Assert.Equal(expectedCount, count);
            }
        }

        [Fact]
        public void Delete_ShouldThrow_Exception()
        {
            //Arrange
            var repository = new GenresRepository(database.Context);
            var genreId = 100;

            //Act
            //Assert
            Assert.Throws<Exception>(() => repository.Delete(genreId));
        }
    }
}