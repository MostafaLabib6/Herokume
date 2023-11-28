using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herokume.Persisitance.Migrations
{
    /// <inheritdoc />
    public partial class updateResponsetoColumninCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
