using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Account = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DebtorClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebtToReturn = table.Column<double>(type: "float", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtorClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtorClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loan = table.Column<double>(type: "float", nullable: false),
                    PaidPartOfLoan = table.Column<double>(type: "float", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Perecents = table.Column<int>(type: "int", nullable: false),
                    MonthDuration = table.Column<int>(type: "int", nullable: false),
                    LoanGotDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Login",
                table: "Clients",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DebtorClients_ClientId",
                table: "DebtorClients",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanClients_ClientId",
                table: "LoanClients",
                column: "ClientId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebtorClients");

            migrationBuilder.DropTable(
                name: "LoanClients");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
