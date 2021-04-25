﻿using LibraryWorkbench.Aggregators;
using LibraryWorkbench.DTO;
using LibraryWorkbench.Interfaces;
using System;
using System.Collections.Generic;

namespace LibraryWorkbench.Data
{
    /// <summary>
    /// 2.0
    /// </summary>
    public class Data
    {
        public static List<IPerson> Users = new()
        {
            new PersonDTO { FirstName = "Николай", LastName = "Петров", Patronym = "Владимирович", Birthday = new DateTime(1980, 12, 1) },
            new PersonDTO { FirstName = "Владимир", LastName = "Савельев", Patronym = "Сергеевич", Birthday = new DateTime(2000, 1, 7) },
            new PersonDTO { FirstName = "Алексей", LastName = "Петров", Patronym = "Владимирович", Birthday = new DateTime(1988, 3, 28) },
            new PersonDTO { FirstName = "Владимир", LastName = "Иванов", Patronym = "Алексеевич", Birthday = new DateTime(1996, 6, 4) }
        };

        public static List<IBook> Books = new()
        {
            new BookDTO { Title = "Война и мир", Author = "Лев Николаевич Толстой", Genre = "Роман" },
            new BookDTO { Title = "Мцыри", Author = "Михаил Юрьевич Лермонтов", Genre = "Поэма" },
            new BookDTO { Title = "Анна Каренина", Author = "Лев Николаевич Толстой", Genre = "Роман" },
            new BookDTO { Title = "Божественная комедия", Author = "Данте Алигьери", Genre = "Поэма" }
        };

        public static List<ReadingPersonAggregator> ReadingUsers = new();
        
    }
}
