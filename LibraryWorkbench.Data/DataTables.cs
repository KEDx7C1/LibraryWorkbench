using LibraryWorkbench.Data.Models.Interfaces;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;

namespace LibraryWorkbench.DataTables
{
    public class DataTables
    {
        /// <summary>
        /// 2.0.2
        /// </summary>
        public static List<IPerson> Persons = new List<IPerson>()
        {
            new Person { FirstName = "Николай", LastName = "Петров", Patronym = "Владимирович", Birthday = new DateTime(1980, 12, 1) },
            new Person { FirstName = "Владимир", LastName = "Савельев", Patronym = "Сергеевич", Birthday = new DateTime(2000, 1, 7) },
            new Person { FirstName = "Алексей", LastName = "Петров", Patronym = "Владимирович", Birthday = new DateTime(1988, 3, 28) },
            new Person { FirstName = "Владимир", LastName = "Иванов", Patronym = "Алексеевич", Birthday = new DateTime(1996, 6, 4) }
        };
        /// <summary>
        /// 2.0.2
        /// </summary>
        public static List<IBook> Books = new List<IBook>()
        {
            new Book { Title = "Война и мир", Author = "Лев Николаевич Толстой", Genre = "Роман" },
            new Book { Title = "Мцыри", Author = "Михаил Юрьевич Лермонтов", Genre = "Поэма" },
            new Book { Title = "Анна Каренина", Author = "Лев Николаевич Толстой", Genre = "Роман" },
            new Book { Title = "Божественная комедия", Author = "Данте Алигьери", Genre = "Поэма" }
        };
        /// <summary>
        /// 2.1.3
        /// </summary>
        public static List<ReadingPerson> ReadingPersons = new List<ReadingPerson>();
        
    }
}
