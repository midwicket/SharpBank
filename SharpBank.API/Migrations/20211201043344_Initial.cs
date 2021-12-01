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
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "FundsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCharge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RTGS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IMPS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NEFT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionCharge_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FundsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Accounts_FundsTable_FundsId",
                        column: x => x.FundsId,
                        principalTable: "FundsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FundsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Money", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Money_FundsTable_FundsId",
                        column: x => x.FundsId,
                        principalTable: "FundsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_DestinationAccountId",
                        column: x => x.DestinationAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_SourceAccountId",
                        column: x => x.SourceAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Money_AmountId",
                        column: x => x.AmountId,
                        principalTable: "Money",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "CreatedBy", "CreatedOn", "Logo", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("339186ff-4c10-48c4-8930-3ebd03c611b8"), "Cat", new DateTime(2021, 12, 1, 10, 3, 43, 934, DateTimeKind.Local).AddTicks(1027), null, "Test Bank", "Cat", new DateTime(2021, 12, 1, 10, 3, 43, 934, DateTimeKind.Local).AddTicks(1042) });

            migrationBuilder.InsertData(
                table: "FundsTable",
                column: "Id",
                value: new Guid("54a11d72-0ed4-4a59-8d5c-1cfe5f0452c9"));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "BankId", "FundsId", "Gender", "Name", "Password", "Status" },
                values: new object[] { new Guid("00dcc120-bfd5-4cb9-9710-3dbcbcc5d0aa"), new Guid("339186ff-4c10-48c4-8930-3ebd03c611b8"), new Guid("54a11d72-0ed4-4a59-8d5c-1cfe5f0452c9"), 0, "Testendra Testy", "password", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BankId",
                table: "Accounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_FundsId",
                table: "Accounts",
                column: "FundsId");

            migrationBuilder.CreateIndex(
                name: "IX_Money_FundsId",
                table: "Money",
                column: "FundsId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCharge_BankId",
                table: "TransactionCharge",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AmountId",
                table: "Transactions",
                column: "AmountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DestinationAccountId",
                table: "Transactions",
                column: "DestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SourceAccountId",
                table: "Transactions",
                column: "SourceAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionCharge");

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
        }
    }
}
