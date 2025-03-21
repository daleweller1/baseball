using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Baseball.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Games = table.Column<int>(type: "int", nullable: false),
                    AtBats = table.Column<int>(type: "int", nullable: false),
                    Runs = table.Column<int>(type: "int", nullable: false),
                    Hits = table.Column<int>(type: "int", nullable: false),
                    Doubles = table.Column<int>(type: "int", nullable: false),
                    Triples = table.Column<int>(type: "int", nullable: false),
                    HomeRuns = table.Column<int>(type: "int", nullable: false),
                    RBIs = table.Column<int>(type: "int", nullable: false),
                    Walks = table.Column<int>(type: "int", nullable: false),
                    Strikeouts = table.Column<int>(type: "int", nullable: false),
                    StolenBases = table.Column<int>(type: "int", nullable: false),
                    CaughtStealing = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "0"),
                    AVG = table.Column<double>(type: "float", nullable: false),
                    OnBasePercentage = table.Column<double>(type: "float", nullable: false),
                    SluggingPercentage = table.Column<double>(type: "float", nullable: false),
                    OPS = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
