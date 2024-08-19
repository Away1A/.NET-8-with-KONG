using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Garuda.Migrations
{
    /// <inheritdoc />
    public partial class AddTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "animals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "app_configurations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_configurations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "audit_logs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    class_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    old_value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    new_value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audit_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    icon_class = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    level = table.Column<byte>(type: "tinyint", nullable: false),
                    order = table.Column<byte>(type: "tinyint", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_sessions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    refresh_token = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    token = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    date_revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    date_expired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_sessions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fullname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_login = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_menu_permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    menu_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    can_view = table.Column<bool>(type: "bit", nullable: false),
                    can_update = table.Column<bool>(type: "bit", nullable: false),
                    can_create = table.Column<bool>(type: "bit", nullable: false),
                    can_delete = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_menu_permissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_role_menu_permissions_menus_menu_id",
                        column: x => x.menu_id,
                        principalTable: "menus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_role_menu_permissions_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    animal_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    payment_status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_transactions_animals_animal_id",
                        column: x => x.animal_id,
                        principalTable: "animals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transactions_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_groups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_groups", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_groups_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_groups_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "animals",
                columns: new[] { "id", "birthdate", "created_by", "created_date", "deleted_by", "deleted_date", "gender", "name", "updated_by", "updated_date" },
                values: new object[] { new Guid("f6268f99-c46f-498e-b2ec-676ce7a7541e"), new DateTime(2001, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Male", "Kukang", null, null });

            migrationBuilder.InsertData(
                table: "menus",
                columns: new[] { "id", "code", "created_by", "created_date", "deleted_by", "deleted_date", "icon_class", "level", "name", "order", "ParentId", "slug", "updated_by", "updated_date" },
                values: new object[,]
                {
                    { new Guid("5026c85e-04f4-4d65-9fd2-bff26ad90013"), "user", "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "icon-user", (byte)1, "User Management", (byte)0, new Guid("f0663ca2-ffb8-42c2-b022-38479c7c84af"), "/IndexUser", null, null },
                    { new Guid("77118193-d70c-4e36-97a0-683b9e825569"), "act", "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "icon-notes", (byte)0, "My Activity", (byte)2, new Guid("00000000-0000-0000-0000-000000000000"), "/IndexMyActivity", null, null },
                    { new Guid("7f2302be-efd5-43f1-b6c9-8e8886c8460c"), "doc", "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "icon-file", (byte)0, "My Document", (byte)3, new Guid("00000000-0000-0000-0000-000000000000"), "", null, null },
                    { new Guid("8f735cdf-bd01-4ae3-89c6-b122bdd59b8b"), "dash", "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "icon-home", (byte)0, "Dashboard", (byte)0, new Guid("00000000-0000-0000-0000-000000000000"), "/Dashboard", null, null },
                    { new Guid("f0663ca2-ffb8-42c2-b022-38479c7c84af"), "set", "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "icon-cog-outline", (byte)0, "Settings", (byte)5, new Guid("00000000-0000-0000-0000-000000000000"), "", null, null },
                    { new Guid("f45e2f20-e6c3-4d82-b0d9-e91469103672"), "sec", "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "", (byte)1, "Manage Security Group", (byte)1, new Guid("f0663ca2-ffb8-42c2-b022-38479c7c84af"), "/IndexSecurity", null, null }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_by", "created_date", "deleted_by", "deleted_date", "name", "updated_by", "updated_date" },
                values: new object[,]
                {
                    { new Guid("91e4aa02-8c2f-4074-9a47-5e33d7ab641c"), "System", new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Buyer", null, null },
                    { new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Administrator", null, null },
                    { new Guid("f5105f3d-579f-42d8-be30-5b78249cba45"), "System", new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Seller", null, null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_by", "created_date", "deleted_by", "deleted_date", "email", "fullname", "last_login", "Password", "updated_by", "updated_date", "username" },
                values: new object[,]
                {
                    { new Guid("81314787-537b-474f-999a-9152c9703bbb"), "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "system@system.co", "System", null, "$2a$11$ijs7c9x9yHz1oeZ95CF76u1CGALKC3sVeMpGyfzA0U7gWlpH7tmhO", null, null, "systemadmin" },
                    { new Guid("c3e20f8e-92a7-4c19-90a2-7fb66fd1b6b1"), "System", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "buyer@platform.com", "Buyer User", null, "$2a$12$7hXoj0eKxTvhwo9qKYZdQOE1aiHaqHdhDlBjSzAqAjSs1u0ILF.EG", null, null, "buyer" },
                    { new Guid("f7a74c57-8968-4b3a-91e5-38b2f6aef91c"), "System", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "seller@platform.com", "Seller User", null, "$2a$12$lVXtNCUzJaFgAmJ.sJvSheGHJlZuQG96ZZGReyJn9lxg2WEbuAYDW", null, null, "seller" },
                    { new Guid("fa3876d9-b8ce-4029-9df6-2e8ee94a3d78"), "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "systemreserve@system.co", "System Admin Reserve", null, "$2a$11$ijs7c9x9yHz1oeZ95CF76u1CGALKC3sVeMpGyfzA0U7gWlpH7tmhO", null, null, "systemadminreserve" }
                });

            migrationBuilder.InsertData(
                table: "role_menu_permissions",
                columns: new[] { "id", "can_create", "can_delete", "can_update", "can_view", "created_by", "created_date", "deleted_by", "deleted_date", "menu_id", "role_id", "updated_by", "updated_date" },
                values: new object[,]
                {
                    { new Guid("0281ec0d-8fc8-411d-80ab-644a94cf02da"), true, true, true, true, "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("77118193-d70c-4e36-97a0-683b9e825569"), new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), null, null },
                    { new Guid("07e87c49-180f-4f00-99e2-7322c0638a2d"), false, false, false, true, "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f0663ca2-ffb8-42c2-b022-38479c7c84af"), new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), null, null },
                    { new Guid("437ec283-d081-46f4-9f36-a1ffe8753566"), false, false, false, true, "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f45e2f20-e6c3-4d82-b0d9-e91469103672"), new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), null, null },
                    { new Guid("64f03301-c574-46c2-b1e6-2922eaaa826a"), false, false, false, true, "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("8f735cdf-bd01-4ae3-89c6-b122bdd59b8b"), new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), null, null },
                    { new Guid("702e4653-2abc-41f1-86f5-c1543ab7d585"), true, true, true, true, "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("5026c85e-04f4-4d65-9fd2-bff26ad90013"), new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), null, null }
                });

            migrationBuilder.InsertData(
                table: "user_groups",
                columns: new[] { "id", "created_by", "created_date", "deleted_by", "deleted_date", "role_id", "updated_by", "updated_date", "user_id" },
                values: new object[,]
                {
                    { new Guid("12ae4f23-8457-4e71-898a-4d36aa2611b2"), "System", new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("91e4aa02-8c2f-4074-9a47-5e33d7ab641c"), null, null, new Guid("c3e20f8e-92a7-4c19-90a2-7fb66fd1b6b1") },
                    { new Guid("d8ffb78d-185c-4d2a-9ad3-52577dcd9392"), "System", new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("f5105f3d-579f-42d8-be30-5b78249cba45"), null, null, new Guid("f7a74c57-8968-4b3a-91e5-38b2f6aef91c") },
                    { new Guid("ec211d37-2400-4877-8696-62ac17faeecb"), "System", new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), null, null, new Guid("81314787-537b-474f-999a-9152c9703bbb") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_role_menu_permissions_menu_id",
                table: "role_menu_permissions",
                column: "menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_menu_permissions_role_id",
                table: "role_menu_permissions",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_animal_id",
                table: "transactions",
                column: "animal_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_user_id",
                table: "transactions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_groups_role_id",
                table: "user_groups",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_groups_user_id",
                table: "user_groups",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app_configurations");

            migrationBuilder.DropTable(
                name: "audit_logs");

            migrationBuilder.DropTable(
                name: "role_menu_permissions");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "user_groups");

            migrationBuilder.DropTable(
                name: "user_sessions");

            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropTable(
                name: "animals");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
