using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class saveBaseQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_Tests_TestId",
                table: "TestQuestion");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestion_BaseQuestionId",
                table: "TestQuestion");

            migrationBuilder.DropColumn(
                name: "Gamipoints",
                table: "Tests");

            migrationBuilder.AddColumn<bool>(
                name: "AllowPowerUps",
                table: "Tests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "TestQuestion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestion_BaseQuestionId",
                table: "TestQuestion",
                column: "BaseQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_Tests_TestId",
                table: "TestQuestion",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_Tests_TestId",
                table: "TestQuestion");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestion_BaseQuestionId",
                table: "TestQuestion");

            migrationBuilder.DropColumn(
                name: "AllowPowerUps",
                table: "Tests");

            migrationBuilder.AddColumn<int>(
                name: "Gamipoints",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "TestQuestion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestion_BaseQuestionId",
                table: "TestQuestion",
                column: "BaseQuestionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_Tests_TestId",
                table: "TestQuestion",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id");
        }
    }
}
