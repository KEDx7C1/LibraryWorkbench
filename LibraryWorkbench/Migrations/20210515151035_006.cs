using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class _006 : Migration
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
                name: "PersonId",
                table: "library_card",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "library_card",
                newName: "book_id");

            migrationBuilder.RenameIndex(
                name: "IX_library_card_PersonId",
                table: "library_card",
                newName: "IX_library_card_person_id");

            migrationBuilder.AddForeignKey(
                name: "FK_library_card_book_book_id",
                table: "library_card",
                column: "book_id",
                principalTable: "book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_library_card_person_person_id",
                table: "library_card",
                column: "person_id",
                principalTable: "person",
                principalColumn: "person_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_library_card_book_book_id",
                table: "library_card");

            migrationBuilder.DropForeignKey(
                name: "FK_library_card_person_person_id",
                table: "library_card");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "library_card",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "book_id",
                table: "library_card",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_library_card_person_id",
                table: "library_card",
                newName: "IX_library_card_PersonId");

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
