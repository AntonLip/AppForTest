using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace testapp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ResultTheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4481c473-cef8-401f-b7f9-0c5b5755b314");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7920992-9623-49d6-85eb-341252b26b2f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2853c644-d284-4807-bc56-1579e2eb46ba", "d341bb2f-8332-4da6-88c2-f9504638e041" });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("bf3deb49-aa42-4343-9780-4f103cb1da46"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("f74e0980-af2e-4920-b992-69a0c22a64e3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2853c644-d284-4807-bc56-1579e2eb46ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d341bb2f-8332-4da6-88c2-f9504638e041");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "DisciplineId",
                table: "Results",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResultThemeId",
                table: "Results",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00494209-3c3e-4fb4-8144-46977b135494", "1", "Admin", "ADMIN" },
                    { "52f3b0de-19d9-45b8-ad8a-de3d003225b0", "2", "Курсант", "КУРСАНТ" },
                    { "b6e0d57c-df78-4013-b10a-909325d99a1f", "2", "Преподаватель", "ПРЕПОДАВАТЕЛЬ" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "GroupId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "39294a65-2615-42e0-90b2-c3d13aa2e1ab", 0, "avadvd", "admin@gmail.com", true, "Admin", new Guid("f81e67db-dbed-4c1e-9162-8cab6fbd0028"), "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEAleKrasHx1wgYAJ8abELUkwdXHh0HXsgcymu+dVyzUCHME9nvwlFw2RCvE65RE/Rw==", "1234567890", false, "avebgdfvs", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("385ebe9e-317a-4b90-af0f-169899695cf8"), "Преподаватели" },
                    { new Guid("f81e67db-dbed-4c1e-9162-8cab6fbd0028"), "444" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "00494209-3c3e-4fb4-8144-46977b135494", "39294a65-2615-42e0-90b2-c3d13aa2e1ab" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52f3b0de-19d9-45b8-ad8a-de3d003225b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6e0d57c-df78-4013-b10a-909325d99a1f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "00494209-3c3e-4fb4-8144-46977b135494", "39294a65-2615-42e0-90b2-c3d13aa2e1ab" });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("385ebe9e-317a-4b90-af0f-169899695cf8"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("f81e67db-dbed-4c1e-9162-8cab6fbd0028"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00494209-3c3e-4fb4-8144-46977b135494");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39294a65-2615-42e0-90b2-c3d13aa2e1ab");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "ResultThemeId",
                table: "Results");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2853c644-d284-4807-bc56-1579e2eb46ba", "1", "Admin", "ADMIN" },
                    { "4481c473-cef8-401f-b7f9-0c5b5755b314", "2", "Преподаватель", "ПРЕПОДАВАТЕЛЬ" },
                    { "a7920992-9623-49d6-85eb-341252b26b2f", "2", "Курсант", "КУРСАНТ" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "GroupId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d341bb2f-8332-4da6-88c2-f9504638e041", 0, "avadvd", "admin@gmail.com", true, "Admin", new Guid("f74e0980-af2e-4920-b992-69a0c22a64e3"), "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEK39ekBmuutq+KBqu0JNwG/neLqkO6tstJWDMijAsL76BLHywWoxtsInsXpTr+Wl8g==", "1234567890", false, null, "avebgdfvs", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("bf3deb49-aa42-4343-9780-4f103cb1da46"), "Преподаватели" },
                    { new Guid("f74e0980-af2e-4920-b992-69a0c22a64e3"), "444" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2853c644-d284-4807-bc56-1579e2eb46ba", "d341bb2f-8332-4da6-88c2-f9504638e041" });
        }
    }
}
