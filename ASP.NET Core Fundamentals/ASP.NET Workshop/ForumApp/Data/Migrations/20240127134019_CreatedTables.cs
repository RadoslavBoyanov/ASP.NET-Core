using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.Data.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "IsDelete", "Title" },
                values: new object[] { 1, "My archeology education.", false, "My first Post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "IsDelete", "Title" },
                values: new object[] { 2, "My education in Software University.", false, "My second post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "IsDelete", "Title" },
                values: new object[] { 3, "Books we should read.", false, "My third post" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
