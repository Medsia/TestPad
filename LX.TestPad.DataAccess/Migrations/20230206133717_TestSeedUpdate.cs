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
            var sqlFile = Path.Combine("../LX.TestPad.DataAccess/Seedings/SeedUpTestUpdate.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine("../LX.TestPad.DataAccess/Seedings/SeedDownTestUpdate.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }
    }
}
