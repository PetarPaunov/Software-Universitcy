using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Core.Data.Migrations
{
    public partial class SeededDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 13, 23, 59, 18, 247, DateTimeKind.Local).AddTicks(4124), "Lern using ASP.NET Core identity", "db69cbba-e2ba-4889-a362-eb04a8c40d34", "Prepare for ASP.NET fundamentals Exam" },
                    { 2, 3, new DateTime(2022, 9, 13, 23, 59, 18, 247, DateTimeKind.Local).AddTicks(4201), "Lern using EF Core and MSSQL", "db69cbba-e2ba-4889-a362-eb04a8c40d34", "Improve EF Core skills" },
                    { 3, 2, new DateTime(2022, 9, 13, 23, 59, 18, 247, DateTimeKind.Local).AddTicks(4204), "Lern using ASP.NET Core Identity", "db69cbba-e2ba-4889-a362-eb04a8c40d34", "Improve ASP.NET Core skills" },
                    { 4, 3, new DateTime(2022, 9, 13, 23, 59, 18, 247, DateTimeKind.Local).AddTicks(4206), "Resurching", "db69cbba-e2ba-4889-a362-eb04a8c40d34", "Prepere for finel project" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "db69cbba-e2ba-4889-a362-eb04a8c40d34", 0, "56e156fb-0c3b-43cc-95a9-ab0103f2ac44", "test@abv.bg", false, "Guest", "User", false, null, "TEST@ABV.BG", "USER", "AQAAAAEAACcQAAAAEEtxm2EU7nSFVTN43iBQXgCzZ/p+KgnBVE9wooGb+et03CAsN+zFmkXNXlo9YHkp3A==", null, false, "b4b3fe84-5bff-49a6-806a-fc6dbf861242", false, "User" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });
        }
    }
}
