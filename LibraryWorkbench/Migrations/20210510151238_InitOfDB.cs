using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class InitOfDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "dim_genre",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genre_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dim_genre", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.person_id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.book_id);
                    table.ForeignKey(
                        name: "FK_book_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "book_genre_lnk",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "int", nullable: false),
                    GenresGenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_genre_lnk", x => new { x.BooksBookId, x.GenresGenreId });
                    table.ForeignKey(
                        name: "FK_book_genre_lnk_book_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_genre_lnk_dim_genre_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "dim_genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "library_card",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "int", nullable: false),
                    PersonsPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_library_card", x => new { x.BooksBookId, x.PersonsPersonId });
                    table.ForeignKey(
                        name: "FK_library_card_book_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_library_card_person_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "person",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_AuthorId",
                table: "book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_book_genre_lnk_GenresGenreId",
                table: "book_genre_lnk",
                column: "GenresGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_library_card_PersonsPersonId",
                table: "library_card",
                column: "PersonsPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_genre_lnk");

            migrationBuilder.DropTable(
                name: "library_card");

            migrationBuilder.DropTable(
                name: "dim_genre");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "author");
        }
    }
}
