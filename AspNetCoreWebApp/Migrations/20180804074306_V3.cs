using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreWebApp.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
             name: "TestMigrationTable",
             columns: table => new
             {
                 ID = table.Column<int>(nullable: false),
                 Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
             },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestMigrationTable", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestMigrationTable");
        }
    }
}
