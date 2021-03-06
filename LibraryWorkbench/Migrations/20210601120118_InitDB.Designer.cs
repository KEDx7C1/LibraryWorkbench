// <auto-generated />
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
    [Migration("20210601120118_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("version");

                    b.HasKey("AuthorId");

                    b.ToTable("author");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 462, DateTimeKind.Unspecified).AddTicks(9538), new TimeSpan(0, 4, 0, 0, 0)),
                            FirstName = "Лев",
                            LastName = "Толстой",
                            MiddleName = "Николаевич",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 462, DateTimeKind.Unspecified).AddTicks(9561), new TimeSpan(0, 4, 0, 0, 0))
                        },
                        new
                        {
                            AuthorId = 2,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 462, DateTimeKind.Unspecified).AddTicks(9604), new TimeSpan(0, 4, 0, 0, 0)),
                            FirstName = "Джон",
                            LastName = "Толкиен",
                            MiddleName = "",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 462, DateTimeKind.Unspecified).AddTicks(9607), new TimeSpan(0, 4, 0, 0, 0))
                        },
                        new
                        {
                            AuthorId = 3,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 462, DateTimeKind.Unspecified).AddTicks(9795), new TimeSpan(0, 4, 0, 0, 0)),
                            FirstName = "Станислав",
                            LastName = "Лем",
                            MiddleName = "",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 462, DateTimeKind.Unspecified).AddTicks(9799), new TimeSpan(0, 4, 0, 0, 0))
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

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
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
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6803), new TimeSpan(0, 4, 0, 0, 0)),
                            Name = "Война и мир",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6819), new TimeSpan(0, 4, 0, 0, 0)),
                            Year = 1835
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 1,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6895), new TimeSpan(0, 4, 0, 0, 0)),
                            Name = "Анна Каренина",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6898), new TimeSpan(0, 4, 0, 0, 0)),
                            Year = 1839
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 2,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6903), new TimeSpan(0, 4, 0, 0, 0)),
                            Name = "Властелин колец",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6906), new TimeSpan(0, 4, 0, 0, 0)),
                            Year = 1955
                        },
                        new
                        {
                            BookId = 4,
                            AuthorId = 2,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6910), new TimeSpan(0, 4, 0, 0, 0)),
                            Name = "Хоббит",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6913), new TimeSpan(0, 4, 0, 0, 0)),
                            Year = 1955
                        },
                        new
                        {
                            BookId = 5,
                            AuthorId = 3,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6917), new TimeSpan(0, 4, 0, 0, 0)),
                            Name = "Солярис",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6920), new TimeSpan(0, 4, 0, 0, 0)),
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("genre_name");

                    b.Property<DateTimeOffset>("UpdationDateTime")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("updation_datetime");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("version");

                    b.HasKey("GenreId");

                    b.ToTable("dim_genre");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2546), new TimeSpan(0, 4, 0, 0, 0)),
                            GenreName = "Роман",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2562), new TimeSpan(0, 4, 0, 0, 0))
                        },
                        new
                        {
                            GenreId = 2,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2625), new TimeSpan(0, 4, 0, 0, 0)),
                            GenreName = "Трагендия",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2628), new TimeSpan(0, 4, 0, 0, 0))
                        },
                        new
                        {
                            GenreId = 3,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2632), new TimeSpan(0, 4, 0, 0, 0)),
                            GenreName = "Фентези",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2635), new TimeSpan(0, 4, 0, 0, 0))
                        },
                        new
                        {
                            GenreId = 4,
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2639), new TimeSpan(0, 4, 0, 0, 0)),
                            GenreName = "Фантастика",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2641), new TimeSpan(0, 4, 0, 0, 0))
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
                            IssueDate = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(9406), new TimeSpan(0, 4, 0, 0, 0))
                        },
                        new
                        {
                            BookId = 2,
                            PersonId = 1,
                            IssueDate = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 464, DateTimeKind.Unspecified).AddTicks(215), new TimeSpan(0, 4, 0, 0, 0))
                        },
                        new
                        {
                            BookId = 5,
                            PersonId = 2,
                            IssueDate = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 464, DateTimeKind.Unspecified).AddTicks(237), new TimeSpan(0, 4, 0, 0, 0))
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

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("version");

                    b.HasKey("PersonId");

                    b.ToTable("person");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            Birthday = new DateTime(1988, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 456, DateTimeKind.Unspecified).AddTicks(8839), new TimeSpan(0, 4, 0, 0, 0)),
                            FirstName = "Иван",
                            LastName = "Иванов",
                            MiddleName = "Иванович",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 461, DateTimeKind.Unspecified).AddTicks(1672), new TimeSpan(0, 4, 0, 0, 0))
                        },
                        new
                        {
                            PersonId = 2,
                            Birthday = new DateTime(1982, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 461, DateTimeKind.Unspecified).AddTicks(2586), new TimeSpan(0, 4, 0, 0, 0)),
                            FirstName = "Петр",
                            LastName = "Петров",
                            MiddleName = "Петрович",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 461, DateTimeKind.Unspecified).AddTicks(2616), new TimeSpan(0, 4, 0, 0, 0))
                        },
                        new
                        {
                            PersonId = 3,
                            Birthday = new DateTime(1998, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 461, DateTimeKind.Unspecified).AddTicks(2629), new TimeSpan(0, 4, 0, 0, 0)),
                            FirstName = "Николай",
                            LastName = "Николаев",
                            MiddleName = "Николаевич",
                            UpdationDateTime = new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 461, DateTimeKind.Unspecified).AddTicks(2632), new TimeSpan(0, 4, 0, 0, 0))
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
