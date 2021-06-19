using LibraryWorkbench.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWorkbench.Data
{
    public interface IDataContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<DimGenre> DimGenres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}