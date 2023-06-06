using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ForumApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateAndSeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[,]
                {
                    { new Guid("05ac22b6-fb4e-4a14-a3d6-b31a12b046d0"), "Calling all bookworms! 📚🐛 Dive into the enchanting world of fantasy with our top 5 must-read novels. #BookLovers #FantasyBooks", "My Second post" },
                    { new Guid("24c12ad1-9635-4b8d-9db7-d27637e4febb"), "Discover the secrets of mindfulness and unlock inner peace in just 10 minutes a day. 🌸🧘‍♀️ #Mindfulness #InnerPeace", "My first post" },
                    { new Guid("6fc4fc5d-1de4-4c89-9fd0-070f4e13bea0"), "Boost your productivity and conquer your goals with these 5 powerful morning habits. 🌞💪 #ProductivityTips #MorningRoutine", "My third post" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
