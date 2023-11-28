using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Herokume.Persisitance.Migrations
{
    /// <inheritdoc />
    public partial class seedcategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreatedAt", "Description", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("75f2a015-c141-47af-85cf-3679a7903475"), null, "Shonen", null, "Shonen" },
                    { new Guid("d9e54f91-df02-4cc1-badb-12f89e9c4d71"), null, "Romans", null, "Romans" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("75f2a015-c141-47af-85cf-3679a7903475"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("d9e54f91-df02-4cc1-badb-12f89e9c4d71"));
        }
    }
}
