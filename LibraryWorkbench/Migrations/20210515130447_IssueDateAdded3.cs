using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class IssueDateAdded3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "book_id",
                table: "library_card");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "person",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "UpdationDateTime",
                table: "person",
                newName: "updation_datetime");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "person",
                newName: "creation_datetime");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "dim_genre",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "UpdationDateTime",
                table: "dim_genre",
                newName: "updation_datetime");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "dim_genre",
                newName: "creation_datetime");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "book",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "UpdationDateTime",
                table: "book",
                newName: "updation_datetime");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "book",
                newName: "creation_datetime");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "author",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "UpdationDateTime",
                table: "author",
                newName: "updation_datetime");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "author",
                newName: "creation_datetime");

            migrationBuilder.AddForeignKey(
                name: "FK_library_card_book_book_id",
                table: "library_card",
                column: "book_id",
                principalTable: "book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_library_card_book_book_id",
                table: "library_card");

            migrationBuilder.RenameColumn(
                name: "version",
                table: "person",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "updation_datetime",
                table: "person",
                newName: "UpdationDateTime");

            migrationBuilder.RenameColumn(
                name: "creation_datetime",
                table: "person",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "version",
                table: "dim_genre",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "updation_datetime",
                table: "dim_genre",
                newName: "UpdationDateTime");

            migrationBuilder.RenameColumn(
                name: "creation_datetime",
                table: "dim_genre",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "version",
                table: "book",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "updation_datetime",
                table: "book",
                newName: "UpdationDateTime");

            migrationBuilder.RenameColumn(
                name: "creation_datetime",
                table: "book",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "version",
                table: "author",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "updation_datetime",
                table: "author",
                newName: "UpdationDateTime");

            migrationBuilder.RenameColumn(
                name: "creation_datetime",
                table: "author",
                newName: "CreationDateTime");

            migrationBuilder.AddForeignKey(
                name: "book_id",
                table: "library_card",
                column: "book_id",
                principalTable: "book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
