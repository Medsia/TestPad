using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LX.TestPad.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionIdToResultAnswerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "ResultAnswers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "ResultAnswers");
        }
    }
}
