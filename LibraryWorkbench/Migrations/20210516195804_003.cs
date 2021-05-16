using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "dim_genre",
                columns: new[] { "genre_id", "creation_datetime", "genre_name", "updation_datetime", "version" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2021, 5, 16, 23, 58, 3, 418, DateTimeKind.Unspecified).AddTicks(4080), new TimeSpan(0, 4, 0, 0, 0)), "Роман", new DateTimeOffset(new DateTime(2021, 5, 16, 23, 58, 3, 424, DateTimeKind.Unspecified).AddTicks(5500), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.InsertData(
                table: "dim_genre",
                columns: new[] { "genre_id", "creation_datetime", "genre_name", "updation_datetime", "version" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2021, 5, 16, 23, 58, 3, 424, DateTimeKind.Unspecified).AddTicks(6431), new TimeSpan(0, 4, 0, 0, 0)), "Драма", new DateTimeOffset(new DateTime(2021, 5, 16, 23, 58, 3, 424, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 4, 0, 0, 0)), 1 });

            migrationBuilder.InsertData(
                table: "dim_genre",
                columns: new[] { "genre_id", "creation_datetime", "genre_name", "updation_datetime", "version" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2021, 5, 16, 23, 58, 3, 424, DateTimeKind.Unspecified).AddTicks(6463), new TimeSpan(0, 4, 0, 0, 0)), "Фантастика", new DateTimeOffset(new DateTime(2021, 5, 16, 23, 58, 3, 424, DateTimeKind.Unspecified).AddTicks(6466), new TimeSpan(0, 4, 0, 0, 0)), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "dim_genre",
                keyColumn: "genre_id",
                keyValue: 3);
        }
    }
}
