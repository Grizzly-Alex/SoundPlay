using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundPlay.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEverything : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Brands_BrandId",
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

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TremoloTypes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TremoloTypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PickupSets",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PickupSets",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Materials",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Materials",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "GuitarShapes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GuitarShapes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Guitars",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Guitars",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Guitars",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Guitars",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TremoloTypeId",
                table: "Guitars",
                newName: "tremolo_id");

            migrationBuilder.RenameColumn(
                name: "StringsCount",
                table: "Guitars",
                newName: "strings_count");

            migrationBuilder.RenameColumn(
                name: "SoundboardId",
                table: "Guitars",
                newName: "soundboard_id");

            migrationBuilder.RenameColumn(
                name: "ShapeId",
                table: "Guitars",
                newName: "shape_id");

            migrationBuilder.RenameColumn(
                name: "PickupSetId",
                table: "Guitars",
                newName: "pickup_set_id");

            migrationBuilder.RenameColumn(
                name: "NeckId",
                table: "Guitars",
                newName: "neck_id");

            migrationBuilder.RenameColumn(
                name: "FretsCount",
                table: "Guitars",
                newName: "frets_count");

            migrationBuilder.RenameColumn(
                name: "FretboardId",
                table: "Guitars",
                newName: "fretboard_id");

            migrationBuilder.RenameColumn(
                name: "DateDelivery",
                table: "Guitars",
                newName: "date_delivery");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Guitars",
                newName: "color_id");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Guitars",
                newName: "brand_id");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_TremoloTypeId",
                table: "Guitars",
                newName: "IX_Guitars_tremolo_id");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_SoundboardId",
                table: "Guitars",
                newName: "IX_Guitars_soundboard_id");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_ShapeId",
                table: "Guitars",
                newName: "IX_Guitars_shape_id");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_PickupSetId",
                table: "Guitars",
                newName: "IX_Guitars_pickup_set_id");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_NeckId",
                table: "Guitars",
                newName: "IX_Guitars_neck_id");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_FretboardId",
                table: "Guitars",
                newName: "IX_Guitars_fretboard_id");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_ColorId",
                table: "Guitars",
                newName: "IX_Guitars_color_id");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_BrandId",
                table: "Guitars",
                newName: "IX_Guitars_brand_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Colors",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Colors",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brands",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Brands",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "TremoloTypes",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "PickupSets",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Materials",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "GuitarShapes",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Guitars",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Guitars",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_delivery",
                table: "Guitars",
                type: "datetime2(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Guitars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Colors",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Categories",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Brands",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Brands_brand_id",
                table: "Guitars",
                column: "brand_id",
                principalTable: "Brands",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Colors_color_id",
                table: "Guitars",
                column: "color_id",
                principalTable: "Colors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_GuitarShapes_shape_id",
                table: "Guitars",
                column: "shape_id",
                principalTable: "GuitarShapes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Materials_fretboard_id",
                table: "Guitars",
                column: "fretboard_id",
                principalTable: "Materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Materials_neck_id",
                table: "Guitars",
                column: "neck_id",
                principalTable: "Materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Materials_soundboard_id",
                table: "Guitars",
                column: "soundboard_id",
                principalTable: "Materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_PickupSets_pickup_set_id",
                table: "Guitars",
                column: "pickup_set_id",
                principalTable: "PickupSets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_TremoloTypes_tremolo_id",
                table: "Guitars",
                column: "tremolo_id",
                principalTable: "TremoloTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Brands_brand_id",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Colors_color_id",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_GuitarShapes_shape_id",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Materials_fretboard_id",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Materials_neck_id",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Materials_soundboard_id",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_PickupSets_pickup_set_id",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_TremoloTypes_tremolo_id",
                table: "Guitars");

            migrationBuilder.DropColumn(
                name: "category",
                table: "Guitars");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TremoloTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TremoloTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "PickupSets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PickupSets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Materials",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Materials",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "GuitarShapes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "GuitarShapes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Guitars",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Guitars",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Guitars",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Guitars",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tremolo_id",
                table: "Guitars",
                newName: "TremoloTypeId");

            migrationBuilder.RenameColumn(
                name: "strings_count",
                table: "Guitars",
                newName: "StringsCount");

            migrationBuilder.RenameColumn(
                name: "soundboard_id",
                table: "Guitars",
                newName: "SoundboardId");

            migrationBuilder.RenameColumn(
                name: "shape_id",
                table: "Guitars",
                newName: "ShapeId");

            migrationBuilder.RenameColumn(
                name: "pickup_set_id",
                table: "Guitars",
                newName: "PickupSetId");

            migrationBuilder.RenameColumn(
                name: "neck_id",
                table: "Guitars",
                newName: "NeckId");

            migrationBuilder.RenameColumn(
                name: "frets_count",
                table: "Guitars",
                newName: "FretsCount");

            migrationBuilder.RenameColumn(
                name: "fretboard_id",
                table: "Guitars",
                newName: "FretboardId");

            migrationBuilder.RenameColumn(
                name: "date_delivery",
                table: "Guitars",
                newName: "DateDelivery");

            migrationBuilder.RenameColumn(
                name: "color_id",
                table: "Guitars",
                newName: "ColorId");

            migrationBuilder.RenameColumn(
                name: "brand_id",
                table: "Guitars",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_tremolo_id",
                table: "Guitars",
                newName: "IX_Guitars_TremoloTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_soundboard_id",
                table: "Guitars",
                newName: "IX_Guitars_SoundboardId");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_shape_id",
                table: "Guitars",
                newName: "IX_Guitars_ShapeId");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_pickup_set_id",
                table: "Guitars",
                newName: "IX_Guitars_PickupSetId");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_neck_id",
                table: "Guitars",
                newName: "IX_Guitars_NeckId");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_fretboard_id",
                table: "Guitars",
                newName: "IX_Guitars_FretboardId");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_color_id",
                table: "Guitars",
                newName: "IX_Guitars_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_brand_id",
                table: "Guitars",
                newName: "IX_Guitars_BrandId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Colors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Colors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Brands",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Brands",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TremoloTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PickupSets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GuitarShapes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Guitars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Guitars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDelivery",
                table: "Guitars",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(7)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Brands_BrandId",
                table: "Guitars",
                column: "BrandId",
                principalTable: "Brands",
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
    }
}
