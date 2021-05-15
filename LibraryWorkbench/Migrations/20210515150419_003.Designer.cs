﻿// <auto-generated />
using System;
using LibraryWorkbench.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryWorkbench.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210515150419_003")]
    partial class _003
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookDimGenre", b =>
                {
                    b.Property<int>("BooksBookId")
                        .HasColumnType("int");

                    b.Property<int>("GenresGenreId")
                        .HasColumnType("int");

                    b.HasKey("BooksBookId", "GenresGenreId");

                    b.HasIndex("GenresGenreId");

                    b.ToTable("book_genre_lnk");
                });

            modelBuilder.Entity("LibraryWorkbench.Data.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("author_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("creation_datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("middle_name");

                    b.Property<DateTimeOffset>("UpdationDateTime")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("updation_datetime");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("version");

                    b.HasKey("AuthorId");

                    b.ToTable("author");
                });

            modelBuilder.Entity("LibraryWorkbench.Data.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("book_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("author_id");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("creation_datetime");

                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("genre_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset>("UpdationDateTime")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("updation_datetime");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("version");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("year");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.ToTable("book");
                });

            modelBuilder.Entity("LibraryWorkbench.Data.Models.DimGenre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("genre_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("creation_datetime");

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("genre_name");

                    b.Property<DateTimeOffset>("UpdationDateTime")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("updation_datetime");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("version");

                    b.HasKey("GenreId");

                    b.ToTable("dim_genre");
                });

            modelBuilder.Entity("LibraryWorkbench.Data.Models.LibraryCard", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssueDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("issue_date")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("BookId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("library_card");
                });

            modelBuilder.Entity("LibraryWorkbench.Data.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("person_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("creation_datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("middle_name");

                    b.Property<DateTimeOffset>("UpdationDateTime")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("updation_datetime");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("version");

                    b.HasKey("PersonId");

                    b.ToTable("person");
                });

            modelBuilder.Entity("BookDimGenre", b =>
                {
                    b.HasOne("LibraryWorkbench.Data.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryWorkbench.Data.Models.DimGenre", null)
                        .WithMany()
                        .HasForeignKey("GenresGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryWorkbench.Data.Models.Book", b =>
                {
                    b.HasOne("LibraryWorkbench.Data.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("LibraryWorkbench.Data.Models.LibraryCard", b =>
                {
                    b.HasOne("LibraryWorkbench.Data.Models.Book", "Book")
                        .WithMany("LibraryCards")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryWorkbench.Data.Models.Person", "Person")
                        .WithMany("LibraryCards")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("LibraryWorkbench.Data.Models.Book", b =>
                {
                    b.Navigation("LibraryCards");
                });

            modelBuilder.Entity("LibraryWorkbench.Data.Models.Person", b =>
                {
                    b.Navigation("LibraryCards");
                });
#pragma warning restore 612, 618
        }
    }
}
