﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiEstadios;

#nullable disable

namespace WebApiEstadios.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230306173708_teams")]
    partial class teams
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiEstadios.Entidades.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstadioId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadioId");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("WebApiEstadios.Entidades.Estadio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estadios");
                });

            modelBuilder.Entity("WebApiEstadios.Entidades.Equipo", b =>
                {
                    b.HasOne("WebApiEstadios.Entidades.Estadio", "Estadio")
                        .WithMany("Equipos")
                        .HasForeignKey("EstadioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estadio");
                });

            modelBuilder.Entity("WebApiEstadios.Entidades.Estadio", b =>
                {
                    b.Navigation("Equipos");
                });
#pragma warning restore 612, 618
        }
    }
}
