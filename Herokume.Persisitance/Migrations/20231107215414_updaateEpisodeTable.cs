using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herokume.Persisitance.Migrations
{
    /// <inheritdoc />
    public partial class updaateEpisodeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Series_SeriesID",
                table: "Episodes");

            migrationBuilder.RenameColumn(
                name: "SeriesID",
                table: "Episodes",
                newName: "SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_SeriesID",
                table: "Episodes",
                newName: "IX_Episodes_SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Series_SeriesId",
                table: "Episodes",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Series_SeriesId",
                table: "Episodes");

            migrationBuilder.RenameColumn(
                name: "SeriesId",
                table: "Episodes",
                newName: "SeriesID");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_SeriesId",
                table: "Episodes",
                newName: "IX_Episodes_SeriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Series_SeriesID",
                table: "Episodes",
                column: "SeriesID",
                principalTable: "Series",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
