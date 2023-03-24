using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundPlay.Infrastructure.DataAccess.Migrations.Shopping
{
    /// <inheritdoc />
    public partial class AddProductTypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "BasketItems");
        }
    }
}
