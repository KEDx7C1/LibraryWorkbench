using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class _005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "author",
                keyColumn: "author_id",
                keyValue: 1,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(2464), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(2479), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "author",
                keyColumn: "author_id",
                keyValue: 2,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(2514), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(2516), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "author",
                keyColumn: "author_id",
                keyValue: 3,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(2520), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(2521), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 1,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(8272), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(8284), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 2,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(8358), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(8361), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 3,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(8365), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(8366), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 4,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(8369), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(8371), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 5,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(8374), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(8376), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 1,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(4442), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(4453), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 2,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(4490), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(4492), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 3,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(4495), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(4497), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 4,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(4500), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 296, DateTimeKind.Unspecified).AddTicks(4501), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "person_id",
                keyValue: 1,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 292, DateTimeKind.Unspecified).AddTicks(2764), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 294, DateTimeKind.Unspecified).AddTicks(9204), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "person_id",
                keyValue: 2,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 294, DateTimeKind.Unspecified).AddTicks(9932), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 294, DateTimeKind.Unspecified).AddTicks(9950), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "person_id",
                keyValue: 3,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 294, DateTimeKind.Unspecified).AddTicks(9962), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 17, 0, 47, 34, 294, DateTimeKind.Unspecified).AddTicks(9965), new TimeSpan(0, 4, 0, 0, 0)), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "author",
                keyColumn: "author_id",
                keyValue: 1,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "author",
                keyColumn: "author_id",
                keyValue: 2,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "author",
                keyColumn: "author_id",
                keyValue: 3,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 1,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 2,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 3,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 4,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "book_id",
                keyValue: 5,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

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
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 3,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 4,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "person_id",
                keyValue: 1,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "person_id",
                keyValue: 2,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "person_id",
                keyValue: 3,
                columns: new[] { "creation_datetime", "updation_datetime", "version" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 });
        }
    }
}
