﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoundPlay.Infrastructure.DataAccess.DbContexts;

#nullable disable

namespace SoundPlay.Infrastructure.DataAccess.Migrations.Catalog
{
    [DbContext(typeof(CatalogDbContext))]
    partial class CatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SoundPlay.Core.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("varchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Items.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Items.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Items.GuitarCategory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GuitarCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electric Guitar"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Accoustic Guitar"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Classic Guitar"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Electric Bass"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Accoustic Bass"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ukulele"
                        });
                });

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Items.GuitarShape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GuitarShapes");
                });

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Items.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Items.PickupSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PickupSets");
                });

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Items.TremoloType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TremoloTypes");
                });

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Products.Guitar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDelivery")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<int>("FretboardId")
                        .HasColumnType("int");

                    b.Property<byte>("FretsCount")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<int>("NeckId")
                        .HasColumnType("int");

                    b.Property<int?>("PickupSetId")
                        .HasColumnType("int");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("varchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal");

                    b.Property<int?>("ShapeId")
                        .HasColumnType("int");

                    b.Property<int>("SoundboardId")
                        .HasColumnType("int");

                    b.Property<byte>("StringsCount")
                        .HasColumnType("tinyint");

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

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Products.Guitar", b =>
                {
                    b.HasOne("SoundPlay.Core.Models.Entities.Items.Brand", "Brand")
                        .WithMany("Guitars")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SoundPlay.Core.Models.Entities.Items.GuitarCategory", "Category")
                        .WithMany("Guitars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SoundPlay.Core.Models.Entities.Items.Color", "Color")
                        .WithMany("Guitars")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SoundPlay.Core.Models.Entities.Items.Material", "Fretboard")
                        .WithMany("GuitarsOfFretboard")
                        .HasForeignKey("FretboardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SoundPlay.Core.Models.Entities.Items.Material", "Neck")
                        .WithMany("GuitarsOfNeck")
                        .HasForeignKey("NeckId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SoundPlay.Core.Models.Entities.Items.PickupSet", "PickupSet")
                        .WithMany("Guitars")
                        .HasForeignKey("PickupSetId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SoundPlay.Core.Models.Entities.Items.GuitarShape", "Shape")
                        .WithMany("Guitars")
                        .HasForeignKey("ShapeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SoundPlay.Core.Models.Entities.Items.Material", "Soundboard")
                        .WithMany("GuitarsOfSoundboard")
                        .HasForeignKey("SoundboardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SoundPlay.Core.Models.Entities.Items.TremoloType", "TremoloType")
                        .WithMany("Guitars")
                        .HasForeignKey("TremoloTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Items.Brand", b =>
                {
                    b.Navigation("Guitars");
                });

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Items.Color", b =>
                {
                    b.Navigation("Guitars");
                });

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Items.GuitarCategory", b =>
                {
                    b.Navigation("Guitars");
                });

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Items.GuitarShape", b =>
                {
                    b.Navigation("Guitars");
                });

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Items.Material", b =>
                {
                    b.Navigation("GuitarsOfFretboard");

                    b.Navigation("GuitarsOfNeck");

                    b.Navigation("GuitarsOfSoundboard");
                });

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Items.PickupSet", b =>
                {
                    b.Navigation("Guitars");
                });

            modelBuilder.Entity("SoundPlay.Core.Models.Entities.Items.TremoloType", b =>
                {
                    b.Navigation("Guitars");
                });
#pragma warning restore 612, 618
        }
    }
}
