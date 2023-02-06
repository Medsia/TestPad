using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LX.TestPad.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeSec",
                table: "Tests",
                newName: "TestDuration");

            migrationBuilder.RenameColumn(
                name: "FinisedAt",
                table: "Results",
                newName: "FinishedAt");

            var sqlFile = Path.Combine("../LX.TestPad.DataAccess/Seedings/SeedUp.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestDuration",
                table: "Tests",
                newName: "TimeSec");

            migrationBuilder.RenameColumn(
                name: "FinishedAt",
                table: "Results",
                newName: "FinisedAt");

            var sqlFile = Path.Combine("../LX.TestPad.DataAccess/Seedings/SeedDown.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }
    }
}
