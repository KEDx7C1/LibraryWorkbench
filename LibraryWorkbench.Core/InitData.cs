using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWorkbench.Core
{
    public class InitData
    {
        public static void InitDataBase(DataContext context)
        {
            context.Database.EnsureCreated();
            PersonsServices.CreatePerson(new Person()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                MiddleName = "Иванович",
                Birthday = new DateTime(1988, 01, 05, 00, 00, 00, 00, 00)
            }, context);
            PersonsServices.CreatePerson(new Person()
            {
                FirstName = "Петр",
                LastName = "Петров",
                MiddleName = "Петрович",
                Birthday = new DateTime(1982, 06, 10, 00, 00, 00, 00, 00)
            }, context);
            PersonsServices.CreatePerson(new Person()
            {
                FirstName = "Николай",
                LastName = "Николаев",
                MiddleName = "Николаевич",
                Birthday = new DateTime(1998, 02, 07, 00, 00, 00, 00, 00)
            }, context);
            BooksServices.CreateBook(new Book()
            {
                Author = new Author()
                {
                    FirstName = "Лев",
                    LastName = "Толстой",
                    MiddleName = "Николаевич"
                },
                Name = "Война и мир",
                Genres = new List<DimGenre>()
                { 
                    new DimGenre() {GenreName = "Роман"},
                    new DimGenre {GenreName="Военный"}
                },
                Year = 1835
            }, context);
            BooksServices.CreateBook(new Book()
            {
                Author = new Author()
                {
                    FirstName = "Лев",
                    LastName = "Толстой",
                    MiddleName = "Николаевич"
                },
                Name = "Анна Каренина",
                Genres = new List<DimGenre>()
                {
                    new DimGenre() {GenreName = "Роман"},
                    new DimGenre {GenreName="Трагедия"}
                },
                Year = 1839
            }, context);
            BooksServices.CreateBook(new Book()
            {
                Author = new Author()
                {
                    FirstName = "Джон",
                    LastName = "Толкиен",
                    MiddleName = ""
                },
                Name = "Властелин колец",
                Genres = new List<DimGenre>()
                {
                    new DimGenre() {GenreName = "Роман"},
                    new DimGenre {GenreName="Фентези"}
                },
                Year = 1955
            }, context);
            BooksServices.CreateBook(new Book()
            {
                Author = new Author()
                {
                    FirstName = "Джон",
                    LastName = "Толкиен",
                    MiddleName = ""
                },
                Name = "Хоббит",
                Genres = new List<DimGenre>()
                {
                    new DimGenre {GenreName="Фентези"}
                },
                Year = 1955
            }, context);
            BooksServices.CreateBook(new Book()
            {
                Author = new Author()
                {
                    FirstName = "Станислав",
                    LastName = "Лем",
                    MiddleName = ""
                },
                Name = "Солярис",
                Genres = new List<DimGenre>()
                {
                    new DimGenre() {GenreName = "Роман"},
                    new DimGenre {GenreName="Фантастика"}
                },
                Year = 1934
            }, context);
        }
    }
}
