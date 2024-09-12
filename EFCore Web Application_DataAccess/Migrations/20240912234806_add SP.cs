using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_Web_Application_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW dbo.GetOnlyBookDetails
                                    AS
                                    SELECT m.ISBN,m.Title,m.Price From dbo.Books m");
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.getAllBookDetails
                                    @bookId int
                                    As
                                    SET NOCOUNT ON;
                                    Select * From dbo.Books b
                                    Where b.Book_Id=@bookId
                                    GO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.GetOnlyBookDetails");
            migrationBuilder.Sql("DROP PROCEDURE dbo.getAllBookDetails");
        }
    }
}
