using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoundPlay.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGuitarCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropColumn(
                name: "category",
                table: "Guitars");

            migrationBuilder.AddColumn<int>(
                name: "category_id",
                table: "Guitars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GuitarCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarCategories", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "GuitarCategories",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 0, "Electric Guitar" },
                    { 1, "Accoustic Guitar" },
                    { 2, "Classic Guitar" },
                    { 3, "Electric Bass" },
                    { 4, "Accoustic Bass" },
                    { 5, "Ukulele" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_category_id",
                table: "Guitars",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_GuitarCategories_category_id",
                table: "Guitars",
                column: "category_id",
                principalTable: "GuitarCategories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_GuitarCategories_category_id",
                table: "Guitars");

            migrationBuilder.DropTable(
                name: "GuitarCategories");

            migrationBuilder.DropIndex(
                name: "IX_Guitars_category_id",
                table: "Guitars");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "Guitars");

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Guitars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });
        }
    }
}
