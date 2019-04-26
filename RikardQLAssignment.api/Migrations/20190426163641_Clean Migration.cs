using Microsoft.EntityFrameworkCore.Migrations;

namespace RikardQLAssignment.api.Migrations
{
    public partial class CleanMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Latitude", "Longitude", "Title" },
                values: new object[,]
                {
                    { "0", "41.7325", "49.9469", "Middle of the Caspian sea" },
                    { "1", "36.4511", "28.2278", "Colossus of Rhodes" },
                    { "2", "44.244167", "7.769444", "Pink Rabbit was once here" },
                    { "3", "59.3293", "18.0686", "Stockholm, capital of Sweden" },
                    { "4", "59.9139", "10.7522", "Oslo, capital of Norway" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
