using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class IssueDateAdded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_library_card_book_BookId",
                table: "library_card");

            migrationBuilder.DropForeignKey(
                name: "FK_library_card_person_PersonId",
                table: "library_card");

            migrationBuilder.RenameColumn(
                name: "IssueDate",
                table: "library_card",
                newName: "issue_date");

            migrationBuilder.AddForeignKey(
                name: "book_id",
                table: "library_card",
                column: "BookId",
                principalTable: "book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "person_id",
                table: "library_card",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "person_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "book_id",
                table: "library_card");

            migrationBuilder.DropForeignKey(
                name: "person_id",
                table: "library_card");

            migrationBuilder.RenameColumn(
                name: "issue_date",
                table: "library_card",
                newName: "IssueDate");

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
    }
}
