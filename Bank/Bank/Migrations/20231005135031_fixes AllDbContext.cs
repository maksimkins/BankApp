using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Migrations
{
    /// <inheritdoc />
    public partial class fixesAllDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoanClients_ClientId",
                table: "LoanClients");

            migrationBuilder.DropIndex(
                name: "IX_DebtorClients_LoanClientId",
                table: "DebtorClients");

            migrationBuilder.CreateIndex(
                name: "IX_LoanClients_ClientId",
                table: "LoanClients",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DebtorClients_LoanClientId",
                table: "DebtorClients",
                column: "LoanClientId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoanClients_ClientId",
                table: "LoanClients");

            migrationBuilder.DropIndex(
                name: "IX_DebtorClients_LoanClientId",
                table: "DebtorClients");

            migrationBuilder.CreateIndex(
                name: "IX_LoanClients_ClientId",
                table: "LoanClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorClients_LoanClientId",
                table: "DebtorClients",
                column: "LoanClientId");
        }
    }
}
