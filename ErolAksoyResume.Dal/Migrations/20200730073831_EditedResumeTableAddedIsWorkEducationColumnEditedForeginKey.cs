using Microsoft.EntityFrameworkCore.Migrations;

namespace ErolAksoyResume.Dal.Migrations
{
    public partial class EditedResumeTableAddedIsWorkEducationColumnEditedForeginKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_SubCategories_SubCategoryId",
                table: "Resumes");

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoryId",
                table: "Resumes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_SubCategories_SubCategoryId",
                table: "Resumes",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_SubCategories_SubCategoryId",
                table: "Resumes");

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoryId",
                table: "Resumes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_SubCategories_SubCategoryId",
                table: "Resumes",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
