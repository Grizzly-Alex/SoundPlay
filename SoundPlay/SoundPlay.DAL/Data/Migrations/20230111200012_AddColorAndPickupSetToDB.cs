using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundPlay.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColorAndPickupSetToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ColorId", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "PickupConfigurations",
                columns: table => new
                {
                    PickupConfigurationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickupConfigurationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PickupConfigurationId", x => x.PickupConfigurationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "PickupConfigurations");
        }
    }
}
