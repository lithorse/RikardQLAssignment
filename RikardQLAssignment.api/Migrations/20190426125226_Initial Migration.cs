using Microsoft.EntityFrameworkCore.Migrations;

namespace RikardQLAssignment.api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { "0", "41.7325", "49.9469" },
                    { "1", "36.4511", "28.2278" },
                    { "2", "44.244167", "7.769444" },
                    { "3", "59.3293", "18.0686" },
                    { "4", "59.9139", "10.7522" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
