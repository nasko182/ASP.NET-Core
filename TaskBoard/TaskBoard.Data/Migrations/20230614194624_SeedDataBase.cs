using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoard.App.Data.Migrations
{
    public partial class SeedDataBase : Migration
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { new Guid("3f7789a6-f2aa-44f5-b46c-3144de75664a"), 2, new DateTime(2023, 5, 2, 19, 46, 24, 242, DateTimeKind.Utc).AddTicks(9906), "Create Desktop Client App", "5e24fcbf-b7ac-4276-8e51-e518945d03dc", "Desktop Client App" },
                    { new Guid("7ac46556-d0cc-4049-9930-941130befe71"), 3, new DateTime(2022, 3, 8, 19, 46, 24, 242, DateTimeKind.Utc).AddTicks(9908), "Implement [Create Task] page for adding new tasks", "5e24fcbf-b7ac-4276-8e51-e518945d03dc", "Create Tasks" },
                    { new Guid("d5de882a-c24b-48e9-ba73-408f741ab981"), 1, new DateTime(2023, 4, 5, 19, 46, 24, 242, DateTimeKind.Utc).AddTicks(9904), "Create Android Client App", "5e24fcbf-b7ac-4276-8e51-e518945d03dc", "Android Client App" },
                    { new Guid("f7b9120f-bff0-4e4a-9597-68f38abb2293"), 1, new DateTime(2022, 11, 26, 19, 46, 24, 242, DateTimeKind.Utc).AddTicks(9893), "Implement Better Styling for all pages", "5e24fcbf-b7ac-4276-8e51-e518945d03dc", "Improve CSS styles" }
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
