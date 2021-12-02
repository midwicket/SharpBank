using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharpBank.Data.Migrations
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
                    MoneyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Transactions_Money_MoneyId",
                        column: x => x.MoneyId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "CreatedBy", "CreatedOn", "Logo", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("70ebb090-ee75-474e-8f6d-4811619be6f1"), "Cat", new DateTime(2021, 12, 2, 19, 23, 24, 593, DateTimeKind.Local).AddTicks(6278), null, "Test Bank", "Cat", new DateTime(2021, 12, 2, 19, 23, 24, 593, DateTimeKind.Local).AddTicks(6295) });

            migrationBuilder.InsertData(
                table: "FundsTable",
                column: "Id",
                value: new Guid("007f4f8b-212c-44b9-b462-012db41098fb"));

            migrationBuilder.InsertData(
                table: "FundsTable",
                column: "Id",
                value: new Guid("77b06774-20c6-4c08-a1f2-149130d16f00"));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "BankId", "FundsId", "Gender", "Name", "Password", "Status" },
                values: new object[,]
                {
                    { new Guid("7bb44932-4c59-4828-92fa-e6c518c8b6f4"), new Guid("70ebb090-ee75-474e-8f6d-4811619be6f1"), new Guid("007f4f8b-212c-44b9-b462-012db41098fb"), 0, "Testendra Testy", "password", 0 },
                    { new Guid("936f2e5e-f8ce-46dc-958f-e6c3c2c57a3d"), new Guid("70ebb090-ee75-474e-8f6d-4811619be6f1"), new Guid("007f4f8b-212c-44b9-b462-012db41098fb"), 0, "Wastendar Wastee", "password", 0 }
                });

            migrationBuilder.InsertData(
                table: "Money",
                columns: new[] { "Id", "Amount", "Currency", "FundsId" },
                values: new object[,]
                {
                    { new Guid("2c226da7-41b0-477b-8dcb-eea6bc6217df"), 10m, 356, new Guid("007f4f8b-212c-44b9-b462-012db41098fb") },
                    { new Guid("487077d3-85d7-4f76-9f2e-65fc2199402d"), 10m, 356, new Guid("77b06774-20c6-4c08-a1f2-149130d16f00") }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "DestinationAccountId", "MoneyId", "On", "SourceAccountId", "Type" },
                values: new object[] { new Guid("fc4c1667-d161-4e45-a95f-d02c0c5d57ee"), new Guid("936f2e5e-f8ce-46dc-958f-e6c3c2c57a3d"), new Guid("487077d3-85d7-4f76-9f2e-65fc2199402d"), new DateTime(2021, 12, 2, 19, 23, 24, 593, DateTimeKind.Local).AddTicks(6743), new Guid("7bb44932-4c59-4828-92fa-e6c518c8b6f4"), 0 });

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
                name: "IX_Transactions_DestinationAccountId",
                table: "Transactions",
                column: "DestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MoneyId",
                table: "Transactions",
                column: "MoneyId");

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
