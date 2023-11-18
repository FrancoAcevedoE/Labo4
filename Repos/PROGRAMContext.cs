using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PROGRAM.Models;
namespace PROGRAM.Repos;

public partial class PROGRAMContext : DbContext
{
    public PROGRAMContext()
    {
    }

    public PROGRAMContext(DbContextOptions<PROGRAMContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contador> Contador { get; set; }
    public virtual DbSet<Equipo> Equipo { get; set; }
    public virtual DbSet<ManoDeObra> ManoDeObra { get; set; }
    public virtual DbSet<Material> Material { get; set; }
    public virtual DbSet<OrdenDeTrabajo> OrdenDeTrabajo { get; set; }
    public virtual DbSet<Procedimiento> Procedimiento { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=conexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    internal static Task<string?> ToListAsync()
    {
        throw new NotImplementedException();
    }

    public DbSet<PROGRAM.Models.Contador>? Contadores { get; set; }

    public DbSet<PROGRAM.Models.Equipo>? Equipos { get; set; }

    public DbSet<PROGRAM.Models.Categoria>? Categoria { get; set; }

    //public DbSet<PROGRAM.Models.ManoDeObra>? ManoDeObras { get; set; }

    //public DbSet<PROGRAM.Models.Material>? Materiales { get; set; }

    //public DbSet<PROGRAM.Models.OrdenDeTrabajo>? OrdenDeTrabajos { get; set; }
}
