﻿// <auto-generated />
using System;
using Fluent_API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fluent_API.Migrations
{
    [DbContext(typeof(TareasContext))]
    partial class TareasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fluent_API.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("907f7cf7-7d85-4c28-9ad0-7c6eb70235eb"),
                            Nombre = "Actividades Pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("907f7cf7-7d85-4c28-9ad0-7c6eb70236eb"),
                            Nombre = "Actividades Personales",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("Fluent_API.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("907f7cf7-7d85-4d28-9ad0-7c6eb71235eb"),
                            CategoriaId = new Guid("907f7cf7-7d85-4c28-9ad0-7c6eb70235eb"),
                            Descripcion = "Esta es una descripcion",
                            FechaCreacion = new DateTime(2024, 1, 11, 12, 11, 18, 336, DateTimeKind.Local).AddTicks(442),
                            PrioridadTarea = 2,
                            Titulo = "Tareas Pendientes"
                        },
                        new
                        {
                            TareaId = new Guid("907f7cf7-8d85-4c29-9ad0-7c6eb70236eb"),
                            CategoriaId = new Guid("907f7cf7-7d85-4c28-9ad0-7c6eb70236eb"),
                            Descripcion = "Esta es una descripcion",
                            FechaCreacion = new DateTime(2024, 1, 11, 12, 11, 18, 336, DateTimeKind.Local).AddTicks(486),
                            PrioridadTarea = 0,
                            Titulo = "Tareas Personales"
                        });
                });

            modelBuilder.Entity("Fluent_API.Models.Tarea", b =>
                {
                    b.HasOne("Fluent_API.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Fluent_API.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
