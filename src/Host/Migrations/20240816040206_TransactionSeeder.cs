using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garuda.Migrations
{
    /// <inheritdoc />
    public partial class TransactionSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_animals_animal_id",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_users_user_id",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_animal_id",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_user_id",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "payment_status",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "transactions",
                newName: "seller_id");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "transactions",
                newName: "amount");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "transactions",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "buyer_id",
                table: "transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "transaction_date",
                table: "transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "transactions",
                columns: new[] { "id", "amount", "animal_id", "buyer_id", "created_by", "created_date", "deleted_by", "deleted_date", "seller_id", "status", "transaction_date", "updated_by", "updated_date" },
                values: new object[] { new Guid("8b7e3e2f-b32a-4c8e-a3f5-4e7e848ea704"), 1500.00m, new Guid("f6268f99-c46f-498e-b2ec-676ce7a7541e"), new Guid("c3e20f8e-92a7-4c19-90a2-7fb66fd1b6b1"), "System", new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f7a74c57-8968-4b3a-91e5-38b2f6aef91c"), "Completed", new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: new Guid("8b7e3e2f-b32a-4c8e-a3f5-4e7e848ea704"));

            migrationBuilder.DropColumn(
                name: "buyer_id",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "transaction_date",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "seller_id",
                table: "transactions",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "transactions",
                newName: "price");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "transactions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "payment_status",
                table: "transactions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_animal_id",
                table: "transactions",
                column: "animal_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_user_id",
                table: "transactions",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_animals_animal_id",
                table: "transactions",
                column: "animal_id",
                principalTable: "animals",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_users_user_id",
                table: "transactions",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
