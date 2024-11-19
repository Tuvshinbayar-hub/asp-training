﻿// <auto-generated />
using System;
using DesignAPI_DotNet8.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ColorRecipePaintType", b =>
                {
                    b.Property<int>("ColorRecipeId")
                        .HasColumnType("int");

                    b.Property<int>("PaintTypesId")
                        .HasColumnType("int");

                    b.HasKey("ColorRecipeId", "PaintTypesId");

                    b.HasIndex("PaintTypesId");

                    b.ToTable("ColorRecipePaintType");
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.Colors.ColorGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ColorGroups", (string)null);
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.Colors.ColorRecipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("CamelWool")
                        .HasColumnType("float");

                    b.Property<string>("ColorComposition")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Cotton")
                        .HasColumnType("float");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModefiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("NaturalColorI")
                        .HasColumnType("float");

                    b.Property<float>("NaturalColorII")
                        .HasColumnType("float");

                    b.Property<float>("NaturalColorIII")
                        .HasColumnType("float");

                    b.Property<float>("NaturalColorIV")
                        .HasColumnType("float");

                    b.Property<string>("PaintTypeIds")
                        .HasColumnType("longtext");

                    b.Property<float>("SheepWool")
                        .HasColumnType("float");

                    b.Property<float>("Silk")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("ColorRecipe", (string)null);
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.Colors.ColorShade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ColorShades", (string)null);
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.Colors.ColorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ColorTypes", (string)null);
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.Colors.DyingMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DyingMethods", (string)null);
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.Colors.GobiColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ColorRecipeId")
                        .HasColumnType("int");

                    b.Property<int?>("ColorShadeId")
                        .HasColumnType("int");

                    b.Property<int?>("ColorTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<int>("DandruffClassification")
                        .HasColumnType("int");

                    b.Property<int?>("DyingMethodId")
                        .HasColumnType("int");

                    b.Property<string>("FourDigitColorCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)");

                    b.Property<string>("GobiColorCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("MainFlag")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModefiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<int?>("PantoneColorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColorRecipeId");

                    b.HasIndex("ColorShadeId");

                    b.HasIndex("ColorTypeId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DyingMethodId");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("PantoneColorId");

                    b.ToTable("GobiColors", (string)null);
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.Colors.PantoneColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ColorGroupId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsOkForMaterial")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsOkForStyle")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModefiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RgbHex")
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)");

                    b.Property<string>("RgbTriple")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ColorGroupId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("PantoneColors", (string)null);
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.Design", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Designers");
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.GobiColor.PaintType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("PaintWeight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("PaintTypes", (string)null);
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Season")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ColorRecipePaintType", b =>
                {
                    b.HasOne("DesignAPI_DotNet8.Models.Colors.ColorRecipe", null)
                        .WithMany()
                        .HasForeignKey("ColorRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesignAPI_DotNet8.Models.GobiColor.PaintType", null)
                        .WithMany()
                        .HasForeignKey("PaintTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.Colors.ColorRecipe", b =>
                {
                    b.HasOne("DesignAPI_DotNet8.Models.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("DesignAPI_DotNet8.Models.Users.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.Colors.GobiColor", b =>
                {
                    b.HasOne("DesignAPI_DotNet8.Models.Colors.ColorRecipe", "ColorRecipe")
                        .WithMany()
                        .HasForeignKey("ColorRecipeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DesignAPI_DotNet8.Models.Colors.ColorShade", "ColorShade")
                        .WithMany()
                        .HasForeignKey("ColorShadeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DesignAPI_DotNet8.Models.Colors.ColorType", "ColorType")
                        .WithMany()
                        .HasForeignKey("ColorTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DesignAPI_DotNet8.Models.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("DesignAPI_DotNet8.Models.Colors.DyingMethod", "DyingMethod")
                        .WithMany()
                        .HasForeignKey("DyingMethodId");

                    b.HasOne("DesignAPI_DotNet8.Models.Users.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.HasOne("DesignAPI_DotNet8.Models.Colors.PantoneColor", "PantoneColor")
                        .WithMany()
                        .HasForeignKey("PantoneColorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ColorRecipe");

                    b.Navigation("ColorShade");

                    b.Navigation("ColorType");

                    b.Navigation("CreatedBy");

                    b.Navigation("DyingMethod");

                    b.Navigation("ModifiedBy");

                    b.Navigation("PantoneColor");
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.Colors.PantoneColor", b =>
                {
                    b.HasOne("DesignAPI_DotNet8.Models.Colors.ColorGroup", "ColorGroup")
                        .WithMany()
                        .HasForeignKey("ColorGroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DesignAPI_DotNet8.Models.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("DesignAPI_DotNet8.Models.Users.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.Navigation("ColorGroup");

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.GobiColor.PaintType", b =>
                {
                    b.HasOne("DesignAPI_DotNet8.Models.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
