﻿// <auto-generated />
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

namespace SoundPlay.Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230119194334_UpdateProductModel")]
    partial class UpdateProductModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SoundPlay.DAL.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("SoundPlay.DAL.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SoundPlay.DAL.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("SoundPlay.DAL.Models.Guitar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDelivery")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FretboardId")
                        .HasColumnType("int");

                    b.Property<int>("FretsCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NeckId")
                        .HasColumnType("int");

                    b.Property<int?>("PickupSetId")
                        .HasColumnType("int");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ShapeId")
                        .HasColumnType("int");

                    b.Property<int?>("SoundboardId")
                        .HasColumnType("int");

                    b.Property<int>("StringsCount")
                        .HasColumnType("int");

                    b.Property<int?>("TremoloTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ColorId");

                    b.HasIndex("FretboardId");

                    b.HasIndex("NeckId");

                    b.HasIndex("PickupSetId");

                    b.HasIndex("ShapeId");

                    b.HasIndex("SoundboardId");

                    b.HasIndex("TremoloTypeId");

                    b.ToTable("Guitars");
                });

            modelBuilder.Entity("SoundPlay.DAL.Models.GuitarShape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GuitarShapes");
                });

            modelBuilder.Entity("SoundPlay.DAL.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("SoundPlay.DAL.Models.PickupSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PickupSets");
                });

            modelBuilder.Entity("SoundPlay.DAL.Models.TremoloType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TremoloTypes");
                });

            modelBuilder.Entity("SoundPlay.DAL.Models.Guitar", b =>
                {
                    b.HasOne("SoundPlay.DAL.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.HasOne("SoundPlay.DAL.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("SoundPlay.DAL.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("SoundPlay.DAL.Models.Material", "Fretboard")
                        .WithMany()
                        .HasForeignKey("FretboardId");

                    b.HasOne("SoundPlay.DAL.Models.Material", "Neck")
                        .WithMany()
                        .HasForeignKey("NeckId");

                    b.HasOne("SoundPlay.DAL.Models.PickupSet", "PickupSet")
                        .WithMany()
                        .HasForeignKey("PickupSetId");

                    b.HasOne("SoundPlay.DAL.Models.GuitarShape", "Shape")
                        .WithMany()
                        .HasForeignKey("ShapeId");

                    b.HasOne("SoundPlay.DAL.Models.Material", "Soundboard")
                        .WithMany()
                        .HasForeignKey("SoundboardId");

                    b.HasOne("SoundPlay.DAL.Models.TremoloType", "TremoloType")
                        .WithMany()
                        .HasForeignKey("TremoloTypeId");

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Color");

                    b.Navigation("Fretboard");

                    b.Navigation("Neck");

                    b.Navigation("PickupSet");

                    b.Navigation("Shape");

                    b.Navigation("Soundboard");

                    b.Navigation("TremoloType");
                });
#pragma warning restore 612, 618
        }
    }
}
