using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LX.TestPad.Migrations
{
    /// <inheritdoc />
    public partial class NumTestQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "TestQuestion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "TestQuestion");
        }
    }
}
