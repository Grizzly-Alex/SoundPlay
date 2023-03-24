using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    Name = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuitarCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuitarShapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "varchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "varchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "varchar(max)", nullable: false)
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
                    FretsCount = table.Column<byte>(type: "tinyint", nullable: false),
                    StringsCount = table.Column<byte>(type: "tinyint", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ShapeId = table.Column<int>(type: "int", nullable: true),
                    SoundboardId = table.Column<int>(type: "int", nullable: false),
                    NeckId = table.Column<int>(type: "int", nullable: false),
                    FretboardId = table.Column<int>(type: "int", nullable: false),
                    TremoloTypeId = table.Column<int>(type: "int", nullable: true),
                    PickupSetId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(max)", nullable: false),
                    Stock = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    PictureUrl = table.Column<string>(type: "varchar(max)", nullable: true),
                    DateDelivery = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guitars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guitars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guitars_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guitars_GuitarCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "GuitarCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guitars_GuitarShapes_ShapeId",
                        column: x => x.ShapeId,
                        principalTable: "GuitarShapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guitars_Materials_FretboardId",
                        column: x => x.FretboardId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guitars_Materials_NeckId",
                        column: x => x.NeckId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guitars_Materials_SoundboardId",
                        column: x => x.SoundboardId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guitars_PickupSets_PickupSetId",
                        column: x => x.PickupSetId,
                        principalTable: "PickupSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guitars_TremoloTypes_TremoloTypeId",
                        column: x => x.TremoloTypeId,
                        principalTable: "TremoloTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "GuitarCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electric Guitar" },
                    { 2, "Accoustic Guitar" },
                    { 3, "Classic Guitar" },
                    { 4, "Electric Bass" },
                    { 5, "Accoustic Bass" },
                    { 6, "Ukulele" }
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
                name: "Colors");

            migrationBuilder.DropTable(
                name: "GuitarCategories");

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
