using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharpBank.Data.Migrations
{
    public partial class TransactionCharges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionCharge_Banks_BankId",
                table: "TransactionCharge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionCharge",
                table: "TransactionCharge");

            migrationBuilder.DeleteData(
                table: "Money",
                keyColumn: "Id",
                keyValue: new Guid("2c226da7-41b0-477b-8dcb-eea6bc6217df"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("fc4c1667-d161-4e45-a95f-d02c0c5d57ee"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("7bb44932-4c59-4828-92fa-e6c518c8b6f4"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("936f2e5e-f8ce-46dc-958f-e6c3c2c57a3d"));

            migrationBuilder.DeleteData(
                table: "Money",
                keyColumn: "Id",
                keyValue: new Guid("487077d3-85d7-4f76-9f2e-65fc2199402d"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("70ebb090-ee75-474e-8f6d-4811619be6f1"));

            migrationBuilder.DeleteData(
                table: "FundsTable",
                keyColumn: "Id",
                keyValue: new Guid("007f4f8b-212c-44b9-b462-012db41098fb"));

            migrationBuilder.DeleteData(
                table: "FundsTable",
                keyColumn: "Id",
                keyValue: new Guid("77b06774-20c6-4c08-a1f2-149130d16f00"));

            migrationBuilder.RenameTable(
                name: "TransactionCharge",
                newName: "Charges");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionCharge_BankId",
                table: "Charges",
                newName: "IX_Charges_BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Charges",
                table: "Charges",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "CreatedBy", "CreatedOn", "Logo", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("f6f0fd94-bb7e-454e-925c-a0d5f539f813"), "Cat", new DateTime(2021, 12, 7, 12, 39, 26, 197, DateTimeKind.Local).AddTicks(7992), null, "Test Bank", "Cat", new DateTime(2021, 12, 7, 12, 39, 26, 197, DateTimeKind.Local).AddTicks(8020) });

            migrationBuilder.InsertData(
                table: "FundsTable",
                column: "Id",
                value: new Guid("342f9963-2a24-49d4-9f6d-cabfcfe6ad84"));

            migrationBuilder.InsertData(
                table: "FundsTable",
                column: "Id",
                value: new Guid("b97bfc17-6ac5-4428-b855-511b9465d6ab"));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "BankId", "FundsId", "Gender", "Name", "Password", "Status" },
                values: new object[,]
                {
                    { new Guid("502237e2-63b3-4645-8a31-decc5a52e379"), new Guid("f6f0fd94-bb7e-454e-925c-a0d5f539f813"), new Guid("b97bfc17-6ac5-4428-b855-511b9465d6ab"), 0, "Testendra Testy", "password", 0 },
                    { new Guid("ae7b64b2-b309-493e-b4f0-48262a0e6b1c"), new Guid("f6f0fd94-bb7e-454e-925c-a0d5f539f813"), new Guid("b97bfc17-6ac5-4428-b855-511b9465d6ab"), 0, "Wastendar Wastee", "password", 0 }
                });

            migrationBuilder.InsertData(
                table: "Money",
                columns: new[] { "Id", "Amount", "Currency", "FundsId" },
                values: new object[,]
                {
                    { new Guid("25b83c46-2aee-4aa0-be33-0f395456ca9f"), 10m, 356, new Guid("b97bfc17-6ac5-4428-b855-511b9465d6ab") },
                    { new Guid("5552db6d-1b61-445b-bc43-202af5512b83"), 10m, 356, new Guid("342f9963-2a24-49d4-9f6d-cabfcfe6ad84") }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "DestinationAccountId", "MoneyId", "On", "SourceAccountId", "Type" },
                values: new object[] { new Guid("2114e135-1fd4-4cb5-b9d1-6a8edc68fb25"), new Guid("ae7b64b2-b309-493e-b4f0-48262a0e6b1c"), new Guid("5552db6d-1b61-445b-bc43-202af5512b83"), new DateTime(2021, 12, 7, 12, 39, 26, 197, DateTimeKind.Local).AddTicks(8722), new Guid("502237e2-63b3-4645-8a31-decc5a52e379"), 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Charges_Banks_BankId",
                table: "Charges",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charges_Banks_BankId",
                table: "Charges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Charges",
                table: "Charges");

            migrationBuilder.DeleteData(
                table: "Money",
                keyColumn: "Id",
                keyValue: new Guid("25b83c46-2aee-4aa0-be33-0f395456ca9f"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("2114e135-1fd4-4cb5-b9d1-6a8edc68fb25"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("502237e2-63b3-4645-8a31-decc5a52e379"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("ae7b64b2-b309-493e-b4f0-48262a0e6b1c"));

            migrationBuilder.DeleteData(
                table: "Money",
                keyColumn: "Id",
                keyValue: new Guid("5552db6d-1b61-445b-bc43-202af5512b83"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("f6f0fd94-bb7e-454e-925c-a0d5f539f813"));

            migrationBuilder.DeleteData(
                table: "FundsTable",
                keyColumn: "Id",
                keyValue: new Guid("342f9963-2a24-49d4-9f6d-cabfcfe6ad84"));

            migrationBuilder.DeleteData(
                table: "FundsTable",
                keyColumn: "Id",
                keyValue: new Guid("b97bfc17-6ac5-4428-b855-511b9465d6ab"));

            migrationBuilder.RenameTable(
                name: "Charges",
                newName: "TransactionCharge");

            migrationBuilder.RenameIndex(
                name: "IX_Charges_BankId",
                table: "TransactionCharge",
                newName: "IX_TransactionCharge_BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionCharge",
                table: "TransactionCharge",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionCharge_Banks_BankId",
                table: "TransactionCharge",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
