using Microsoft.EntityFrameworkCore.Migrations;

namespace Registrera.se.Data.Migrations
{
    public partial class userID_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Places_placeId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_teacherId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "teacherId",
                table: "Courses",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "placeId",
                table: "Courses",
                newName: "PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_teacherId",
                table: "Courses",
                newName: "IX_Courses_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_placeId",
                table: "Courses",
                newName: "IX_Courses_PlaceId");

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Places_PlaceId",
                table: "Courses",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Places_PlaceId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Courses",
                newName: "teacherId");

            migrationBuilder.RenameColumn(
                name: "PlaceId",
                table: "Courses",
                newName: "placeId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                newName: "IX_Courses_teacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_PlaceId",
                table: "Courses",
                newName: "IX_Courses_placeId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Places_placeId",
                table: "Courses",
                column: "placeId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_teacherId",
                table: "Courses",
                column: "teacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
