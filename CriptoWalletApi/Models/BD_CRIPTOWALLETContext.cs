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
        public virtual DbSet<Domicilio> Domicilios { get; set; } = null!;
        public virtual DbSet<Localidade> Localidades { get; set; } = null!;
        public virtual DbSet<Moneda> Monedas { get; set; } = null!;
        public virtual DbSet<Provincia> Provincias { get; set; } = null!;
        public virtual DbSet<TiposCuentum> TiposCuenta { get; set; } = null!;
        public virtual DbSet<TiposMovimiento> TiposMovimientos { get; set; } = null!;
        public virtual DbSet<Transaccione> Transacciones { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=BD_CRIPTO-WALLET; User=sa; Password=123456; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Clientes_");

                entity.Property(e => e.IdCliente)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_cliente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdDomicilio).HasColumnName("Id_domicilio");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDomicilioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdDomicilio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes__Domicilios");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes__Usuarios");
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

                entity.Property(e => e.IdTipoCuenta).HasColumnName("Id_tipo_cuenta");

                entity.Property(e => e.IdTransaccion).HasColumnName("Id_transaccion");

                entity.Property(e => e.NumeroDeCuenta).HasColumnName("Numero_de_cuenta");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.CuentasBancaria)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuentas_Bancarias_Clientes_");

                entity.HasOne(d => d.IdTipoCuentaNavigation)
                    .WithMany(p => p.CuentasBancaria)
                    .HasForeignKey(d => d.IdTipoCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuentas_Bancarias_Tipos_Cuenta");

                entity.HasOne(d => d.IdTransaccionNavigation)
                    .WithMany(p => p.CuentasBancaria)
                    .HasForeignKey(d => d.IdTransaccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuentas_Bancarias_Transacciones");
            });

            modelBuilder.Entity<Domicilio>(entity =>
            {
                entity.HasKey(e => e.IdDomicilio);

                entity.Property(e => e.IdDomicilio).HasColumnName("Id_domicilio");

                entity.Property(e => e.Barrio)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdLocalidad).HasColumnName("Id_localidad");

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Domicilios)
                    .HasForeignKey(d => d.IdLocalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Domicilios_Localidades");
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

            modelBuilder.Entity<Moneda>(entity =>
            {
                entity.HasKey(e => e.IdMoneda);

                entity.Property(e => e.IdMoneda).HasColumnName("Id_moneda");

                entity.Property(e => e.NombreMoneda)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_moneda");

                entity.Property(e => e.Simbolo)
                    .HasMaxLength(3)
                    .IsUnicode(false);
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

            modelBuilder.Entity<TiposCuentum>(entity =>
            {
                entity.HasKey(e => e.IdTipoCuenta);

                entity.ToTable("Tipos_Cuenta");

                entity.Property(e => e.IdTipoCuenta).HasColumnName("Id_tipo_cuenta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdMoneda).HasColumnName("Id_moneda");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMonedaNavigation)
                    .WithMany(p => p.TiposCuenta)
                    .HasForeignKey(d => d.IdMoneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tipos_Cuenta_Monedas");
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

                entity.Property(e => e.CuentaDestino).HasColumnName("Cuenta_destino");

                entity.Property(e => e.CuentaOrigen).HasColumnName("Cuenta_origen");

                entity.Property(e => e.FechaHoraTransaccion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_hora_transaccion");

                entity.Property(e => e.IdTipoMovimiento).HasColumnName("Id_tipo_movimiento");

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdTipoMovimientoNavigation)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => d.IdTipoMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transacciones_Tipos_Movimientos");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
