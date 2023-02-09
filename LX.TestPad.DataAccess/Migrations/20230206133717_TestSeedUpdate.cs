using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LX.TestPad.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TestSeedUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText("../LX.TestPad.DataAccess/Seedings/TestSeedUpdate.sql"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText("../LX.TestPad.DataAccess/Seedings/Rollback_TestSeedUpdate.sql"));
        }
    }
}
