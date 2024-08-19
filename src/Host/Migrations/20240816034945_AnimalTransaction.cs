using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garuda.Migrations
{
    /// <inheritdoc />
    public partial class AnimalTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "animals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "animals",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "animals",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "animals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "animals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "animals",
                keyColumn: "id",
                keyValue: new Guid("f6268f99-c46f-498e-b2ec-676ce7a7541e"),
                columns: new[] { "age", "description", "price", "type" },
                values: new object[] { 3, "A cute slow loris.", 1500.00m, "Mammal" });

            migrationBuilder.InsertData(
                table: "animals",
                columns: new[] { "id", "age", "created_by", "created_date", "deleted_by", "deleted_date", "description", "gender", "name", "price", "type", "updated_by", "updated_date" },
                values: new object[] { new Guid("d34db33f-92a9-4a4e-a24c-89c8bafaa0f2"), 2, "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "A colorful and talkative parrot.", "Female", "Parrot", 200.00m, "Bird", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "animals",
                keyColumn: "id",
                keyValue: new Guid("d34db33f-92a9-4a4e-a24c-89c8bafaa0f2"));

            migrationBuilder.DropColumn(
                name: "age",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "description",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "price",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "type",
                table: "animals");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "animals",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "animals",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
