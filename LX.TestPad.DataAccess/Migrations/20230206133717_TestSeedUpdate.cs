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
            migrationBuilder.Sql(File.ReadAllText("../LX.TestPad.DataAccess/Seedings/SeedUp.sql"));
            migrationBuilder.Sql(File.ReadAllText("../LX.TestPad.DataAccess/Seedings/SeedUpTestUpdate.sql"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText("../LX.TestPad.DataAccess/Seedings/SeedDown.sql"));
            migrationBuilder.Sql(File.ReadAllText("../LX.TestPad.DataAccess/Seedings/SeedDownTestUpdate.sql"));
        }
    }
}
