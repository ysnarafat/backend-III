using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallBlog.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserPostScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Reputation",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "UserPostSupports",
                columns: table => new
                {
                    SupporterId = table.Column<int>(type: "integer", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PostId1 = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPostSupports", x => new { x.SupporterId, x.PostId });
                    table.ForeignKey(
                        name: "FK_UserPostSupports_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPostSupports_Posts_PostId1",
                        column: x => x.PostId1,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserPostSupports_Users_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPostSupports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPostSupports_PostId",
                table: "UserPostSupports",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostSupports_PostId1",
                table: "UserPostSupports",
                column: "PostId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostSupports_UserId",
                table: "UserPostSupports",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPostSupports");

            migrationBuilder.DropColumn(
                name: "Reputation",
                table: "Users");
        }
    }
}
