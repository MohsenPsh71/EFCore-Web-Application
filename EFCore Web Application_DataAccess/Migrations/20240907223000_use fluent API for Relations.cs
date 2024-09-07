using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_Web_Application_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class usefluentAPIforRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fluent_BookAuthor",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_BookAuthor", x => new { x.Author_Id, x.Book_Id });
                    table.ForeignKey(
                        name: "FK_Fluent_BookAuthor_FluentAuthors_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "FluentAuthors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_BookAuthor_FluentBooks_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "FluentBooks",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_BookDetail_Id",
                table: "FluentBooks",
                column: "BookDetail_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_Publisher_Id",
                table: "FluentBooks",
                column: "Publisher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookAuthor_Book_Id",
                table: "Fluent_BookAuthor",
                column: "Book_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentBookDetails_BookDetail_Id",
                table: "FluentBooks",
                column: "BookDetail_Id",
                principalTable: "FluentBookDetails",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentPublishers_Publisher_Id",
                table: "FluentBooks",
                column: "Publisher_Id",
                principalTable: "FluentPublishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentBookDetails_BookDetail_Id",
                table: "FluentBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentPublishers_Publisher_Id",
                table: "FluentBooks");

            migrationBuilder.DropTable(
                name: "Fluent_BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_FluentBooks_BookDetail_Id",
                table: "FluentBooks");

            migrationBuilder.DropIndex(
                name: "IX_FluentBooks_Publisher_Id",
                table: "FluentBooks");
        }
    }
}
