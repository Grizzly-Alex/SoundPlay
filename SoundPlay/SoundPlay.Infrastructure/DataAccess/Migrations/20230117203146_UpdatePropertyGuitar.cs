using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundPlay.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropertyGuitar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FrestCount",
                table: "Guitars",
                newName: "FretsCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FretsCount",
                table: "Guitars",
                newName: "FrestCount");
        }
    }
}
