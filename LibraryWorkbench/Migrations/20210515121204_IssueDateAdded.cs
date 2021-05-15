using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class IssueDateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_library_card_book_BooksBookId",
                table: "library_card");

            migrationBuilder.DropForeignKey(
                name: "FK_library_card_person_PersonsPersonId",
                table: "library_card");

            migrationBuilder.RenameColumn(
                name: "PersonsPersonId",
                table: "library_card",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "BooksBookId",
                table: "library_card",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_library_card_PersonsPersonId",
                table: "library_card",
                newName: "IX_library_card_PersonId");

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "library_card",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddForeignKey(
                name: "FK_library_card_book_BookId",
                table: "library_card",
                column: "BookId",
                principalTable: "book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_library_card_person_PersonId",
                table: "library_card",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "person_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_library_card_book_BookId",
                table: "library_card");

            migrationBuilder.DropForeignKey(
                name: "FK_library_card_person_PersonId",
                table: "library_card");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "library_card");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "library_card",
                newName: "PersonsPersonId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "library_card",
                newName: "BooksBookId");

            migrationBuilder.RenameIndex(
                name: "IX_library_card_PersonId",
                table: "library_card",
                newName: "IX_library_card_PersonsPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_library_card_book_BooksBookId",
                table: "library_card",
                column: "BooksBookId",
                principalTable: "book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_library_card_person_PersonsPersonId",
                table: "library_card",
                column: "PersonsPersonId",
                principalTable: "person",
                principalColumn: "person_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
