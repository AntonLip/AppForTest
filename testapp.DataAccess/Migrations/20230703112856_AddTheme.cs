using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace testapp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Disciplines_DisciplinesId",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b00aebb-0594-4888-bc43-234d6b45e533");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e49235e1-7a15-4505-abb4-31c5de8111b6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4ccb9fc8-2da9-45c0-a0d3-3f99eb3a8190", "8397452c-9c80-4d5d-9bf0-81f38498d6d7" });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("7769ca4f-c8c6-4618-b4d0-3385dfa9e7b0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ccb9fc8-2da9-45c0-a0d3-3f99eb3a8190");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8397452c-9c80-4d5d-9bf0-81f38498d6d7");

            migrationBuilder.RenameColumn(
                name: "DisciplinesId",
                table: "Questions",
                newName: "ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_DisciplinesId",
                table: "Questions",
                newName: "IX_Questions_ThemeId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Theme",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisciplinesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Theme_Disciplines_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4bde18a6-a1be-4464-bb74-d7751706fdf9", "2", "Курсант", "КУРСАНТ" },
                    { "ad7dbd34-c17a-47e0-a198-fb2ce65201e6", "2", "Преподаватель", "ПРЕПОДАВАТЕЛЬ" },
                    { "ec9da2b5-f7c1-4194-b6c8-559e6bd38631", "1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "GroupId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5491b35e-4716-4825-9fcc-7ffbdfff4b0b", 0, "avadvd", "admin@gmail.com", true, "Admin", new Guid("2cec1474-42f1-4a52-8160-846eeae5ae97"), "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEFI9rBQlkgAsiO71n+aL+gUUt0CntMlShzUIflxITkoeM6XB/hUOWSqexbNNV2uGAQ==", "1234567890", false, null, "avebgdfvs", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2cec1474-42f1-4a52-8160-846eeae5ae97"), "444" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ec9da2b5-f7c1-4194-b6c8-559e6bd38631", "5491b35e-4716-4825-9fcc-7ffbdfff4b0b" });

            migrationBuilder.CreateIndex(
                name: "IX_Theme_DisciplinesId",
                table: "Theme",
                column: "DisciplinesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Theme_ThemeId",
                table: "Questions",
                column: "ThemeId",
                principalTable: "Theme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Theme_ThemeId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Theme");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bde18a6-a1be-4464-bb74-d7751706fdf9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad7dbd34-c17a-47e0-a198-fb2ce65201e6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ec9da2b5-f7c1-4194-b6c8-559e6bd38631", "5491b35e-4716-4825-9fcc-7ffbdfff4b0b" });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("2cec1474-42f1-4a52-8160-846eeae5ae97"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec9da2b5-f7c1-4194-b6c8-559e6bd38631");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5491b35e-4716-4825-9fcc-7ffbdfff4b0b");

            migrationBuilder.RenameColumn(
                name: "ThemeId",
                table: "Questions",
                newName: "DisciplinesId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_ThemeId",
                table: "Questions",
                newName: "IX_Questions_DisciplinesId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b00aebb-0594-4888-bc43-234d6b45e533", "2", "Курсант", "КУРСАНТ" },
                    { "4ccb9fc8-2da9-45c0-a0d3-3f99eb3a8190", "1", "Admin", "ADMIN" },
                    { "e49235e1-7a15-4505-abb4-31c5de8111b6", "2", "Преподаватель", "ПРЕПОДАВАТЕЛЬ" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "GroupId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8397452c-9c80-4d5d-9bf0-81f38498d6d7", 0, "avadvd", "admin@gmail.com", true, "Admin", new Guid("7769ca4f-c8c6-4618-b4d0-3385dfa9e7b0"), "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEMOso1SOXqX93O5IVMoUF7vNTOiW/5yxCIWo3Wua/BTURrnrj6lvqO2FSF095kUY0g==", "1234567890", false, null, "avebgdfvs", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("7769ca4f-c8c6-4618-b4d0-3385dfa9e7b0"), "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4ccb9fc8-2da9-45c0-a0d3-3f99eb3a8190", "8397452c-9c80-4d5d-9bf0-81f38498d6d7" });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Disciplines_DisciplinesId",
                table: "Questions",
                column: "DisciplinesId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
