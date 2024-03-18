﻿// <auto-generated />
using CodeFirstPart2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeFirstPart2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodeFirstPart2.Model.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Chassis")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Audi",
                            Chassis = 123,
                            Color = "Black",
                            Model = "A6",
                            Number = 5,
                            Year = 2020
                        },
                        new
                        {
                            Id = 2,
                            Brand = "BMW",
                            Chassis = 321,
                            Color = "Blue",
                            Model = "520",
                            Number = 6,
                            Year = 2020
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Mercedes",
                            Chassis = 231,
                            Color = "White",
                            Model = "E220",
                            Number = 7,
                            Year = 2020
                        });
                });

            modelBuilder.Entity("CodeFirstPart2.Model.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("EngineTypeId")
                        .HasColumnType("int");

                    b.Property<string>("MyProperty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.HasIndex("EngineTypeId");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("CodeFirstPart2.Model.EngineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EngineTypes");
                });

            modelBuilder.Entity("CodeFirstPart2.Model.Engine", b =>
                {
                    b.HasOne("CodeFirstPart2.Model.Car", "Car")
                        .WithOne("Engine")
                        .HasForeignKey("CodeFirstPart2.Model.Engine", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeFirstPart2.Model.EngineType", "EngineType")
                        .WithMany("Engines")
                        .HasForeignKey("EngineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("EngineType");
                });

            modelBuilder.Entity("CodeFirstPart2.Model.Car", b =>
                {
                    b.Navigation("Engine");
                });

            modelBuilder.Entity("CodeFirstPart2.Model.EngineType", b =>
                {
                    b.Navigation("Engines");
                });
#pragma warning restore 612, 618
        }
    }
}
