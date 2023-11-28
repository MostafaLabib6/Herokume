using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Herokume.Persisitance.Migrations
{
    /// <inheritdoc />
    public partial class updateCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("75f2a015-c141-47af-85cf-3679a7903475"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("d9e54f91-df02-4cc1-badb-12f89e9c4d71"));

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RelatedSeries",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CommentResponses",
                newName: "ID");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RelatedSeries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "RelatedSeries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CommentResponses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "CommentResponses",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RelatedSeries");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "RelatedSeries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CommentResponses");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "CommentResponses");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "RelatedSeries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CommentResponses",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreatedAt", "Description", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("75f2a015-c141-47af-85cf-3679a7903475"), null, "Shonen", null, "Shonen" },
                    { new Guid("d9e54f91-df02-4cc1-badb-12f89e9c4d71"), null, "Romans", null, "Romans" }
                });
        }
    }
}
