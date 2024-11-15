﻿// <auto-generated />
using System;
using DesignAPI_DotNet8.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241115044936_PantonyColor")]
    partial class PantonyColor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DesignAPI_DotNet8.Models.ColorGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ColorGroups");
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

            modelBuilder.Entity("DesignAPI_DotNet8.Models.PantoneColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<string>("RgbHex")
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)");

                    b.Property<string>("RgbTriple")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId")
                        .IsUnique();

                    b.ToTable("PantoneColors");
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.PantoneColorProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ColorGroupNameId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsOkForMaterial")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsOkForStyle")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PantoneColorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColorGroupNameId");

                    b.ToTable("PantoneColorProperties");
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

            modelBuilder.Entity("DesignAPI_DotNet8.Models.PantoneColor", b =>
                {
                    b.HasOne("DesignAPI_DotNet8.Models.PantoneColorProperty", "Property")
                        .WithOne("PantoneColor")
                        .HasForeignKey("DesignAPI_DotNet8.Models.PantoneColor", "PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.PantoneColorProperty", b =>
                {
                    b.HasOne("DesignAPI_DotNet8.Models.ColorGroup", "ColorGroupName")
                        .WithMany()
                        .HasForeignKey("ColorGroupNameId");

                    b.Navigation("ColorGroupName");
                });

            modelBuilder.Entity("DesignAPI_DotNet8.Models.PantoneColorProperty", b =>
                {
                    b.Navigation("PantoneColor")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
