using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LX.TestPad.Migrations
{
    /// <inheritdoc />
    public partial class IsCorrectResultAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "ResultAnswers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "ResultAnswers");
        }
    }
}
