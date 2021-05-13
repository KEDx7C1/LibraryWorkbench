using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

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


            modelBuilder.Entity<Models.Author>()
                .HasKey(p => p.AuthorId);
            modelBuilder.Entity<Models.Author>()
                .ToTable("author");
            modelBuilder.Entity<Models.Author>()
                .Property(p => p.AuthorId).HasColumnName("author_id");
            modelBuilder.Entity<Models.Author>()
                .Property(p => p.FirstName).HasColumnName("first_name")
                .HasMaxLength(75);
            modelBuilder.Entity<Models.Author>()
                .Property(p => p.LastName).HasColumnName("last_name")
                .HasMaxLength(75);
            modelBuilder.Entity<Models.Author>()
                .Property(p => p.MiddleName).HasColumnName("middle_name")
                .HasMaxLength(80);

            modelBuilder.Entity<Models.Book>()
                .HasKey(p => p.BookId);
            modelBuilder.Entity<Models.Book>()
                .ToTable("book");
            modelBuilder.Entity<Models.Book>()
                .Property(p => p.BookId).HasColumnName("book_id");
            modelBuilder.Entity<Models.Book>()
                .Property(p => p.Name).HasColumnName("name")
                .HasMaxLength(500);
            //modelBuilder.Entity<Models.Book>()
            //    .Property(p => p.Author).HasColumnName("author_id");

            modelBuilder.Entity<Models.Person>()
                .HasKey(p => p.PersonId);
            modelBuilder.Entity<Models.Person>()
                .ToTable("person");
            modelBuilder.Entity<Models.Person>()
                .Property(p => p.PersonId).HasColumnName("person_id");
            modelBuilder.Entity<Models.Person>()
                .Property(p => p.FirstName).HasColumnName("first_name")
                .HasMaxLength(75);
            modelBuilder.Entity<Models.Person>()
                .Property(p => p.LastName).HasColumnName("last_name")
                .HasMaxLength(75);
            modelBuilder.Entity<Models.Person>()
                .Property(p => p.MiddleName).HasColumnName("middle_name")
                .HasMaxLength(80);
            modelBuilder.Entity<Models.Person>()
                .Property(p => p.Birthday).HasColumnName("birth_date");

            modelBuilder.Entity<Models.DimGenre>()
                .HasKey(p => p.GenreId);
            modelBuilder.Entity<Models.DimGenre>()
                .ToTable("dim_genre");
            modelBuilder.Entity<Models.DimGenre>()
                .Property(p => p.GenreId).HasColumnName("genre_id");
            modelBuilder.Entity<Models.DimGenre>()
                .Property(p => p.GenreName).HasColumnName("genre_name");


            modelBuilder.Entity<Models.Book>()
                .HasMany(g => g.Genres)
                .WithMany(b => b.Books)
                .UsingEntity(j => j.ToTable("book_genre_lnk"));

            modelBuilder.Entity<Models.Book>()
                .HasMany(p => p.Persons)
                .WithMany(b => b.Books)
                .UsingEntity(j => j.ToTable("library_card"));
        }
        public DataContext(DbContextOptions<DataContext> options): base(options)
        { }
    }
}
