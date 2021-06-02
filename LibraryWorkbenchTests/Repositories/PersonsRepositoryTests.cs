using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Linq;
using Xunit;

namespace LibraryWorkbenchTests.Repositories
{
    [Collection("DatabaseCollection")]
    public class PersonsRepositoryTests
    {
        DatabaseFixture database;
        public PersonsRepositoryTests(DatabaseFixture fixture)
        {
            database = fixture;
        }
        [Fact]
        public void Create_ShouldReturn_Person()
        {
            //Arrange
            const int expectedCount = 1;
            var repository = new PersonsRepository(database.Context);
            string sql = "SELECT COUNT(*) FROM person WHERE person_id=@id;";
            Person person = new Person()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                MiddleName = "MiddleName"
            };
            //Act
            var actual = repository.Create(person);
            //Assert
            using (SqliteCommand cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", person.PersonId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                Assert.Equal(expectedCount, count);
                Assert.IsType<Person>(actual);
            }
        }
        [Fact]
        public void Get_ShouldReturn_Person()
        {
            //Arrange
            var repository = new PersonsRepository(database.Context);
            int personId = 1;

            //Act
            Person person = repository.Get(personId);

            //Assert
            Assert.Equal(personId, person.PersonId);
        }
        [Fact]
        public void Get_ShouldThrow_Exception()
        {
            //Arrange
            var repository = new PersonsRepository(database.Context);
            int personId = 100;

            //Act
            //Assert
            Assert.Throws<Exception>(() => repository.Get(personId));
        }
        [Fact]
        public void GetAll_ShouldReturn_PersonList()
        {
            //Arrange
            int expectedCount;
            var repository = new PersonsRepository(database.Context);
            string sql = "SELECT COUNT(*) FROM person;";
            using (SqliteCommand cmd = new SqliteCommand(sql, database.Connection))
            {
                expectedCount = Convert.ToInt32(cmd.ExecuteScalar());

            }
            //Act
            var persons = repository.GetAll();
            //Assert
            Assert.Equal(expectedCount, persons.Count());
        }
        [Fact]
        public void PersonWasUpdated()
        {
            //Arrange
            var repository = new PersonsRepository(database.Context);
            int personId = 1;
            string firstName = "ChangedFirstName";
            string sql = "SELECT first_name FROM person WHERE person_id=@id;";
            Person person = repository.Get(personId);
            //Act
            person.FirstName = firstName;
            repository.Update(person);
            //Assert
            using (SqliteCommand cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", person.PersonId);
                string actual = cmd.ExecuteScalar().ToString();
                Assert.Equal(firstName, actual);
            }
        }
        [Fact]
        public void Delete_PersonWasDeleted()
        {
            //Arrange
            var repository = new PersonsRepository(database.Context);
            int personId = 2;
            int expectedCount = 0;
            string sql = "SELECT COUNT(*) FROM person WHERE person_id=@id;";
            //Act
            repository.Delete(personId);
            //Assert
            using (SqliteCommand cmd = new SqliteCommand(sql, database.Connection))
            {
                cmd.Parameters.AddWithValue("@id", personId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                Assert.Equal(expectedCount, count);
            }
        }
        [Fact]
        public void Delete_ShouldThrow_Exception()
        {
            //Arrange
            var repository = new PersonsRepository(database.Context);
            int personId = 100;

            //Act
            //Assert
            Assert.Throws<Exception>(() => repository.Delete(personId));
        }
    }
}
