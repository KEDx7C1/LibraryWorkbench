using System;
using System.Collections.Generic;
using LibraryWorkbench.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWorkbench.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<DimGenre> DimGenres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(
                j =>
                {
                    j.HasKey(p => p.AuthorId);
                    j.ToTable("author");
                }
            );

            modelBuilder.Entity<Book>(
                j =>
                {
                    j.HasKey(p => p.BookId);
                    j.ToTable("book");
                    j.HasOne(p => p.Author);
                }
            );

            modelBuilder.Entity<Person>(
                j =>
                {
                    j.HasKey(p => p.PersonId);
                    j.ToTable("person");
                }
            );

            modelBuilder.Entity<DimGenre>(
                j =>
                {
                    j.HasKey(p => p.GenreId);
                    j.ToTable("dim_genre");
                }
            );

            modelBuilder.Entity<Book>()
                .HasMany(g => g.Genres)
                .WithMany(b => b.Books)
                .UsingEntity<Dictionary<string, object>>
                ("book_genre_lnk",
                    g => g.HasOne<DimGenre>().WithMany()
                        .HasForeignKey("genre_id"),
                    b => b.HasOne<Book>().WithMany()
                        .HasForeignKey("book_id"),
                    j =>
                    {
                        j.HasKey("genre_id", "book_id");
                        j.ToTable("book_genre_lnk");
                    });

            modelBuilder.Entity<Book>()
                .HasMany(c => c.Persons)
                .WithMany(s => s.Books)
                .UsingEntity<LibraryCard>
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
                        j.HasKey(t => new {t.BookId, t.PersonId});
                        j.ToTable("library_card");
                    }
                );

            #region "Initial Data"

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 1,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    MiddleName = "Иванович",
                    Birthday = new DateTime(1988, 01, 05, 00, 00, 00, 00, 00),
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                },
                new Person
                {
                    PersonId = 2,
                    FirstName = "Петр",
                    LastName = "Петров",
                    MiddleName = "Петрович",
                    Birthday = new DateTime(1982, 06, 10, 00, 00, 00, 00, 00),
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                },
                new Person
                {
                    PersonId = 3,
                    FirstName = "Николай",
                    LastName = "Николаев",
                    MiddleName = "Николаевич",
                    Birthday = new DateTime(1998, 02, 07, 00, 00, 00, 00, 00),
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                });
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    AuthorId = 1,
                    FirstName = "Лев",
                    LastName = "Толстой",
                    MiddleName = "Николаевич",
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                },
                new Author
                {
                    AuthorId = 2,
                    FirstName = "Джон",
                    LastName = "Толкиен",
                    MiddleName = "",
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                },
                new Author
                {
                    AuthorId = 3,
                    FirstName = "Станислав",
                    LastName = "Лем",
                    MiddleName = "",
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                });
            modelBuilder.Entity<DimGenre>().HasData(
                new DimGenre
                {
                    GenreId = 1,
                    GenreName = "Роман",
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                },
                new DimGenre
                {
                    GenreId = 2,
                    GenreName = "Трагендия",
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                },
                new DimGenre
                {
                    GenreId = 3,
                    GenreName = "Фентези",
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                },
                new DimGenre
                {
                    GenreId = 4,
                    GenreName = "Фантастика",
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                });

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    AuthorId = 1,
                    Name = "Война и мир",
                    Year = 1835,
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                },
                new Book
                {
                    BookId = 2,
                    AuthorId = 1,
                    Name = "Анна Каренина",
                    Year = 1839,
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                },
                new Book
                {
                    BookId = 3,
                    AuthorId = 2,
                    Name = "Властелин колец",
                    Year = 1955,
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                },
                new Book
                {
                    BookId = 4,
                    AuthorId = 2,
                    Name = "Хоббит",
                    Year = 1955,
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                },
                new Book
                {
                    BookId = 5,
                    AuthorId = 3,
                    Name = "Солярис",
                    Year = 1934,
                    CreationDateTime = DateTimeOffset.Now,
                    UpdationDateTime = DateTimeOffset.Now
                });

            modelBuilder.Entity<LibraryCard>().HasData(
                new LibraryCard {BookId = 1, PersonId = 1, IssueDate = DateTimeOffset.Now},
                new LibraryCard {BookId = 2, PersonId = 1, IssueDate = DateTimeOffset.Now},
                new LibraryCard {BookId = 5, PersonId = 2, IssueDate = DateTimeOffset.Now}
            );

            #endregion
        }
    }
}