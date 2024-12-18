﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241102195944_CrearTablas")]
    partial class CrearTablas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Model.Zocalo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadArchivos")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PromedioDuracion")
                        .HasColumnType("REAL");

                    b.Property<double>("PromedioTamañoArchivos")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Zocalos");
                });
#pragma warning restore 612, 618
        }
    }
}
