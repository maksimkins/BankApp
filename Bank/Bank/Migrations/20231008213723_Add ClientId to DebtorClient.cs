using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Migrations
{
    /// <inheritdoc />
    public partial class AddClientIdtoDebtorClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "DebtorClients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DebtorClients_ClientId",
                table: "DebtorClients",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorClients_Clients_ClientId",
                table: "DebtorClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtorClients_Clients_ClientId",
                table: "DebtorClients");

            migrationBuilder.DropIndex(
                name: "IX_DebtorClients_ClientId",
                table: "DebtorClients");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "DebtorClients");
        }
    }
}
