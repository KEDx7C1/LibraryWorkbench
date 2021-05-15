using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class IssueDateAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "person_id",
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
                name: "person_id",
                table: "library_card",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "person_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
