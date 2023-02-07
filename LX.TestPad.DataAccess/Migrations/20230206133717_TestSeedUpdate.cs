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
            var sqlFile1 = Path.Combine("../LX.TestPad.DataAccess/Seedings/SeedUp.sql");           
            var sqlFile2 = Path.Combine("../LX.TestPad.DataAccess/Seedings/SeedUpTestUpdate.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile1));
            migrationBuilder.Sql(File.ReadAllText(sqlFile2));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sqlFile1 = Path.Combine("../LX.TestPad.DataAccess/Seedings/SeedDown.sql");        
            var sqlFile2 = Path.Combine("../LX.TestPad.DataAccess/Seedings/SeedDownTestUpdate.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile1));
            migrationBuilder.Sql(File.ReadAllText(sqlFile2));
        }
    }
}
