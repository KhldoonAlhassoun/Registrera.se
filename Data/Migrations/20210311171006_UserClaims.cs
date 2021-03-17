using Microsoft.EntityFrameworkCore.Migrations;

namespace Registrera.se.Data.Migrations
{
    public partial class UserClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Places_PlaceId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Courses",
                newName: "Teacher");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Teacher",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Courses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Courses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "Courses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Places_PlaceId",
                table: "Courses",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Places_PlaceId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "School",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Teacher",
                table: "Courses",
                newName: "TeacherId");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Places_PlaceId",
                table: "Courses",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
