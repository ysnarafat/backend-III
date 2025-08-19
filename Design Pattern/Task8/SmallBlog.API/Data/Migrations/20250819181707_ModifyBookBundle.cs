using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallBlog.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyBookBundle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookBundle_Books_BookId",
                table: "BookBundle");

            migrationBuilder.DropForeignKey(
                name: "FK_BookBundle_Bundles_BundleId",
                table: "BookBundle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookBundle",
                table: "BookBundle");

            migrationBuilder.RenameTable(
                name: "BookBundle",
                newName: "BookBundles");

            migrationBuilder.RenameIndex(
                name: "IX_BookBundle_BundleId",
                table: "BookBundles",
                newName: "IX_BookBundles_BundleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookBundles",
                table: "BookBundles",
                columns: new[] { "BookId", "BundleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookBundles_Books_BookId",
                table: "BookBundles",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookBundles_Bundles_BundleId",
                table: "BookBundles",
                column: "BundleId",
                principalTable: "Bundles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookBundles_Books_BookId",
                table: "BookBundles");

            migrationBuilder.DropForeignKey(
                name: "FK_BookBundles_Bundles_BundleId",
                table: "BookBundles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookBundles",
                table: "BookBundles");

            migrationBuilder.RenameTable(
                name: "BookBundles",
                newName: "BookBundle");

            migrationBuilder.RenameIndex(
                name: "IX_BookBundles_BundleId",
                table: "BookBundle",
                newName: "IX_BookBundle_BundleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookBundle",
                table: "BookBundle",
                columns: new[] { "BookId", "BundleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookBundle_Books_BookId",
                table: "BookBundle",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookBundle_Bundles_BundleId",
                table: "BookBundle",
                column: "BundleId",
                principalTable: "Bundles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
