using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace testapp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddResultThemeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ResultThemes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultThemes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e4ae23f-1e6f-4246-a954-dd08c2caa6fe", "2", "Преподаватель", "ПРЕПОДАВАТЕЛЬ" },
                    { "980ee95d-f967-43bf-aa4d-e521f8557a89", "2", "Курсант", "КУРСАНТ" },
                    { "c497f7eb-6ef4-4c2e-9fe8-e9a331c23bea", "1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "GroupId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "20678249-20a3-4c50-bea4-31a68b61267a", 0, "avadvd", "admin@gmail.com", true, "Admin", new Guid("8c431959-84b4-4895-b68e-5097c231e360"), "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEA86z3n5kYEBeqAOr3v9ElUN4q1G3mYtmjIiFFixF3CXXLmlU5g05zLabidKqa4vww==", "1234567890", false, "avebgdfvs", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7b56f216-e552-4366-a34d-e075659b5e12"), "Преподаватели" },
                    { new Guid("8c431959-84b4-4895-b68e-5097c231e360"), "444" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c497f7eb-6ef4-4c2e-9fe8-e9a331c23bea", "20678249-20a3-4c50-bea4-31a68b61267a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultThemes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e4ae23f-1e6f-4246-a954-dd08c2caa6fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "980ee95d-f967-43bf-aa4d-e521f8557a89");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c497f7eb-6ef4-4c2e-9fe8-e9a331c23bea", "20678249-20a3-4c50-bea4-31a68b61267a" });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("7b56f216-e552-4366-a34d-e075659b5e12"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("8c431959-84b4-4895-b68e-5097c231e360"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c497f7eb-6ef4-4c2e-9fe8-e9a331c23bea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20678249-20a3-4c50-bea4-31a68b61267a");

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
    }
}
