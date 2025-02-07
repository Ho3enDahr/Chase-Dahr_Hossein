using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud_test_dotnet.Infrastructure.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initDatabasessd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email",
                table: "Customer",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_FirstName_LastName_Email",
                table: "Customer",
                columns: new[] { "FirstName", "LastName", "Email" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email",
                table: "Customer",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_FirstName_LastName_Email",
                table: "Customer",
                columns: new[] { "FirstName", "LastName", "Email" });
        }
    }
}
