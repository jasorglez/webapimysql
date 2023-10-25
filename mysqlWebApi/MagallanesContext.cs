using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using mysqlWebApi.Models;

namespace mysqlWebApi;

public partial class MagallanesContext : DbContext
{

    public virtual DbSet<Bancos> Bancos { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }


    public MagallanesContext(DbContextOptions<MagallanesContext> options)  : base(options) {  }
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_spanish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Bancos>(entity =>
        {
            entity.HasKey(e => e.IId).HasName("PRIMARY");

            entity
                .ToTable("bancos")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IId, "idbanco").IsUnique();

            entity.Property(e => e.IId).HasColumnName("iId");
            entity.Property(e => e.Contacto)
                .HasMaxLength(200)
                .HasColumnName("contacto")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.IActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("iActivo");
            entity.Property(e => e.ICodigoSat)
                .HasDefaultValueSql("'0'")
                .HasColumnName("iCodigoSAT");
            entity.Property(e => e.Imagen).HasColumnType("mediumblob");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Numsucursal).HasColumnName("numsucursal");
            entity.Property(e => e.Sucursal)
                .HasMaxLength(45)
                .HasDefaultValueSql("'SIN SUCURSAL'")
                .HasColumnName("sucursal")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .HasColumnName("telefono")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("usuarios")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Mail)
                .HasMaxLength(40)
                .HasDefaultValueSql("'NOMBRE@DOMINIO'")
                .HasColumnName("mail")
                .UseCollation("latin1_spanish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .HasDefaultValueSql("'NOMBRE'")
                .HasColumnName("nombre")
                .UseCollation("latin1_spanish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .HasDefaultValueSql("'PASS'")
                .HasColumnName("password")
                .UseCollation("latin1_spanish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Puesto)
                .HasMaxLength(50)
                .HasDefaultValueSql("'PUESTO'")
                .HasColumnName("puesto")
                .UseCollation("latin1_spanish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Usuario)
                .HasMaxLength(15)
                .HasDefaultValueSql("'USUARIO'")
                .HasColumnName("usuario")
                .UseCollation("latin1_spanish_ci")
                .HasCharSet("latin1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
