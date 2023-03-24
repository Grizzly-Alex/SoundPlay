using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoundPlay.Infrastructure.DataAccess.Migrations.Catalog
{
    /// <inheritdoc />
    public partial class UpdateAllConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Category");

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
                name: "picture_url",
                table: "Guitars",
                newName: "PictureUrl");

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
                table: "Brands",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Brands",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "Guitars",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Guitars",
                type: "int",
                nullable: false,
                defaultValue: 1);

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
                name: "IX_Guitars_CategoryId",
                table: "Guitars",
                column: "CategoryId");

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
                name: "FK_Guitars_GuitarCategories_CategoryId",
                table: "Guitars",
                column: "CategoryId",
                principalTable: "GuitarCategories",
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
                name: "FK_Guitars_Colors_ColorId",
                table: "Guitars");

            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_GuitarCategories_CategoryId",
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

            migrationBuilder.DropTable(
                name: "GuitarCategories");

            migrationBuilder.DropIndex(
                name: "IX_Guitars_CategoryId",
                table: "Guitars");

            migrationBuilder.DropColumn(
                name: "CategoryId",
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
                name: "PictureUrl",
                table: "Guitars",
                newName: "picture_url");

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
                table: "Brands",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Brands",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "picture_url",
                table: "Guitars",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

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
    }
}
