using Microsoft.EntityFrameworkCore.Migrations;

namespace ErolAksoyResume.Dal.Migrations
{
    public partial class PortofolioTableAddRelationWithSubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Portofolios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Portofolios_SubCategoryId",
                table: "Portofolios",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portofolios_SubCategories_SubCategoryId",
                table: "Portofolios",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portofolios_SubCategories_SubCategoryId",
                table: "Portofolios");

            migrationBuilder.DropIndex(
                name: "IX_Portofolios_SubCategoryId",
                table: "Portofolios");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Portofolios");
        }
    }
}
