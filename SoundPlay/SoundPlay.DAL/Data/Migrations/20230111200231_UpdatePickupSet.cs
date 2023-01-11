using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundPlay.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePickupSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PickupConfigurationId",
                table: "PickupConfigurations");

            migrationBuilder.RenameTable(
                name: "PickupConfigurations",
                newName: "PickupSets");

            migrationBuilder.RenameColumn(
                name: "PickupConfigurationName",
                table: "PickupSets",
                newName: "PickupSetName");

            migrationBuilder.RenameColumn(
                name: "PickupConfigurationId",
                table: "PickupSets",
                newName: "PickupSetId");

            migrationBuilder.AddPrimaryKey(
                name: "PickupSetId",
                table: "PickupSets",
                column: "PickupSetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PickupSetId",
                table: "PickupSets");

            migrationBuilder.RenameTable(
                name: "PickupSets",
                newName: "PickupConfigurations");

            migrationBuilder.RenameColumn(
                name: "PickupSetName",
                table: "PickupConfigurations",
                newName: "PickupConfigurationName");

            migrationBuilder.RenameColumn(
                name: "PickupSetId",
                table: "PickupConfigurations",
                newName: "PickupConfigurationId");

            migrationBuilder.AddPrimaryKey(
                name: "PickupConfigurationId",
                table: "PickupConfigurations",
                column: "PickupConfigurationId");
        }
    }
}
