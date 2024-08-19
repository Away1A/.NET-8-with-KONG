using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garuda.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DeleteData(
                table: "animals",
                keyColumn: "id",
                keyValue: new Guid("f6268f99-c46f-498e-b2ec-676ce7a7541e"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    animal_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    buyer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    seller_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    transaction_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "animals",
                columns: new[] { "id", "age", "created_by", "created_date", "deleted_by", "deleted_date", "description", "gender", "name", "price", "type", "updated_by", "updated_date" },
                values: new object[] { new Guid("f6268f99-c46f-498e-b2ec-676ce7a7541e"), 3, "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "A cute slow loris.", "Male", "Kukang", 1500.00m, "Mammal", null, null });

            migrationBuilder.InsertData(
                table: "transactions",
                columns: new[] { "id", "amount", "animal_id", "buyer_id", "created_by", "created_date", "deleted_by", "deleted_date", "seller_id", "status", "transaction_date", "updated_by", "updated_date" },
                values: new object[] { new Guid("8b7e3e2f-b32a-4c8e-a3f5-4e7e848ea704"), 1500.00m, new Guid("f6268f99-c46f-498e-b2ec-676ce7a7541e"), new Guid("c3e20f8e-92a7-4c19-90a2-7fb66fd1b6b1"), "System", new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f7a74c57-8968-4b3a-91e5-38b2f6aef91c"), "Completed", new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });
        }
    }
}
