using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class AddTablesAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("350a69ab-6e04-4178-8f42-dbe7f253dda9"), 1, new DateTime(2023, 7, 21, 12, 16, 5, 389, DateTimeKind.Utc).AddTicks(4126), "Implement better styling for all public pages", "c544d269-4891-459b-b841-dcdc6f11f755", "Improve CSS styles" },
                    { new Guid("bd75171c-ac58-4ab9-9fde-38d696522849"), 1, new DateTime(2023, 9, 6, 12, 16, 5, 389, DateTimeKind.Utc).AddTicks(4159), "Create Android client App for the RESTful TaskBoard service", "af2558e7-083d-487b-8583-42fe65ce8360", "Android Client App" },
                    { new Guid("d915e16b-c27d-4c2c-9732-8ced0bf6647a"), 2, new DateTime(2024, 1, 6, 12, 16, 5, 389, DateTimeKind.Utc).AddTicks(4166), "Create Desktop client App for the RESTful TaskBoard service", "c544d269-4891-459b-b841-dcdc6f11f755", "Desktop Client App" },
                    { new Guid("e9d171ac-b2ba-48fd-af34-74ca3a132e72"), 3, new DateTime(2023, 2, 6, 12, 16, 5, 389, DateTimeKind.Utc).AddTicks(4170), "Implement [Create Task] page for adding tasks", "c544d269-4891-459b-b841-dcdc6f11f755", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
