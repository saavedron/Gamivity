using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class generalClassUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralClass_Classes_ClassId",
                table: "GeneralClass");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Students_StudentID",
                table: "StudentClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneralClass",
                table: "GeneralClass");

            migrationBuilder.DropIndex(
                name: "IX_GeneralClass_ClassId",
                table: "GeneralClass");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "GeneralClass");

            migrationBuilder.RenameTable(
                name: "GeneralClass",
                newName: "GeneralClasses");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "StudentClasses",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "GeneralClasses",
                newName: "GeneralClassName");

            migrationBuilder.AddColumn<int>(
                name: "GeneralClassId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneralClasses",
                table: "GeneralClasses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_GeneralClassId",
                table: "Classes",
                column: "GeneralClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_GeneralClasses_GeneralClassId",
                table: "Classes",
                column: "GeneralClassId",
                principalTable: "GeneralClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Students_StudentId",
                table: "StudentClasses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_GeneralClasses_GeneralClassId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Students_StudentId",
                table: "StudentClasses");

            migrationBuilder.DropIndex(
                name: "IX_Classes_GeneralClassId",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneralClasses",
                table: "GeneralClasses");

            migrationBuilder.DropColumn(
                name: "GeneralClassId",
                table: "Classes");

            migrationBuilder.RenameTable(
                name: "GeneralClasses",
                newName: "GeneralClass");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentClasses",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "GeneralClassName",
                table: "GeneralClass",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "GeneralClass",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneralClass",
                table: "GeneralClass",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralClass_ClassId",
                table: "GeneralClass",
                column: "ClassId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralClass_Classes_ClassId",
                table: "GeneralClass",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Students_StudentID",
                table: "StudentClasses",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
