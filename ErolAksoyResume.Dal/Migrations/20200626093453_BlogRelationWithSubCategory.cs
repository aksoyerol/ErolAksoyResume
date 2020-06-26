using Microsoft.EntityFrameworkCore.Migrations;

namespace ErolAksoyResume.Dal.Migrations
{
    public partial class BlogRelationWithSubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Blogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_SubCategoryId",
                table: "Blogs",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_SubCategories_SubCategoryId",
                table: "Blogs",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_SubCategories_SubCategoryId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_SubCategoryId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Blogs");
        }
    }
}
