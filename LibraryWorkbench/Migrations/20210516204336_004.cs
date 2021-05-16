using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class _004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_book_genre_lnk",
                table: "book_genre_lnk");

            migrationBuilder.DropIndex(
                name: "IX_book_genre_lnk_genre_id",
                table: "book_genre_lnk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book_genre_lnk",
                table: "book_genre_lnk",
                columns: new[] { "genre_id", "book_id" });

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "author_id", "creation_datetime", "first_name", "last_name", "middle_name", "updation_datetime", "version" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Лев", "Толстой", "Николаевич", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 },
                    { 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Джон", "Толкиен", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 },
                    { 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Станислав", "Лем", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.UpdateData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 1,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 2,
                columns: new[] { "creation_datetime", "genre_name", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Трагендия", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 3,
                columns: new[] { "creation_datetime", "genre_name", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Фентези", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.InsertData(
                table: "dim_genre",
                columns: new[] { "genre_id", "creation_datetime", "genre_name", "updation_datetime", "version" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Фантастика", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "person_id", "birth_date", "creation_datetime", "first_name", "last_name", "middle_name", "updation_datetime", "version" },
                values: new object[,]
                {
                    { 1, new DateTime(1988, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Иван", "Иванов", "Иванович", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 },
                    { 2, new DateTime(1982, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Петр", "Петров", "Петрович", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 },
                    { 3, new DateTime(1998, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Николай", "Николаев", "Николаевич", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "book_id", "author_id", "creation_datetime", "name", "updation_datetime", "version", "year" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Война и мир", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 1835 },
                    { 2, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Анна Каренина", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 1839 },
                    { 3, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Властелин колец", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 1955 },
                    { 4, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Хоббит", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 1955 },
                    { 5, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Солярис", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 1934 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_genre_lnk_book_id",
                table: "book_genre_lnk",
                column: "book_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_book_genre_lnk",
                table: "book_genre_lnk");

            migrationBuilder.DropIndex(
                name: "IX_book_genre_lnk_book_id",
                table: "book_genre_lnk");

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "person_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "person_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "person_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "author_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "author_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "author_id",
                keyValue: 3);

            migrationBuilder.AddPrimaryKey(
                name: "PK_book_genre_lnk",
                table: "book_genre_lnk",
                columns: new[] { "book_id", "genre_id" });

            migrationBuilder.UpdateData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 1,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 16, 23, 58, 3, 418, DateTimeKind.Unspecified).AddTicks(4080), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 23, 58, 3, 424, DateTimeKind.Unspecified).AddTicks(5500), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 2,
                columns: new[] { "creation_datetime", "genre_name", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 16, 23, 58, 3, 424, DateTimeKind.Unspecified).AddTicks(6431), new TimeSpan(0, 4, 0, 0, 0)), "Драма", new DateTimeOffset(new DateTime(2021, 5, 16, 23, 58, 3, 424, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 3,
                columns: new[] { "creation_datetime", "genre_name", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 16, 23, 58, 3, 424, DateTimeKind.Unspecified).AddTicks(6463), new TimeSpan(0, 4, 0, 0, 0)), "Фантастика", new DateTimeOffset(new DateTime(2021, 5, 16, 23, 58, 3, 424, DateTimeKind.Unspecified).AddTicks(6466), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_book_genre_lnk_genre_id",
                table: "book_genre_lnk",
                column: "genre_id");
        }
    }
}
