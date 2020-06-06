using Microsoft.EntityFrameworkCore.Migrations;

namespace VegaData.Migrations
{
    public partial class seedingdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES('Make2')");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES('Make1-ModelA', (SELECT Id FROM Makes WHERE NAME = 'Make1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES('Make1-ModelB', (SELECT Id FROM Makes WHERE NAME = 'Make1'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES('Make2-ModelA', (SELECT Id FROM Makes WHERE NAME = 'Make2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES('Make2-ModelB', (SELECT Id FROM Makes WHERE NAME = 'Make2'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE Name in ('Make1', 'Make2', 'Make3')");
        }
    }
}
