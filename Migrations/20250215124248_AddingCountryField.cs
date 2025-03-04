using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyTransfer.Migrations
{
    /// <inheritdoc />
    public partial class AddingCountryField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "System",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "System",
                table: "BankAccounts",
                keyColumn: "AccountId",
                keyValue: 1,
                column: "Country",
                value: "Nepal");

            migrationBuilder.UpdateData(
                schema: "System",
                table: "BankAccounts",
                keyColumn: "AccountId",
                keyValue: 2,
                column: "Country",
                value: "Malaysia");

            migrationBuilder.UpdateData(
                schema: "System",
                table: "BankAccounts",
                keyColumn: "AccountId",
                keyValue: 3,
                column: "Country",
                value: "Nepal");

            migrationBuilder.UpdateData(
                schema: "System",
                table: "BankAccounts",
                keyColumn: "AccountId",
                keyValue: 4,
                column: "Country",
                value: "Malaysia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                schema: "System",
                table: "BankAccounts");
        }
    }
}
