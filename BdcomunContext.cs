using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tiendaapi;

public partial class BdcomunContext : DbContext
{
    public BdcomunContext()
    {
    }

    public BdcomunContext(DbContextOptions<BdcomunContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.,143;initial catalog=bdcomun;User=sa;Password=Basedatos.Docker1;Max Pool Size=500;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AI");

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.IdPersonal);

            entity.ToTable("PERSONAL");

            entity.Property(e => e.Departamento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.FechaBaja)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Movil)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Nif)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Oficina)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Responsabilidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Personals)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__PERSONAL__Usuari__2C82709D");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("USUARIOS");

            entity.HasIndex(e => e.Email, "IX_EMail").IsUnique();

            entity.Property(e => e.Apellido1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Apellido_1");
            entity.Property(e => e.Apellido2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Apellido_2");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.ModoAutenticacion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
