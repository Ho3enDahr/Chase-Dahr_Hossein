using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud_test_dotnet.Infrastructure.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initDatabasessdk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AlterColumn<string>(
                name: "BankAccountNumber",
                table: "Customer",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

         
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_Id",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "BankAccountNumber",
                table: "Customer",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Id",
                table: "Customer",
                column: "Id");
        }
    }
}
