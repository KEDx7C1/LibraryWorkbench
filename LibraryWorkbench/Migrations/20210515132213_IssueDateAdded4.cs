using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWorkbench.Migrations
{
    public partial class IssueDateAdded4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "book",
                newName: "year");

            migrationBuilder.AlterColumn<string>(
                name: "middle_name",
                table: "person",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "person",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "person",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "book",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "middle_name",
                table: "author",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "author",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "author",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75);

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

            migrationBuilder.RenameColumn(
                name: "year",
                table: "book",
                newName: "Year");

            migrationBuilder.AlterColumn<string>(
                name: "middle_name",
                table: "person",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "person",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "person",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "book",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "middle_name",
                table: "author",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "author",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "author",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
