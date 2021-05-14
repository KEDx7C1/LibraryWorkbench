using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class DateTimeColumnsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDateTime",
                table: "person",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdationDateTime",
                table: "person",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDateTime",
                table: "dim_genre",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdationDateTime",
                table: "dim_genre",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "dim_genre",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDateTime",
                table: "author",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdationDateTime",
                table: "author",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "author",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "person");

            migrationBuilder.DropColumn(
                name: "UpdationDateTime",
                table: "person");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "person");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "dim_genre");

            migrationBuilder.DropColumn(
                name: "UpdationDateTime",
                table: "dim_genre");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "dim_genre");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "author");

            migrationBuilder.DropColumn(
                name: "UpdationDateTime",
                table: "author");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "author");
        }
    }
}
