using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_genre_lnk_book_BooksBookId",
                table: "book_genre_lnk");

            migrationBuilder.DropForeignKey(
                name: "FK_book_genre_lnk_dim_genre_GenresGenreId",
                table: "book_genre_lnk");

            migrationBuilder.RenameColumn(
                name: "GenresGenreId",
                table: "book_genre_lnk",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "BooksBookId",
                table: "book_genre_lnk",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_book_genre_lnk_GenresGenreId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "GenresGenreId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "book_genre_lnk",
                newName: "BooksBookId");

            migrationBuilder.RenameIndex(
                name: "IX_book_genre_lnk_GenreId",
                table: "book_genre_lnk",
                newName: "IX_book_genre_lnk_GenresGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_book_genre_lnk_book_BooksBookId",
                table: "book_genre_lnk",
                column: "BooksBookId",
                principalTable: "book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_book_genre_lnk_dim_genre_GenresGenreId",
                table: "book_genre_lnk",
                column: "GenresGenreId",
                principalTable: "dim_genre",
                principalColumn: "genre_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
