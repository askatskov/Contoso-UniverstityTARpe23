using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoUniverstity.Migrations
{
    /// <inheritdoc />
    public partial class editbutrfaaFFAafsffasa4agadaf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Student_StudentId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_StudentId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Department");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_StatusId",
                table: "Department",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Student_StatusId",
                table: "Department",
                column: "StatusId",
                principalTable: "Student",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Student_StatusId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_StatusId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Department");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Department_StudentId",
                table: "Department",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Student_StudentId",
                table: "Department",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
