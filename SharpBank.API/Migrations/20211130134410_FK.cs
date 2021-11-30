using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharpBank.API.Migrations
{
    public partial class FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banks_TransactionCharge_IMPSId",
                table: "Banks");

            migrationBuilder.DropForeignKey(
                name: "FK_Banks_TransactionCharge_NEFTId",
                table: "Banks");

            migrationBuilder.DropForeignKey(
                name: "FK_Banks_TransactionCharge_RTGSId",
                table: "Banks");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Banks_IMPSId",
                table: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_Banks_NEFTId",
                table: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_Banks_RTGSId",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IMPSId",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "NEFTId",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "RTGSId",
                table: "Banks");

            migrationBuilder.RenameColumn(
                name: "IntraBank",
                table: "TransactionCharge",
                newName: "RTGS");

            migrationBuilder.RenameColumn(
                name: "InterBank",
                table: "TransactionCharge",
                newName: "NEFT");

            migrationBuilder.AddColumn<long>(
                name: "BankId",
                table: "TransactionCharge",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "IMPS",
                table: "TransactionCharge",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TransactionCharge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DestinationAccountId",
                table: "Transactions",
                column: "DestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SourceAccountId",
                table: "Transactions",
                column: "SourceAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCharge_BankId",
                table: "TransactionCharge",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionCharge_Banks_BankId",
                table: "TransactionCharge",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_DestinationAccountId",
                table: "Transactions",
                column: "DestinationAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_SourceAccountId",
                table: "Transactions",
                column: "SourceAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionCharge_Banks_BankId",
                table: "TransactionCharge");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_DestinationAccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_SourceAccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_DestinationAccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_SourceAccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_TransactionCharge_BankId",
                table: "TransactionCharge");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "TransactionCharge");

            migrationBuilder.DropColumn(
                name: "IMPS",
                table: "TransactionCharge");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TransactionCharge");

            migrationBuilder.RenameColumn(
                name: "RTGS",
                table: "TransactionCharge",
                newName: "IntraBank");

            migrationBuilder.RenameColumn(
                name: "NEFT",
                table: "TransactionCharge",
                newName: "InterBank");

            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Transactions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IMPSId",
                table: "Banks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NEFTId",
                table: "Banks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RTGSId",
                table: "Banks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_TransactionCharge_IMPSId",
                table: "Banks",
                column: "IMPSId",
                principalTable: "TransactionCharge",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_TransactionCharge_NEFTId",
                table: "Banks",
                column: "NEFTId",
                principalTable: "TransactionCharge",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_TransactionCharge_RTGSId",
                table: "Banks",
                column: "RTGSId",
                principalTable: "TransactionCharge",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId");
        }
    }
}
