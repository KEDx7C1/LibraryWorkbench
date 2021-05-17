﻿// <auto-generated />
using System;
using LibraryWorkbench.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryWorkbench.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(6258), new TimeSpan(0, 4, 0, 0, 0)),
                            FirstName = "Лев",
                            LastName = "Толстой",
                            MiddleName = "Николаевич",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(6272), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1
                        },
                        new
                        {
                            AuthorId = 2,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(6303), new TimeSpan(0, 4, 0, 0, 0)),
                            FirstName = "Джон",
                            LastName = "Толкиен",
                            MiddleName = "",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(6305), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1
                        },
                        new
                        {
                            AuthorId = 3,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(6308), new TimeSpan(0, 4, 0, 0, 0)),
                            FirstName = "Станислав",
                            LastName = "Лем",
                            MiddleName = "",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(6309), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1
                        });
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

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1234), new TimeSpan(0, 4, 0, 0, 0)),
                            Name = "Война и мир",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1244), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1,
                            Year = 1835
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 1,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1307), new TimeSpan(0, 4, 0, 0, 0)),
                            Name = "Анна Каренина",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1309), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1,
                            Year = 1839
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 2,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1313), new TimeSpan(0, 4, 0, 0, 0)),
                            Name = "Властелин колец",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1314), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1,
                            Year = 1955
                        },
                        new
                        {
                            BookId = 4,
                            AuthorId = 2,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1317), new TimeSpan(0, 4, 0, 0, 0)),
                            Name = "Хоббит",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1319), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1,
                            Year = 1955
                        },
                        new
                        {
                            BookId = 5,
                            AuthorId = 3,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1322), new TimeSpan(0, 4, 0, 0, 0)),
                            Name = "Солярис",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1323), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1,
                            Year = 1934
                        });
                });

            modelBuilder.Entity("LibraryWorkbench.Data.Models.DimGenre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("genre_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8046), new TimeSpan(0, 4, 0, 0, 0)),
                            GenreName = "Роман",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8055), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1
                        },
                        new
                        {
                            GenreId = 2,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8089), new TimeSpan(0, 4, 0, 0, 0)),
                            GenreName = "Трагендия",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8091), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1
                        },
                        new
                        {
                            GenreId = 3,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8093), new TimeSpan(0, 4, 0, 0, 0)),
                            GenreName = "Фентези",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8094), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1
                        },
                        new
                        {
                            GenreId = 4,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8097), new TimeSpan(0, 4, 0, 0, 0)),
                            GenreName = "Фантастика",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8098), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1
                        });
                });

            modelBuilder.Entity("LibraryWorkbench.Data.Models.LibraryCard", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("person_id");

                    b.Property<DateTimeOffset>("IssueDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("issue_date")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("BookId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("library_card");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            PersonId = 1,
                            IssueDate = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(2728), new TimeSpan(0, 4, 0, 0, 0))
                        },
                        new
                        {
                            BookId = 2,
                            PersonId = 1,
                            IssueDate = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(3245), new TimeSpan(0, 4, 0, 0, 0))
                        },
                        new
                        {
                            BookId = 5,
                            PersonId = 2,
                            IssueDate = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(3259), new TimeSpan(0, 4, 0, 0, 0))
                        });
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

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            Birthday = new DateTime(1988, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 39, DateTimeKind.Unspecified).AddTicks(1542), new TimeSpan(0, 4, 0, 0, 0)),
                            FirstName = "Иван",
                            LastName = "Иванов",
                            MiddleName = "Иванович",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 42, DateTimeKind.Unspecified).AddTicks(4878), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1
                        },
                        new
                        {
                            PersonId = 2,
                            Birthday = new DateTime(1982, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 42, DateTimeKind.Unspecified).AddTicks(5527), new TimeSpan(0, 4, 0, 0, 0)),
                            FirstName = "Петр",
                            LastName = "Петров",
                            MiddleName = "Петрович",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 42, DateTimeKind.Unspecified).AddTicks(5541), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1
                        },
                        new
                        {
                            PersonId = 3,
                            Birthday = new DateTime(1998, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 42, DateTimeKind.Unspecified).AddTicks(5553), new TimeSpan(0, 4, 0, 0, 0)),
                            FirstName = "Николай",
                            LastName = "Николаев",
                            MiddleName = "Николаевич",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 42, DateTimeKind.Unspecified).AddTicks(5555), new TimeSpan(0, 4, 0, 0, 0)),
                            Version = 1
                        });
                });

            modelBuilder.Entity("book_genre_lnk", b =>
                {
                    b.Property<int>("genre_id")
                        .HasColumnType("int");

                    b.Property<int>("book_id")
                        .HasColumnType("int");

                    b.HasKey("genre_id", "book_id");

                    b.HasIndex("book_id");

                    b.ToTable("book_genre_lnk");
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

            modelBuilder.Entity("book_genre_lnk", b =>
                {
                    b.HasOne("LibraryWorkbench.Data.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("book_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryWorkbench.Data.Models.DimGenre", null)
                        .WithMany()
                        .HasForeignKey("genre_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
