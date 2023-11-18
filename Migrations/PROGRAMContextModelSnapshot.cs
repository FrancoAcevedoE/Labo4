﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROGRAM.Repos;

#nullable disable

namespace PROGRAM.Migrations
{
    [DbContext(typeof(PROGRAMContext))]
    partial class PROGRAMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PROGRAM.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoría")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Valor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("PROGRAM.Models.Contador", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("EquipoRefId")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EquipoRefId");

                    b.ToTable("Contador");
                });

            modelBuilder.Entity("PROGRAM.Models.Equipo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("ContadorRefId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProcedimientoRefId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ContadorRefId");

                    b.HasIndex("ProcedimientoRefId");

                    b.ToTable("Equipo");
                });

            modelBuilder.Entity("PROGRAM.Models.ManoDeObra", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CategoriaRefId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CategoriaRefId");

                    b.ToTable("ManoDeObra");
                });

            modelBuilder.Entity("PROGRAM.Models.Material", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CodMateriales")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int?>("Valor")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Materiales");
                });

            modelBuilder.Entity("PROGRAM.Models.OrdenDeTrabajo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("EquipoRefId")
                        .HasColumnType("int");

                    b.Property<int?>("ManoDeObraRefId")
                        .HasColumnType("int");

                    b.Property<int?>("MaterialesRefId")
                        .HasColumnType("int");

                    b.Property<int?>("ProcedimientoRefId")
                        .HasColumnType("int");

                    b.Property<string>("TipoOT")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EquipoRefId");

                    b.HasIndex("ManoDeObraRefId");

                    b.HasIndex("MaterialesRefId");

                    b.HasIndex("ProcedimientoRefId");

                    b.ToTable("OrdenDeTrabajo");
                });

            modelBuilder.Entity("PROGRAM.Models.Procedimiento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Procedimiento");
                });

            modelBuilder.Entity("PROGRAM.Models.Contador", b =>
                {
                    b.HasOne("PROGRAM.Models.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoRefId");

                    b.Navigation("Equipo");
                });

            modelBuilder.Entity("PROGRAM.Models.Equipo", b =>
                {
                    b.HasOne("PROGRAM.Models.Contador", "Contador")
                        .WithMany()
                        .HasForeignKey("ContadorRefId");

                    b.HasOne("PROGRAM.Models.Procedimiento", "Procedimiento")
                        .WithMany()
                        .HasForeignKey("ProcedimientoRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contador");

                    b.Navigation("Procedimiento");
                });

            modelBuilder.Entity("PROGRAM.Models.ManoDeObra", b =>
                {
                    b.HasOne("PROGRAM.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaRefId");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("PROGRAM.Models.OrdenDeTrabajo", b =>
                {
                    b.HasOne("PROGRAM.Models.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoRefId");

                    b.HasOne("PROGRAM.Models.ManoDeObra", "ManoDeObra")
                        .WithMany()
                        .HasForeignKey("ManoDeObraRefId");

                    b.HasOne("PROGRAM.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialesRefId");

                    b.HasOne("PROGRAM.Models.Procedimiento", "Procedimiento")
                        .WithMany()
                        .HasForeignKey("ProcedimientoRefId");

                    b.Navigation("Equipo");

                    b.Navigation("ManoDeObra");

                    b.Navigation("Material");

                    b.Navigation("Procedimiento");
                });
#pragma warning restore 612, 618
        }
    }
}
