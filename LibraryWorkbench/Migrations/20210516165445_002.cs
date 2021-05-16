using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_genre_lnk_book_BookId",
                table: "book_genre_lnk");

            migrationBuilder.DropForeignKey(
                name: "FK_book_genre_lnk_dim_genre_GenreId",
                table: "book_genre_lnk");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "book_genre_lnk",
                newName: "genre_id");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "book_genre_lnk",
                newName: "book_id");

            migrationBuilder.RenameIndex(
                name: "IX_book_genre_lnk_GenreId",
                table: "book_genre_lnk",
                newName: "IX_book_genre_lnk_genre_id");

            migrationBuilder.AddForeignKey(
                name: "FK_book_genre_lnk_book_book_id",
                table: "book_genre_lnk",
                column: "book_id",
                principalTable: "book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_book_genre_lnk_dim_genre_genre_id",
                table: "book_genre_lnk",
                column: "genre_id",
                principalTable: "dim_genre",
                principalColumn: "genre_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_genre_lnk_book_book_id",
                table: "book_genre_lnk");

            migrationBuilder.DropForeignKey(
                name: "FK_book_genre_lnk_dim_genre_genre_id",
                table: "book_genre_lnk");

            migrationBuilder.RenameColumn(
                name: "genre_id",
                table: "book_genre_lnk",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "book_id",
                table: "book_genre_lnk",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_book_genre_lnk_genre_id",
                table: "book_genre_lnk",
                newName: "IX_book_genre_lnk_GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_book_genre_lnk_book_BookId",
                table: "book_genre_lnk",
                column: "BookId",
                principalTable: "book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_book_genre_lnk_dim_genre_GenreId",
                table: "book_genre_lnk",
                column: "GenreId",
                principalTable: "dim_genre",
                principalColumn: "genre_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
