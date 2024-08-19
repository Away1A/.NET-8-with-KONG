using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garuda.Migrations
{
    /// <inheritdoc />
    public partial class AddAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birthdate",
                table: "animals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "birthdate",
                table: "animals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "animals",
                keyColumn: "id",
                keyValue: new Guid("f6268f99-c46f-498e-b2ec-676ce7a7541e"),
                column: "birthdate",
                value: new DateTime(2001, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
