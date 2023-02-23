using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundPlay.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGuitar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Brands_BrandId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Categories_CategoryId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Colors_ColorId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_GuitarShapes_ShapeId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Materials_FretboardId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Materials_NeckId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Materials_SoundboardId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_PickupSets_PickupSetId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_TremoloTypes_TremoloTypeId",
                table: "Guitars");

            migrationBuilder.AlterColumn<int>(
                name: "SoundboardId",
                table: "Guitars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NeckId",
                table: "Guitars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FretboardId",
                table: "Guitars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Brands_BrandId",
                table: "Guitars",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Categories_CategoryId",
                table: "Guitars",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Colors_ColorId",
                table: "Guitars",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_GuitarShapes_ShapeId",
                table: "Guitars",
                column: "ShapeId",
                principalTable: "GuitarShapes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Materials_FretboardId",
                table: "Guitars",
                column: "FretboardId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Materials_NeckId",
                table: "Guitars",
                column: "NeckId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Materials_SoundboardId",
                table: "Guitars",
                column: "SoundboardId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_PickupSets_PickupSetId",
                table: "Guitars",
                column: "PickupSetId",
                principalTable: "PickupSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_TremoloTypes_TremoloTypeId",
                table: "Guitars",
                column: "TremoloTypeId",
                principalTable: "TremoloTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Brands_BrandId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Categories_CategoryId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Colors_ColorId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_GuitarShapes_ShapeId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Materials_FretboardId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Materials_NeckId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Materials_SoundboardId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_PickupSets_PickupSetId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_TremoloTypes_TremoloTypeId",
                table: "Guitars");

            migrationBuilder.AlterColumn<int>(
                name: "SoundboardId",
                table: "Guitars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NeckId",
                table: "Guitars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FretboardId",
                table: "Guitars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Brands_BrandId",
                table: "Guitars",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Categories_CategoryId",
                table: "Guitars",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Colors_ColorId",
                table: "Guitars",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_GuitarShapes_ShapeId",
                table: "Guitars",
                column: "ShapeId",
                principalTable: "GuitarShapes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Materials_FretboardId",
                table: "Guitars",
                column: "FretboardId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Materials_NeckId",
                table: "Guitars",
                column: "NeckId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Materials_SoundboardId",
                table: "Guitars",
                column: "SoundboardId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_PickupSets_PickupSetId",
                table: "Guitars",
                column: "PickupSetId",
                principalTable: "PickupSets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_TremoloTypes_TremoloTypeId",
                table: "Guitars",
                column: "TremoloTypeId",
                principalTable: "TremoloTypes",
                principalColumn: "Id");
        }
    }
}
