using Microsoft.EntityFrameworkCore;
using StoreSystem.Models;

namespace StoreSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Proveedor> Proveedores => Set<Proveedor>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Compra> Compras => Set<Compra>();
        public DbSet<DetalleCompra> DetalleCompras => Set<DetalleCompra>();
        public DbSet<Venta> Ventas => Set<Venta>();
        public DbSet<DetalleVenta> DetallesVenta => Set<DetalleVenta>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ===== Categoria =====

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categoria");
                entity.HasKey(c => c.IdCategoria);
                entity.Property(c => c.Nombre).IsRequired().HasMaxLength(100);
                entity.HasIndex(c => c.Nombre).IsUnique();

            });

            // ===== Producto =====

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos");
                entity.HasKey(p => p.IdProducto);
                entity.Property(p => p.CodigoBarras).IsRequired().HasMaxLength(80);
                entity.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                entity.Property(p => p.PrecioCosto).HasColumnType("decimal(18,2)");
                entity.Property(p => p.PrecioVenta).HasColumnType("decimal(18,2)");
                entity.HasIndex(p => p.CodigoBarras).IsUnique();

                entity.HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            // ===== Proveedor =====

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedores");
                entity.HasKey(p => p.IdProveedor);
                entity.Property(P => P.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Telefono).HasMaxLength(30);
            });

            // ==== Cliente ===

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes");
                entity.HasKey(c => c.IdCliente);
                entity.Property(c => c.Nombre).IsRequired().HasMaxLength(80);
                entity.Property(c => c.Apellido).HasMaxLength(60);
                entity.Property(c => c.Telefono).HasMaxLength(60);
                entity.Property(c => c.Email).HasMaxLength(250);
                entity.Property(c => c.Direccion).HasMaxLength(150);
                entity.Property(c => c.Dni).HasMaxLength(20);
                entity.Property(c => c.Saldo).HasColumnType("decimal(18,2)");
            });

            // === Compra ===

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.ToTable("Compras");
                entity.HasKey(c => c.IdCompra);
                entity.Property(c => c.Total).HasColumnType("decimal(18,2)");
                entity.Property(c => c.FormaDePago).IsRequired();
                entity.HasOne(c => c.Proveedor)
                .WithMany(p => p.Compras)
                .HasForeignKey(c => c.ProveedorId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            // === Detalle Compra ===
            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.ToTable("DetallesCompra");
                entity.HasKey(c => c.IdDetalleCompra);
                entity.Property(d => d.PrecioUnitario).HasColumnType("decimal(18,2)");
                entity.Ignore(d => d.SubTotal);

                entity.HasOne(d => d.Compra)
                .WithMany(c => c.Detalles)
                .HasForeignKey(d => d.IdCompra)
                .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(d => d.Producto)
                .WithMany(p => p.detalleCompras)
                .HasForeignKey(d => d.ProductoID)
                .OnDelete(DeleteBehavior.Restrict);


            });

            // === Venta ===

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("Ventas");
                entity.HasKey(v => v.IdVenta);
                entity.Property(v => v.Total).HasColumnType("decimal(18,2)");
                entity.Property(v => v.SaldoPendiente).HasColumnType("decimal(18,2)");
                entity.Property(v => v.FormaDePago).IsRequired();

                entity.HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v =>  v.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // === Detalle Venta ===
            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.ToTable("DetallesVenta");
                entity.HasKey(d=> d.IdDetalleVenta);
                entity.Property(d => d.PrecioUnitario).HasColumnType("decimal(18,2)");
                entity.Ignore(d => d.SubTotal);

                entity.HasOne(d => d.Venta)
                .WithMany(v => v.Detalles)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(d => d.Producto)
                .WithMany(p => p.detalleVentas)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);

            });


        }
    }



}
