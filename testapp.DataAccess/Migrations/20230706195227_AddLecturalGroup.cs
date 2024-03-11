using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace testapp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddLecturalGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
