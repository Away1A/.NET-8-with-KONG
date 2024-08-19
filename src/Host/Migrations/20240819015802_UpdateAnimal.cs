using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Garuda.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "animals",
                keyColumn: "id",
                keyValue: new Guid("d34db33f-92a9-4a4e-a24c-89c8bafaa0f2"));

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "animals",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "approved_by",
                table: "animals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "approved_date",
                table: "animals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "permitted_by",
                table: "animals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "permitted_date",
                table: "animals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rejected_by",
                table: "animals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "rejected_date",
                table: "animals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rejection_reason",
                table: "animals",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "animals",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "animals",
                columns: new[] { "id", "age", "approved_by", "approved_date", "created_by", "created_date", "deleted_by", "deleted_date", "description", "gender", "name", "permitted_by", "permitted_date", "price", "rejected_by", "rejected_date", "rejection_reason", "status", "type", "updated_by", "updated_date" },
                values: new object[,]
                {
                    { new Guid("47c49fdd-ad89-4acb-99e1-0cf45eae1910"), 5, "admin@example.com", new DateTime(2024, 8, 19, 1, 58, 1, 368, DateTimeKind.Utc).AddTicks(2021), "", null, null, null, "A majestic lion.", "Male", "Lion", "admin@example.com", new DateTime(2024, 8, 19, 1, 58, 1, 368, DateTimeKind.Utc).AddTicks(2026), 1500.00m, null, null, null, "Approved", "Mammal", null, null },
                    { new Guid("dc69b089-fa6d-4d97-9a9e-cbdbd23cf84d"), 2, null, null, "", null, null, null, "A colorful parrot.", "Female", "Parrot", null, null, 300.00m, null, null, null, "Pending", "Bird", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "animals",
                keyColumn: "id",
                keyValue: new Guid("47c49fdd-ad89-4acb-99e1-0cf45eae1910"));

            migrationBuilder.DeleteData(
                table: "animals",
                keyColumn: "id",
                keyValue: new Guid("dc69b089-fa6d-4d97-9a9e-cbdbd23cf84d"));

            migrationBuilder.DropColumn(
                name: "approved_by",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "approved_date",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "permitted_by",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "permitted_date",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "rejected_by",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "rejected_date",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "rejection_reason",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "status",
                table: "animals");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "animals",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "animals",
                columns: new[] { "id", "age", "created_by", "created_date", "deleted_by", "deleted_date", "description", "gender", "name", "price", "type", "updated_by", "updated_date" },
                values: new object[] { new Guid("d34db33f-92a9-4a4e-a24c-89c8bafaa0f2"), 2, "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "A colorful and talkative parrot.", "Female", "Parrot", 200.00m, "Bird", null, null });
        }
    }
}
