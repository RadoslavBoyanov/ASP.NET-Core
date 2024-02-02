using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id for the news category."),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Name of the news category."),
                    Content = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Content for the category.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journalists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id of the journalist."),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the journalist."),
                    Email = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Email of the journalist.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journalists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id of article."),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Title of the article."),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "Content of the article."),
                    PublishDate = table.Column<DateTime>(name: "Publish Date", type: "datetime2", nullable: false, comment: "Date of publish for the article."),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id of the category of article."),
                    JournalistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id of the journalist writed the article.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Journalists_JournalistId",
                        column: x => x.JournalistId,
                        principalTable: "Journalists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesJournalists",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesJournalists", x => new { x.CategoryId, x.JournalistId });
                    table.ForeignKey(
                        name: "FK_CategoriesJournalists_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesJournalists_Journalists_JournalistId",
                        column: x => x.JournalistId,
                        principalTable: "Journalists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_JournalistId",
                table: "Articles",
                column: "JournalistId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesJournalists_JournalistId",
                table: "CategoriesJournalists",
                column: "JournalistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "CategoriesJournalists");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Journalists");
        }
    }
}
