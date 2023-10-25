using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mysqlWebApi.Models;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Banks> Banks { get; set; }

    public virtual DbSet<Moneymovement> Moneymovements { get; set; }

    public virtual DbSet<Typemovement> Typemovements { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=containers-us-west-37.railway.app;port=6166;database=warehouses;user=root;password=DKiXutchMgN5JID9sFnO", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_spanish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Banks>(entity =>
        {
            entity.HasKey(e => e.IId).HasName("PRIMARY");

            entity
                .ToTable("banks")
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

        modelBuilder.Entity<Moneymovement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("moneymovements")
                .HasCharSet("utf32")
                .UseCollation("utf32_spanish_ci");

            entity.HasIndex(e => e.Tipomovimiento, "TIPO");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
            entity.Property(e => e.Amount)
                .HasColumnType("float(10,3)")
                .HasColumnName("amount");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .HasColumnType("tinytext")
                .HasColumnName("description")
                .UseCollation("latin1_spanish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Reference)
                .HasMaxLength(80)
                .HasDefaultValueSql("'REFERENCIA'")
                .HasColumnName("reference")
                .UseCollation("latin1_spanish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'PENDIENTE'")
                .HasColumnType("enum('PAGADA','ENTREGADA','PENDIENTE')")
                .HasColumnName("status")
                .UseCollation("latin1_spanish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Tipomovimiento).HasColumnName("tipomovimiento");

            entity.HasOne(d => d.TipomovimientoNavigation).WithMany(p => p.Moneymovements)
                .HasForeignKey(d => d.Tipomovimiento)
                .HasConstraintName("TIPO");
        });

        modelBuilder.Entity<Typemovement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("typemovements")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("users")
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
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasDefaultValueSql("'NOMBRE'")
                .HasColumnName("name")
                .UseCollation("latin1_spanish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .HasDefaultValueSql("'PASS'")
                .HasColumnName("password")
                .UseCollation("latin1_spanish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Position)
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
