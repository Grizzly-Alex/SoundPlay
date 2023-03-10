using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundPlay.Infrastructure.DataAccess.Migrations.Catalog
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuitarShapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarShapes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PickupSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickupSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TremoloTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TremoloTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guitars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrestCount = table.Column<int>(type: "int", nullable: false),
                    StringsCount = table.Column<int>(type: "int", nullable: false),
                    ShapeId = table.Column<int>(type: "int", nullable: true),
                    SoundboardId = table.Column<int>(type: "int", nullable: true),
                    NeckId = table.Column<int>(type: "int", nullable: true),
                    FretboardId = table.Column<int>(type: "int", nullable: true),
                    TremoloTypeId = table.Column<int>(type: "int", nullable: true),
                    PickupSetId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDelivery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guitars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guitars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Guitars_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Guitars_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Guitars_GuitarShapes_ShapeId",
                        column: x => x.ShapeId,
                        principalTable: "GuitarShapes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Guitars_Materials_FretboardId",
                        column: x => x.FretboardId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Guitars_Materials_NeckId",
                        column: x => x.NeckId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Guitars_Materials_SoundboardId",
                        column: x => x.SoundboardId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Guitars_PickupSets_PickupSetId",
                        column: x => x.PickupSetId,
                        principalTable: "PickupSets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Guitars_TremoloTypes_TremoloTypeId",
                        column: x => x.TremoloTypeId,
                        principalTable: "TremoloTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_BrandId",
                table: "Guitars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_CategoryId",
                table: "Guitars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_ColorId",
                table: "Guitars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_FretboardId",
                table: "Guitars",
                column: "FretboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_NeckId",
                table: "Guitars",
                column: "NeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_PickupSetId",
                table: "Guitars",
                column: "PickupSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_ShapeId",
                table: "Guitars",
                column: "ShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_SoundboardId",
                table: "Guitars",
                column: "SoundboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_TremoloTypeId",
                table: "Guitars",
                column: "TremoloTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guitars");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "GuitarShapes");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "PickupSets");

            migrationBuilder.DropTable(
                name: "TremoloTypes");
        }
    }
}
