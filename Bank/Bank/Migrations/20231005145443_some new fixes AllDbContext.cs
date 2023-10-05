using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Migrations
{
    /// <inheritdoc />
    public partial class somenewfixesAllDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "LoanClients");

            migrationBuilder.RenameColumn(
                name: "PeriodOfPayment",
                table: "LoanClients",
                newName: "LoanGotDate");

            migrationBuilder.AddColumn<int>(
                name: "MonthDuration",
                table: "LoanClients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthDuration",
                table: "LoanClients");

            migrationBuilder.RenameColumn(
                name: "LoanGotDate",
                table: "LoanClients",
                newName: "PeriodOfPayment");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "LoanClients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
