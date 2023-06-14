﻿// <auto-generated />
using System;
using Interface.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Interface.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Domain.Figure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("clientId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("radius")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("clientId");

                    b.ToTable("Figures");
                });

            modelBuilder.Entity("Domain.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("clientId")
                        .HasColumnType("int");

                    b.Property<int>("color")
                        .HasColumnType("int")
                        .HasColumnName("Color");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("clientId");

                    b.ToTable("Materials");

                    b.HasDiscriminator<string>("Type").HasValue("Material");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("clientId")
                        .HasColumnType("int");

                    b.Property<int>("figureId")
                        .HasColumnType("int");

                    b.Property<int>("materialId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("clientId");

                    b.HasIndex("figureId");

                    b.HasIndex("materialId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("Domain.PositionedModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("modelId")
                        .HasColumnType("int");

                    b.Property<string>("position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sceneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("modelId");

                    b.HasIndex("sceneId");

                    b.ToTable("PositionedModels");
                });

            modelBuilder.Entity("Domain.Scene", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("aperture")
                        .HasColumnType("float");

                    b.Property<int>("clientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<int>("fieldOfView")
                        .HasColumnType("int");

                    b.Property<DateTime>("lastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("lastRendered")
                        .HasColumnType("datetime2");

                    b.Property<string>("lookAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lookFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("clientId");

                    b.ToTable("Scenes");
                });

            modelBuilder.Entity("Domain.LambertianoMaterial", b =>
                {
                    b.HasBaseType("Domain.Material");

                    b.HasDiscriminator().HasValue("Lambertian");
                });

            modelBuilder.Entity("Domain.MetalicMaterial", b =>
                {
                    b.HasBaseType("Domain.Material");

                    b.Property<double>("blurred")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Metalic");
                });

            modelBuilder.Entity("Domain.Figure", b =>
                {
                    b.HasOne("Domain.Client", "client")
                        .WithMany("figures")
                        .HasForeignKey("clientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");
                });

            modelBuilder.Entity("Domain.Material", b =>
                {
                    b.HasOne("Domain.Client", "client")
                        .WithMany("materials")
                        .HasForeignKey("clientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");
                });

            modelBuilder.Entity("Domain.Model", b =>
                {
                    b.HasOne("Domain.Client", "client")
                        .WithMany("models")
                        .HasForeignKey("clientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Figure", "figure")
                        .WithMany()
                        .HasForeignKey("figureId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Material", "material")
                        .WithMany()
                        .HasForeignKey("materialId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("client");

                    b.Navigation("figure");

                    b.Navigation("material");
                });

            modelBuilder.Entity("Domain.PositionedModel", b =>
                {
                    b.HasOne("Domain.Model", "model")
                        .WithMany()
                        .HasForeignKey("modelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Scene", "scene")
                        .WithMany("positionedModels")
                        .HasForeignKey("sceneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("model");

                    b.Navigation("scene");
                });

            modelBuilder.Entity("Domain.Scene", b =>
                {
                    b.HasOne("Domain.Client", "client")
                        .WithMany("scenes")
                        .HasForeignKey("clientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");
                });

            modelBuilder.Entity("Domain.Client", b =>
                {
                    b.Navigation("figures");

                    b.Navigation("materials");

                    b.Navigation("models");

                    b.Navigation("scenes");
                });

            modelBuilder.Entity("Domain.Scene", b =>
                {
                    b.Navigation("positionedModels");
                });
#pragma warning restore 612, 618
        }
    }
}
