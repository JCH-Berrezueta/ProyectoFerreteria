using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using CapaEntidades.Gestion;





namespace PresentacionWeb.Datos;

public partial class FerreteriaPaBacpacContext : DbContext
{
    public FerreteriaPaBacpacContext()
    {
    }

    public FerreteriaPaBacpacContext(DbContextOptions<FerreteriaPaBacpacContext> options)
    : base(options)
    {
    }

    public virtual DbSet<CapaEntidades.Gestion.Categoria> CategoriaProductos { get; set; }

    public virtual DbSet<CapaEntidades.Gestion.Cliente> Clientes { get; set; }
    public virtual DbSet<CapaEntidades.Gestion.Cuenta> Cuenta { get; set; }

    public virtual DbSet<CapaEntidades.Gestion.DetalleFactura> DetalleFacturas { get; set; }
    public virtual DbSet<CapaEntidades.Gestion.Empresa> Empresas { get; set; }

    public virtual DbSet<CapaEntidades.Gestion.EntradaProducto> EntradaProductos { get; set; }
    public virtual DbSet<CapaEntidades.Gestion.Factura> Facturas { get; set; }

    public virtual DbSet<CapaEntidades.Gestion.Producto> Productos { get; set; }

    public virtual DbSet<CapaEntidades.Gestion.Proveedor> Proveedors { get; set; }
    public virtual DbSet<CapaEntidades.Gestion.Rol> Rols { get; set; }

    public virtual DbSet<CapaEntidades.Gestion.SalidaProducto> SalidaProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CapaEntidades.Gestion.Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK_Categoria");

            entity.ToTable("CategoriaProducto");

            entity.Property(e => e.IdCategoriaProducto).HasColumnName("Id_CategoriaProducto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CapaEntidades.Gestion.Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK_Registro_Cliente");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdCuenta).HasColumnName("Id_Cuenta");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCuentaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdCuenta)
                .HasConstraintName("FK_Registro_Cliente_Cuenta");
        });

        modelBuilder.Entity<CapaEntidades.Gestion.Cuenta>(entity =>
        {
            entity.HasKey(e => e.IdCuenta).HasName("PK_Cuenta_Cliente_1");

            entity.Property(e => e.IdCuenta).HasColumnName("Id_Cuenta");
            entity.Property(e => e.IdRol).HasColumnName("Id_rol");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_Cliente_Rol");
        });

        modelBuilder.Entity<CapaEntidades.Gestion.DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.IdDetalleFactura);

            entity.ToTable("DetalleFactura");

            entity.Property(e => e.IdDetalleFactura).HasColumnName("Id_DetalleFactura");
            entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");
            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFactura_Factura1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFactura_Productos_Cliente");
        });

        modelBuilder.Entity<CapaEntidades.Gestion.Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa);

            entity.ToTable("Empresa");

            entity.Property(e => e.IdEmpresa).HasColumnName("Id_Empresa");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Observacion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Representante)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ruc)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CapaEntidades.Gestion.EntradaProducto>(entity =>
        {
            entity.HasKey(e => e.IdEntradaProducto);

            entity.ToTable("EntradaProducto");

            entity.Property(e => e.IdEntradaProducto).HasColumnName("Id_EntradaProducto");
            entity.Property(e => e.CostoUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.IdProveedor).HasColumnName("Id_Proveedor");
            entity.Property(e => e.Observacion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.EntradaProductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EntradaProducto_Producto");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.EntradaProductos)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EntradaProducto_Proveedor");
        });

        modelBuilder.Entity<CapaEntidades.Gestion.Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura);

            entity.ToTable("Factura");

            entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Registro_Cliente");
        });

        modelBuilder.Entity<CapaEntidades.Gestion.Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK_Productos");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdCategoriaProducto).HasColumnName("Id_CategoriaProducto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdCategoriaProductoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoriaProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_CategoriaProducto1");
        });

        modelBuilder.Entity<CapaEntidades.Gestion.Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor);

            entity.ToTable("Proveedor");

            entity.Property(e => e.IdProveedor).HasColumnName("Id_Proveedor");
            entity.Property(e => e.IdEmpresa).HasColumnName("Id_Empresa");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Observacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proveedor_Empresa");
        });

        modelBuilder.Entity<CapaEntidades.Gestion.Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("Id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CapaEntidades.Gestion.SalidaProducto>(entity =>
        {
            entity.HasKey(e => e.IdSalidaProducto);

            entity.ToTable("SalidaProducto");

            entity.Property(e => e.IdSalidaProducto).HasColumnName("Id_SalidaProducto");
            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.Motivo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observacion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.SalidaProductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalidaProducto_Producto");
        });
        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
