using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VarsityManagementAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseStudents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CourseStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
