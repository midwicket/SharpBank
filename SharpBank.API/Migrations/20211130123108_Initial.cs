using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharpBank.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundsTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCharge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntraBank = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterBank = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCharge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FundsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Money", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Money_FundsTable_FundsId",
                        column: x => x.FundsId,
                        principalTable: "FundsTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMPSId = table.Column<int>(type: "int", nullable: true),
                    RTGSId = table.Column<int>(type: "int", nullable: true),
                    NEFTId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                    table.ForeignKey(
                        name: "FK_Banks_TransactionCharge_IMPSId",
                        column: x => x.IMPSId,
                        principalTable: "TransactionCharge",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Banks_TransactionCharge_NEFTId",
                        column: x => x.NEFTId,
                        principalTable: "TransactionCharge",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Banks_TransactionCharge_RTGSId",
                        column: x => x.RTGSId,
                        principalTable: "TransactionCharge",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankId = table.Column<long>(type: "bigint", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BalanceId = table.Column<long>(type: "bigint", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_FundsTable_BalanceId",
                        column: x => x.BalanceId,
                        principalTable: "FundsTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceBankId = table.Column<long>(type: "bigint", nullable: false),
                    DestinationBankId = table.Column<long>(type: "bigint", nullable: false),
                    SourceAccountId = table.Column<long>(type: "bigint", nullable: false),
                    DestinationAccountId = table.Column<long>(type: "bigint", nullable: false),
                    AmountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_Transactions_Money_AmountId",
                        column: x => x.AmountId,
                        principalTable: "Money",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BalanceId",
                table: "Accounts",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BankId",
                table: "Accounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_IMPSId",
                table: "Banks",
                column: "IMPSId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_NEFTId",
                table: "Banks",
                column: "NEFTId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_RTGSId",
                table: "Banks",
                column: "RTGSId");

            migrationBuilder.CreateIndex(
                name: "IX_Money_FundsId",
                table: "Money",
                column: "FundsId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AmountId",
                table: "Transactions",
                column: "AmountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Money");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "FundsTable");

            migrationBuilder.DropTable(
                name: "TransactionCharge");
        }
    }
}
