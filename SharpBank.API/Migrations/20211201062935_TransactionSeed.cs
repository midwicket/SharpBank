using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharpBank.API.Migrations
{
    public partial class TransactionSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Money_AmountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AmountId",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("00dcc120-bfd5-4cb9-9710-3dbcbcc5d0aa"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("339186ff-4c10-48c4-8930-3ebd03c611b8"));

            migrationBuilder.DeleteData(
                table: "FundsTable",
                keyColumn: "Id",
                keyValue: new Guid("54a11d72-0ed4-4a59-8d5c-1cfe5f0452c9"));

            migrationBuilder.DropColumn(
                name: "AmountId",
                table: "Transactions");

            migrationBuilder.AddColumn<Guid>(
                name: "MoneyId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "CreatedBy", "CreatedOn", "Logo", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("9c113548-4554-43fd-92df-8c447d5ed0ea"), "Cat", new DateTime(2021, 12, 1, 11, 59, 34, 405, DateTimeKind.Local).AddTicks(3429), null, "Test Bank", "Cat", new DateTime(2021, 12, 1, 11, 59, 34, 405, DateTimeKind.Local).AddTicks(3450) });

            migrationBuilder.InsertData(
                table: "FundsTable",
                column: "Id",
                value: new Guid("3c3052f2-fb88-4bce-80a4-5033095aabb9"));

            migrationBuilder.InsertData(
                table: "FundsTable",
                column: "Id",
                value: new Guid("9c099d25-7498-4ab1-b2c4-354d91aa843f"));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "BankId", "FundsId", "Gender", "Name", "Password", "Status" },
                values: new object[,]
                {
                    { new Guid("7129a9b2-cd11-4230-af43-2e8e15aafc2c"), new Guid("9c113548-4554-43fd-92df-8c447d5ed0ea"), new Guid("9c099d25-7498-4ab1-b2c4-354d91aa843f"), 0, "Wastendar Wastee", "password", 0 },
                    { new Guid("9b3258a5-8f13-4083-83fe-8c7d24d449fe"), new Guid("9c113548-4554-43fd-92df-8c447d5ed0ea"), new Guid("9c099d25-7498-4ab1-b2c4-354d91aa843f"), 0, "Testendra Testy", "password", 0 }
                });

            migrationBuilder.InsertData(
                table: "Money",
                columns: new[] { "Id", "Amount", "Currency", "FundsId" },
                values: new object[,]
                {
                    { new Guid("164c9af8-8e27-4cd7-9144-2b7eb5ea43ba"), 10m, 356, new Guid("9c099d25-7498-4ab1-b2c4-354d91aa843f") },
                    { new Guid("48981f5a-c936-40a6-9357-de710bf0e02e"), 10m, 356, new Guid("3c3052f2-fb88-4bce-80a4-5033095aabb9") }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "DestinationAccountId", "MoneyId", "On", "SourceAccountId", "Type" },
                values: new object[] { new Guid("99405c69-cdf2-4a31-b3fa-55338de3caad"), new Guid("7129a9b2-cd11-4230-af43-2e8e15aafc2c"), new Guid("48981f5a-c936-40a6-9357-de710bf0e02e"), new DateTime(2021, 12, 1, 11, 59, 34, 405, DateTimeKind.Local).AddTicks(3892), new Guid("9b3258a5-8f13-4083-83fe-8c7d24d449fe"), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MoneyId",
                table: "Transactions",
                column: "MoneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Money_MoneyId",
                table: "Transactions",
                column: "MoneyId",
                principalTable: "Money",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Money_MoneyId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_MoneyId",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "Money",
                keyColumn: "Id",
                keyValue: new Guid("164c9af8-8e27-4cd7-9144-2b7eb5ea43ba"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("99405c69-cdf2-4a31-b3fa-55338de3caad"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("7129a9b2-cd11-4230-af43-2e8e15aafc2c"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("9b3258a5-8f13-4083-83fe-8c7d24d449fe"));

            migrationBuilder.DeleteData(
                table: "Money",
                keyColumn: "Id",
                keyValue: new Guid("48981f5a-c936-40a6-9357-de710bf0e02e"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("9c113548-4554-43fd-92df-8c447d5ed0ea"));

            migrationBuilder.DeleteData(
                table: "FundsTable",
                keyColumn: "Id",
                keyValue: new Guid("3c3052f2-fb88-4bce-80a4-5033095aabb9"));

            migrationBuilder.DeleteData(
                table: "FundsTable",
                keyColumn: "Id",
                keyValue: new Guid("9c099d25-7498-4ab1-b2c4-354d91aa843f"));

            migrationBuilder.DropColumn(
                name: "MoneyId",
                table: "Transactions");

            migrationBuilder.AddColumn<Guid>(
                name: "AmountId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true);

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
                name: "IX_Transactions_AmountId",
                table: "Transactions",
                column: "AmountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Money_AmountId",
                table: "Transactions",
                column: "AmountId",
                principalTable: "Money",
                principalColumn: "Id");
        }
    }
}
