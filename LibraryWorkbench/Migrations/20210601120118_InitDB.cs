using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creation_datetime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updation_datetime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    genre_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creation_datetime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updation_datetime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
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
                    creation_datetime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updation_datetime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    creation_datetime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updation_datetime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.book_id);
                    table.ForeignKey(
                        name: "FK_book_author_author_id",
                        column: x => x.author_id,
                        principalTable: "author",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_genre_lnk",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_genre_lnk", x => new { x.genre_id, x.book_id });
                    table.ForeignKey(
                        name: "FK_book_genre_lnk_book_book_id",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_genre_lnk_dim_genre_genre_id",
                        column: x => x.genre_id,
                        principalTable: "dim_genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "library_card",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    issue_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_library_card", x => new { x.book_id, x.person_id });
                    table.ForeignKey(
                        name: "FK_library_card_book_book_id",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_library_card_person_person_id",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "author_id", "creation_datetime", "first_name", "last_name", "middle_name", "updation_datetime" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 462, DateTimeKind.Unspecified).AddTicks(9538), new TimeSpan(0, 4, 0, 0, 0)), "Лев", "Толстой", "Николаевич", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 462, DateTimeKind.Unspecified).AddTicks(9561), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 462, DateTimeKind.Unspecified).AddTicks(9604), new TimeSpan(0, 4, 0, 0, 0)), "Джон", "Толкиен", "", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 462, DateTimeKind.Unspecified).AddTicks(9607), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 462, DateTimeKind.Unspecified).AddTicks(9795), new TimeSpan(0, 4, 0, 0, 0)), "Станислав", "Лем", "", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 462, DateTimeKind.Unspecified).AddTicks(9799), new TimeSpan(0, 4, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "dim_genre",
                columns: new[] { "genre_id", "creation_datetime", "genre_name", "updation_datetime" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2546), new TimeSpan(0, 4, 0, 0, 0)), "Роман", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2562), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2625), new TimeSpan(0, 4, 0, 0, 0)), "Трагендия", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2628), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2632), new TimeSpan(0, 4, 0, 0, 0)), "Фентези", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2635), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 4, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2639), new TimeSpan(0, 4, 0, 0, 0)), "Фантастика", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(2641), new TimeSpan(0, 4, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "person_id", "birth_date", "creation_datetime", "first_name", "last_name", "middle_name", "updation_datetime" },
                values: new object[,]
                {
                    { 1, new DateTime(1988, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 456, DateTimeKind.Unspecified).AddTicks(8839), new TimeSpan(0, 4, 0, 0, 0)), "Иван", "Иванов", "Иванович", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 461, DateTimeKind.Unspecified).AddTicks(1672), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 2, new DateTime(1982, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 461, DateTimeKind.Unspecified).AddTicks(2586), new TimeSpan(0, 4, 0, 0, 0)), "Петр", "Петров", "Петрович", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 461, DateTimeKind.Unspecified).AddTicks(2616), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 3, new DateTime(1998, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 461, DateTimeKind.Unspecified).AddTicks(2629), new TimeSpan(0, 4, 0, 0, 0)), "Николай", "Николаев", "Николаевич", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 461, DateTimeKind.Unspecified).AddTicks(2632), new TimeSpan(0, 4, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "book_id", "author_id", "creation_datetime", "name", "updation_datetime", "year" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6803), new TimeSpan(0, 4, 0, 0, 0)), "Война и мир", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6819), new TimeSpan(0, 4, 0, 0, 0)), 1835 },
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6895), new TimeSpan(0, 4, 0, 0, 0)), "Анна Каренина", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6898), new TimeSpan(0, 4, 0, 0, 0)), 1839 },
                    { 3, 2, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6903), new TimeSpan(0, 4, 0, 0, 0)), "Властелин колец", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6906), new TimeSpan(0, 4, 0, 0, 0)), 1955 },
                    { 4, 2, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6910), new TimeSpan(0, 4, 0, 0, 0)), "Хоббит", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6913), new TimeSpan(0, 4, 0, 0, 0)), 1955 },
                    { 5, 3, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6917), new TimeSpan(0, 4, 0, 0, 0)), "Солярис", new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(6920), new TimeSpan(0, 4, 0, 0, 0)), 1934 }
                });

            migrationBuilder.InsertData(
                table: "library_card",
                columns: new[] { "book_id", "person_id", "issue_date" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 463, DateTimeKind.Unspecified).AddTicks(9406), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "library_card",
                columns: new[] { "book_id", "person_id", "issue_date" },
                values: new object[] { 2, 1, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 464, DateTimeKind.Unspecified).AddTicks(215), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "library_card",
                columns: new[] { "book_id", "person_id", "issue_date" },
                values: new object[] { 5, 2, new DateTimeOffset(new DateTime(2021, 6, 1, 16, 1, 17, 464, DateTimeKind.Unspecified).AddTicks(237), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_book_author_id",
                table: "book",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_genre_lnk_book_id",
                table: "book_genre_lnk",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_library_card_person_id",
                table: "library_card",
                column: "person_id");

            migrationBuilder
                .Sql(@"INSERT INTO book_genre_lnk (genre_id, book_id) VALUES (1, 1), (1, 2), (3, 3), (1, 3), (3, 4), (4, 5)");
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
