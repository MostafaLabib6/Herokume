using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herokume.Persisitance.Migrations
{
    /// <inheritdoc />
    public partial class initcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowInSlides = table.Column<bool>(type: "bit", nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    AddToWatchList = table.Column<bool>(type: "bit", nullable: false),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorySeries",
                columns: table => new
                {
                    SeriesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    categoriesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySeries", x => new { x.SeriesID, x.categoriesID });
                    table.ForeignKey(
                        name: "FK_CategorySeries_Categories_categoriesID",
                        column: x => x.categoriesID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySeries_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    EpisodeURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    SeriesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Episodes_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedSeries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    SeriesID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedSeries_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SeriesTag",
                columns: table => new
                {
                    SeriesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesTag", x => new { x.SeriesID, x.TagsID });
                    table.ForeignKey(
                        name: "FK_SeriesTag_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesTag_Tags_TagsID",
                        column: x => x.TagsID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriesID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EpisodeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ResponseToID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ResponseToID",
                        column: x => x.ResponseToID,
                        principalTable: "Comments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Comments_Episodes_EpisodeID",
                        column: x => x.EpisodeID,
                        principalTable: "Episodes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Comments_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CommentResponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentResponses_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorySeries_categoriesID",
                table: "CategorySeries",
                column: "categoriesID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentResponses_CommentId",
                table: "CommentResponses",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EpisodeID",
                table: "Comments",
                column: "EpisodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ResponseToID",
                table: "Comments",
                column: "ResponseToID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SeriesID",
                table: "Comments",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeriesID",
                table: "Episodes",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedSeries_SeriesID",
                table: "RelatedSeries",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesTag_TagsID",
                table: "SeriesTag",
                column: "TagsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorySeries");

            migrationBuilder.DropTable(
                name: "CommentResponses");

            migrationBuilder.DropTable(
                name: "RelatedSeries");

            migrationBuilder.DropTable(
                name: "SeriesTag");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
