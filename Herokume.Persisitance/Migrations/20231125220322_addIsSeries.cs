using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herokume.Persisitance.Migrations
{
    /// <inheritdoc />
    public partial class addIsSeries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSeries",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSeries",
                table: "Comments");
        }
    }
}
