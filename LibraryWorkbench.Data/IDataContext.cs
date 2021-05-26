using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace LibraryWorkbench.Data
{
    public interface IDataContext
    {
        public DbSet<Models.Person> Persons { get; set; }
        public DbSet<Models.DimGenre> DimGenres { get; set; }
        public DbSet<Models.Author> Authors { get; set; }
        public DbSet<Models.Book> Books { get; set; }
    }
}
