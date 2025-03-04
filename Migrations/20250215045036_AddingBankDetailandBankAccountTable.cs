using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoneyTransfer.Migrations
{
    /// <inheritdoc />
    public partial class AddingBankDetailandBankAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankDetails",
                schema: "System",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                schema: "System",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_BankAccounts_BankDetails_BankId",
                        column: x => x.BankId,
                        principalSchema: "System",
                        principalTable: "BankDetails",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "System",
                table: "BankDetails",
                columns: new[] { "BankId", "Address", "BankName", "Country", "Currency", "IsoCode", "SwiftCode" },
                values: new object[,]
                {
                    { 1, "New Road, Kathmandu, Bagmati, 44600, Nepal", "Standard Chartered Bank Nepal", "Nepal", "Nepalese Rupee", "NPR", "SCBLNPKA" },
                    { 2, "Thamel, Kathmandu, Bagmati, 44600, Nepal", "Himalayan Bank Limited", "Nepal", "Nepalese Rupee", "NPR", "HBLNNPKA" },
                    { 3, "Lazimpat, Kathmandu, Bagmati, 44600, Nepal", "Nepal Investment Bank Limited", "Nepal", "Nepalese Rupee", "NPR", "NIBLNPKA" },
                    { 4, "Durbar Marg, Kathmandu, Bagmati, 44600, Nepal", "Nabil Bank Limited", "Nepal", "Nepalese Rupee", "NPR", "NABLNPKA" },
                    { 5, "Menara Maybank, 100 Jalan Tun Perak, Kuala Lumpur, Wilayah Persekutuan, 50050, Malaysia", "Maybank", "Malaysia", "Malaysian Ringgit", "MYR", "MAYBMYKL" },
                    { 6, "Menara CIMB, 165 Jalan Ampang, Kuala Lumpur, Wilayah Persekutuan, 50450, Malaysia", "CIMB Bank", "Malaysia", "Malaysian Ringgit", "MYR", "CIBBMYKL" },
                    { 7, "Public Bank Building, 146 Jalan Ampang, Kuala Lumpur, Wilayah Persekutuan, 50450, Malaysia", "Public Bank Berhad", "Malaysia", "Malaysian Ringgit", "MYR", "PBBEMYKL" },
                    { 8, "RHB Tower, 10 Jalan Tun Perak, Kuala Lumpur, Wilayah Persekutuan, 50050, Malaysia", "RHB Bank", "Malaysia", "Malaysian Ringgit", "MYR", "RHBBMYKL" }
                });

            migrationBuilder.InsertData(
                schema: "System",
                table: "BankAccounts",
                columns: new[] { "AccountId", "AccountNumber", "AccountType", "Address", "Balance", "BankId", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { 1, "123456789", "Savings", "123 Main Street, Kathmandu, Bagmati, 44600, Nepal", 1000.00m, 1, "John", "Doe", "D." },
                    { 2, "987654321", "Checking", "456 Market Street, Kuala Lumpur, Wilayah Persekutuan, 50050, Malaysia", 2000.00m, 5, "Jane", "Smith", "P." },
                    { 3, "567890123", "Business", "789 Business Ave, Kathmandu, Bagmati, 44600, Nepal", 5000.00m, 3, "Alice", "Johnson", "M." },
                    { 4, "246801357", "Savings", "1014 High Street, Kuala Lumpur, Wilayah Persekutuan, 50450, Malaysia", 3000.00m, 6, "Bob", "Williams", "L." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_BankId",
                schema: "System",
                table: "BankAccounts",
                column: "BankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts",
                schema: "System");

            migrationBuilder.DropTable(
                name: "BankDetails",
                schema: "System");
        }
    }
}
