using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herokume.Persisitance.Migrations
{
    /// <inheritdoc />
    public partial class updateComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentResponses");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ResponseTo",
                table: "Comments",
                newName: "ResponseToID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ResponseToID",
                table: "Comments",
                column: "ResponseToID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ResponseToID",
                table: "Comments",
                column: "ResponseToID",
                principalTable: "Comments",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ResponseToID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ResponseToID",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ResponseToID",
                table: "Comments",
                newName: "ResponseTo");

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Comments",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "CommentResponses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentResponses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentResponses_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentResponses_CommentId",
                table: "CommentResponses",
                column: "CommentId");
        }
    }
}
