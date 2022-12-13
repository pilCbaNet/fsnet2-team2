using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CriptoWalletApi.Models
{
    public partial class BD_CRIPTOWALLETContext : DbContext
    {
        public BD_CRIPTOWALLETContext()
        {
        }

        public BD_CRIPTOWALLETContext(DbContextOptions<BD_CRIPTOWALLETContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<CuentasBancaria> CuentasBancarias { get; set; } = null!;
        public virtual DbSet<Localidade> Localidades { get; set; } = null!;
        public virtual DbSet<Provincia> Provincias { get; set; } = null!;
        public virtual DbSet<TiposMovimiento> TiposMovimientos { get; set; } = null!;
        public virtual DbSet<Transaccione> Transacciones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DU1BN98\\SQLEXPRESS; Database=BD_CRIPTO-WALLET; User=sa; Password=123456; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Clientes_");

                entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdLocalidad).HasColumnName("Id_localidad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdLocalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes__Localidades");
            });

            modelBuilder.Entity<CuentasBancaria>(entity =>
            {
                entity.HasKey(e => e.IdCuenta);

                entity.ToTable("Cuentas_Bancarias");

                entity.Property(e => e.IdCuenta).HasColumnName("Id_cuenta");

                entity.Property(e => e.Alias)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");

                entity.Property(e => e.NumeroDeCuenta).HasColumnName("Numero_de_cuenta");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.CuentasBancaria)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuentas_Bancarias_Clientes_");
            });

            modelBuilder.Entity<Localidade>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad);

                entity.Property(e => e.IdLocalidad).HasColumnName("Id_localidad");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdProvincia).HasColumnName("Id_provincia");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Localidades)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Localidades_Provincias");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.IdProvincia);

                entity.Property(e => e.IdProvincia).HasColumnName("Id_provincia");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposMovimiento>(entity =>
            {
                entity.HasKey(e => e.IdTipoMovimiento);

                entity.ToTable("Tipos_Movimientos");

                entity.Property(e => e.IdTipoMovimiento).HasColumnName("Id_tipo_movimiento");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTipoMovimiento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_tipo_movimiento");
            });

            modelBuilder.Entity<Transaccione>(entity =>
            {
                entity.HasKey(e => e.IdTransaccion);

                entity.Property(e => e.IdTransaccion).HasColumnName("Id_transaccion");

                entity.Property(e => e.CuentaDestino)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Cuenta_destino");

                entity.Property(e => e.CuentaOrigen)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Cuenta_origen");

                entity.Property(e => e.FechaHoraTransaccion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_hora_transaccion");

                entity.Property(e => e.IdCuenta).HasColumnName("Id_cuenta");

                entity.Property(e => e.IdTipoMovimientos).HasColumnName("Id_tipo_movimientos");

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transacciones_Cuentas_Bancarias");

                entity.HasOne(d => d.IdTipoMovimientosNavigation)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => d.IdTipoMovimientos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transacciones_Tipos_Movimientos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
