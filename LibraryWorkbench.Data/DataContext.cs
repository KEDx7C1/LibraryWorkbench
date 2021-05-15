using Microsoft.EntityFrameworkCore;

namespace LibraryWorkbench.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Models.Person> Persons { get; set; }
        public DbSet<Models.DimGenre> DimGenres { get; set; }
        public DbSet<Models.Author> Authors { get; set; }
        public DbSet<Models.Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Models.Author>(
                j =>
                {
                    j.HasKey(p => p.AuthorId);
                    j.ToTable("author");
                }
                );

            modelBuilder.Entity<Models.Book>(
                j =>
                {
                    j.HasKey(p => p.BookId);
                    j.ToTable("book");
                    j.HasOne(p => p.Author);
                }
                );

            modelBuilder.Entity<Models.Person>(
                j =>
                {
                    j.HasKey(p => p.PersonId);
                    j.ToTable("person");
                }
                );

            modelBuilder.Entity<Models.DimGenre>(
                j =>
                {
                    j.HasKey(p => p.GenreId);
                    j.ToTable("dim_genre");
                }
                );

            modelBuilder.Entity<Models.Book>()
                .HasMany(g => g.Genres)
                .WithMany(b => b.Books)
                .UsingEntity(j => j.ToTable("book_genre_lnk"));

            modelBuilder.Entity<Models.Book>()
                .HasMany(c => c.Persons)
                .WithMany(s => s.Books)
                .UsingEntity<Models.LibraryCard>
                (
                    j => j
                    .HasOne(pt => pt.Person)
                    .WithMany(t => t.LibraryCards)
                    .HasForeignKey(pt => pt.PersonId),
                    j => j
                    .HasOne(pt => pt.Book)
                    .WithMany(p => p.LibraryCards)
                    .HasForeignKey(pt => pt.BookId),
                    j =>
                    {
                        j.Property(pt => pt.IssueDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                        j.HasKey(t => new { t.BookId, t.PersonId });
                        j.ToTable("library_card");
                    }
                );
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
    }
}
