using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_author_AuthorId",
                table: "book");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "book",
                newName: "author_id");

            migrationBuilder.RenameIndex(
                name: "IX_book_AuthorId",
                table: "book",
                newName: "IX_book_author_id");

            migrationBuilder.AlterColumn<int>(
                name: "author_id",
                table: "book",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_book_author_author_id",
                table: "book",
                column: "author_id",
                principalTable: "author",
                principalColumn: "author_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_author_author_id",
                table: "book");

            migrationBuilder.RenameColumn(
                name: "author_id",
                table: "book",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_book_author_id",
                table: "book",
                newName: "IX_book_AuthorId");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "book",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_book_author_AuthorId",
                table: "book",
                column: "AuthorId",
                principalTable: "author",
                principalColumn: "author_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
