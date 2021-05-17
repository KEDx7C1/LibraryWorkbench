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
                    version = table.Column<int>(type: "int", nullable: false),
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
                    genre_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_datetime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updation_datetime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    version = table.Column<int>(type: "int", nullable: false)
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
                    version = table.Column<int>(type: "int", nullable: false),
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
                    year = table.Column<int>(type: "int", nullable: false),
                    creation_datetime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updation_datetime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    version = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author_id = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "author_id", "creation_datetime", "first_name", "last_name", "middle_name", "updation_datetime", "version" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(6258), new TimeSpan(0, 4, 0, 0, 0)), "Лев", "Толстой", "Николаевич", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(6272), new TimeSpan(0, 4, 0, 0, 0)), 1 },
                    { 2, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(6303), new TimeSpan(0, 4, 0, 0, 0)), "Джон", "Толкиен", "", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(6305), new TimeSpan(0, 4, 0, 0, 0)), 1 },
                    { 3, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(6308), new TimeSpan(0, 4, 0, 0, 0)), "Станислав", "Лем", "", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(6309), new TimeSpan(0, 4, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "dim_genre",
                columns: new[] { "genre_id", "creation_datetime", "genre_name", "updation_datetime", "version" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8046), new TimeSpan(0, 4, 0, 0, 0)), "Роман", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8055), new TimeSpan(0, 4, 0, 0, 0)), 1 },
                    { 2, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8089), new TimeSpan(0, 4, 0, 0, 0)), "Трагендия", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8091), new TimeSpan(0, 4, 0, 0, 0)), 1 },
                    { 3, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8093), new TimeSpan(0, 4, 0, 0, 0)), "Фентези", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8094), new TimeSpan(0, 4, 0, 0, 0)), 1 },
                    { 4, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8097), new TimeSpan(0, 4, 0, 0, 0)), "Фантастика", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 43, DateTimeKind.Unspecified).AddTicks(8098), new TimeSpan(0, 4, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "person_id", "birth_date", "creation_datetime", "first_name", "last_name", "middle_name", "updation_datetime", "version" },
                values: new object[,]
                {
                    { 1, new DateTime(1988, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 39, DateTimeKind.Unspecified).AddTicks(1542), new TimeSpan(0, 4, 0, 0, 0)), "Иван", "Иванов", "Иванович", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 42, DateTimeKind.Unspecified).AddTicks(4878), new TimeSpan(0, 4, 0, 0, 0)), 1 },
                    { 2, new DateTime(1982, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 42, DateTimeKind.Unspecified).AddTicks(5527), new TimeSpan(0, 4, 0, 0, 0)), "Петр", "Петров", "Петрович", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 42, DateTimeKind.Unspecified).AddTicks(5541), new TimeSpan(0, 4, 0, 0, 0)), 1 },
                    { 3, new DateTime(1998, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 42, DateTimeKind.Unspecified).AddTicks(5553), new TimeSpan(0, 4, 0, 0, 0)), "Николай", "Николаев", "Николаевич", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 42, DateTimeKind.Unspecified).AddTicks(5555), new TimeSpan(0, 4, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "book_id", "author_id", "creation_datetime", "name", "updation_datetime", "version", "year" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1234), new TimeSpan(0, 4, 0, 0, 0)), "Война и мир", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1244), new TimeSpan(0, 4, 0, 0, 0)), 1, 1835 },
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1307), new TimeSpan(0, 4, 0, 0, 0)), "Анна Каренина", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1309), new TimeSpan(0, 4, 0, 0, 0)), 1, 1839 },
                    { 3, 2, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1313), new TimeSpan(0, 4, 0, 0, 0)), "Властелин колец", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1314), new TimeSpan(0, 4, 0, 0, 0)), 1, 1955 },
                    { 4, 2, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1317), new TimeSpan(0, 4, 0, 0, 0)), "Хоббит", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1319), new TimeSpan(0, 4, 0, 0, 0)), 1, 1955 },
                    { 5, 3, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1322), new TimeSpan(0, 4, 0, 0, 0)), "Солярис", new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(1323), new TimeSpan(0, 4, 0, 0, 0)), 1, 1934 }
                });

            migrationBuilder.InsertData(
                table: "library_card",
                columns: new[] { "book_id", "person_id", "issue_date" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(2728), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "library_card",
                columns: new[] { "book_id", "person_id", "issue_date" },
                values: new object[] { 2, 1, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(3245), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "library_card",
                columns: new[] { "book_id", "person_id", "issue_date" },
                values: new object[] { 5, 2, new DateTimeOffset(new DateTime(2021, 5, 17, 7, 33, 13, 44, DateTimeKind.Unspecified).AddTicks(3259), new TimeSpan(0, 4, 0, 0, 0)) });

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

            migrationBuilder.Sql(@"INSERT INTO book_genre_lnk (genre_id, book_id) VALUES (1, 1), (1, 2), (3, 3), (1, 3), (3, 4), (4, 5)");
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
