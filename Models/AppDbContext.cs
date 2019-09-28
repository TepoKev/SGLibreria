using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace SGLibreria.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration Configuration)
            : base(options)
        {
            this.Configuration = Configuration;
        }

        public virtual DbSet<Accion> Acciones { get; set; }
        public virtual DbSet<Bitacora> Bitacoras { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Compania> Companias { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Configuracion> Configuraciones { get; set; }
        public virtual DbSet<Detallecompra> Detallecompra { get; set; }
        public virtual DbSet<Detalleservicio> Detalleservicio { get; set; }
        public virtual DbSet<Detalleventa> Detalleventa { get; set; }
        public virtual DbSet<Documento> Documentos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Imagen> Imagenes { get; set; }
        public virtual DbSet<Kardex> Kardex { get; set; }
        public virtual DbSet<Oferta> Ofertas { get; set; }
        public virtual DbSet<Ofertaproducto> Ofertaproducto { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Precioventa> Precioventa { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Recuperacioncuenta> Recuperacioncuenta { get; set; }
        public virtual DbSet<Ruta> Rutas { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<Telefono> Telefonos { get; set; }
        public virtual DbSet<TipoServicio> TipoServicio { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
        public IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(Configuration["Conexion"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accion>(entity =>
            {
                entity.ToTable("accion");

                entity.HasIndex(e => e.IdBitacora)
                    .HasName("IdBitacora");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("varchar(70)");

                entity.Property(e => e.Hora).HasColumnType("datetime");

                entity.Property(e => e.IdBitacora).HasColumnType("int(11)");

                entity.HasOne(d => d.IdBitacoraNavigation)
                    .WithMany(p => p.Acciones)
                    .HasForeignKey(d => d.IdBitacora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accion_ibfk_1");
            });

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.ToTable("bitacora");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("IdUsuario");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CierreSesion).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario).HasColumnType("int(11)");

                entity.Property(e => e.InicioSesion).HasColumnType("datetime");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Bitacora)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bitacora_ibfk_1");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Estado).HasColumnType("tinyint(3)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(25)");
            });

            modelBuilder.Entity<Compania>(entity =>
            {
                entity.ToTable("compania");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Estado).HasColumnType("tinyint(3)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.ToTable("compra");

                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("IdEmpleado");

                entity.HasIndex(e => e.IdProveedor)
                    .HasName("IdProveedor");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdEmpleado).HasColumnType("int(11)");

                entity.Property(e => e.IdProveedor).HasColumnType("int(11)");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("compra_ibfk_1");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("compra_ibfk_2");
            });

            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.ToTable("configuracion");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.NombreInstitucion)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TiempoSesion).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Detallecompra>(entity =>
            {
                entity.ToTable("detallecompra");

                entity.HasIndex(e => e.IdCompra)
                    .HasName("IdCompra");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("IdProducto");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Cantidad).HasColumnType("int(11)");

                entity.Property(e => e.IdCompra).HasColumnType("int(11)");

                entity.Property(e => e.IdProducto).HasColumnType("int(11)");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.Detallecompra)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("detallecompra_ibfk_1");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Detallecompra)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("detallecompra_ibfk_2");
            });

            modelBuilder.Entity<Detalleservicio>(entity =>
            {
                entity.ToTable("detalleservicio");

                entity.HasIndex(e => e.IdTipoServicio)
                    .HasName("IdTipoServicio");

                entity.HasIndex(e => e.IdVenta)
                    .HasName("IdVenta");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Cantidad).HasColumnType("int(11)");

                entity.Property(e => e.IdTipoServicio).HasColumnType("int(11)");

                entity.Property(e => e.IdVenta).HasColumnType("int(11)");

                entity.HasOne(d => d.IdTipoServicioNavigation)
                    .WithMany(p => p.Detalleservicio)
                    .HasForeignKey(d => d.IdTipoServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("detalleservicio_ibfk_5");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.Detalleservicio)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("detalleservicio_ibfk_4");
            });

            modelBuilder.Entity<Detalleventa>(entity =>
            {
                entity.ToTable("detalleventa");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("IdProducto");

                entity.HasIndex(e => e.IdVenta)
                    .HasName("IdVenta");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Cantidad).HasColumnType("int(11)");

                entity.Property(e => e.IdProducto).HasColumnType("int(11)");

                entity.Property(e => e.IdVenta).HasColumnType("int(11)");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Detalleventa)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("detalleventa_ibfk_2");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.Detalleventa)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("detalleventa_ibfk_1");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasIndex(e => e.IdCompra)
                    .HasName("IdCompra");

                entity.HasIndex(e => e.IdRuta)
                    .HasName("IdRuta");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdCompra).HasColumnType("int(11)");

                entity.Property(e => e.IdRuta).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(256)");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.Documento)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Documento_ibfk_2");

                entity.HasOne(d => d.IdRutaNavigation)
                    .WithMany(p => p.Documento)
                    .HasForeignKey(d => d.IdRuta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Documento_ibfk_1");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleado");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("IdPersona")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Dui)
                    .IsRequired()
                    .HasColumnName("DUI")
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.FechaSalida).HasColumnType("date");

                entity.Property(e => e.IdUsuario).HasColumnType("int(11)");

                entity.Property(e => e.Salario).HasColumnType("decimal(10,0)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Empleado)
                    .HasForeignKey<Empleado>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empleado_ibfk_1");
            });

            modelBuilder.Entity<Imagen>(entity =>
            {
                entity.HasIndex(e => e.IdRuta)
                    .HasName("IdRuta");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdRuta).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(256)");

                entity.HasOne(d => d.IdRutaNavigation)
                    .WithMany(p => p.Imagen)
                    .HasForeignKey(d => d.IdRuta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Imagen_ibfk_1");
            });

            modelBuilder.Entity<Kardex>(entity =>
            {
                entity.ToTable("kardex");

                entity.HasIndex(e => e.IdDetalleCompra)
                    .HasName("fk_IdDetalleCompra");

                entity.HasIndex(e => e.IdDetalleVenta)
                    .HasName("fk_IdDetalleVenta");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Existencia).HasColumnType("int(11)");

                entity.Property(e => e.IdDetalleCompra)
                    .HasColumnName("idDetalleCompra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdDetalleVenta).HasColumnType("int(11)");

                entity.HasOne(d => d.IdDetalleCompraNavigation)
                    .WithMany(p => p.Kardex)
                    .HasForeignKey(d => d.IdDetalleCompra)
                    .HasConstraintName("fk_IdDetalleCompra");

                entity.HasOne(d => d.IdDetalleVentaNavigation)
                    .WithMany(p => p.Kardex)
                    .HasForeignKey(d => d.IdDetalleVenta)
                    .HasConstraintName("fk_IdDetalleVenta");
            });

            modelBuilder.Entity<Oferta>(entity =>
            {
                entity.ToTable("oferta");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Estado).HasColumnType("tinyint(3)");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            });

            modelBuilder.Entity<Ofertaproducto>(entity =>
            {
                entity.ToTable("ofertaproducto");

                entity.HasIndex(e => e.IdOferta)
                    .HasName("IdOferta");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("IdProducto");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Cantidad).HasColumnType("int(11)");

                entity.Property(e => e.IdOferta).HasColumnType("int(11)");

                entity.Property(e => e.IdProducto).HasColumnType("int(11)");

                entity.HasOne(d => d.IdOfertaNavigation)
                    .WithMany(p => p.Ofertaproducto)
                    .HasForeignKey(d => d.IdOferta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ofertaproducto_ibfk_2");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Ofertaproducto)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ofertaproducto_ibfk_1");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("persona");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.Genero).HasColumnType("int(11)");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnType("varchar(9)");
            });

            modelBuilder.Entity<Precioventa>(entity =>
            {
                entity.ToTable("precioventa");

                entity.HasIndex(e => e.IdProductoKardex)
                    .HasName("IdProducto");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Estado).HasColumnType("tinyint(1)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdProductoKardex).HasColumnType("int(11)");

                entity.HasOne(d => d.IdProductoKardexNavigation)
                    .WithMany(p => p.Precioventa)
                    .HasForeignKey(d => d.IdProductoKardex)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("precioventa_ibfk_1");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.HasIndex(e => e.IdCategoria)
                    .HasName("IdCategoria");

                entity.HasIndex(e => e.IdImagen)
                    .HasName("IdImagen");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Codigo).HasColumnType("int(25)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Estado).HasColumnType("tinyint(3)");

                entity.Property(e => e.FechaVencimiento).HasColumnType("date");

                entity.Property(e => e.IdCategoria).HasColumnType("int(11)");

                entity.Property(e => e.IdImagen).HasColumnType("int(11)");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.StockMinimo).HasColumnType("int(11)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("producto_ibfk_1");

                entity.HasOne(d => d.IdImagenNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdImagen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("producto_ibfk_2");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("proveedor");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.Enlace)
                    .IsRequired()
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.Estado).HasColumnType("tinyint(3)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(40)");
            });

            modelBuilder.Entity<Recuperacioncuenta>(entity =>
            {
                entity.ToTable("recuperacioncuenta");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("IdUsuario");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Estado).HasColumnType("tinyint(3)");

                entity.Property(e => e.FechaEnvio).HasColumnType("datetime");

                entity.Property(e => e.FechaRecuperacion).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario).HasColumnType("int(11)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Recuperacioncuenta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recuperacioncuenta_ibfk_1");
            });

            modelBuilder.Entity<Ruta>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(128)");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasIndex(e => e.IdCompania)
                    .HasName("fk_IdCompania");

                entity.HasIndex(e => e.IdImagen)
                    .HasName("IdImagen");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Estado).HasColumnType("tinyint(3)");

                entity.Property(e => e.IdCompania).HasColumnType("int(11)");

                entity.Property(e => e.IdImagen).HasColumnType("int(11)");

                entity.Property(e => e.IdTipoServicio).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.HasOne(d => d.IdCompaniaNavigation)
                    .WithMany(p => p.Servicio)
                    .HasForeignKey(d => d.IdCompania)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IdCompania");

                entity.HasOne(d => d.IdImagenNavigation)
                    .WithMany(p => p.Servicio)
                    .HasForeignKey(d => d.IdImagen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Servicio_ibfk_1");
            });

            modelBuilder.Entity<Telefono>(entity =>
            {
                entity.ToTable("Telefono");
                entity.HasIndex(e => e.IdProveedor)
                    .HasName("fk_idProveedor");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdProveedor).HasColumnType("int(11)");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Principal).HasColumnType("tinyint(3)");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Telefono)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idProveedor");
            });

            modelBuilder.Entity<TipoServicio>(entity =>
            {
                entity.HasIndex(e => e.IdServicio)
                    .HasName("IdServicio");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdServicio).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Precio).HasColumnType("decimal(10,0)");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.TipoServicio)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TipoServicio_ibfk_1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.HasIndex(e => e.IdPersona)
                    .HasName("IdPersona")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Estado).HasColumnType("tinyint(3)");

                entity.Property(e => e.IdImagen).HasColumnType("int(11)");

                entity.Property(e => e.IdPersona).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Privilegio).HasColumnType("int(11)");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuario>(d => d.IdPersona)
                    .HasConstraintName("fkIdPersonaID");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("venta");

                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("IdEmpleado");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdEmpleado).HasColumnType("int(11)");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("venta_ibfk_1");
            });
        }
    }
}
