using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Ofertaproducto = new HashSet<Ofertaproducto>();
            Preciocompra = new HashSet<Preciocompra>();
            Precioventa = new HashSet<Precioventa>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public int IdCategoria { get; set; }
        public int? IdImagen { get; set; }
        public string Nombre { get; set; }
        public int IdMarca { get; set; }
        public string Descripcion { get; set; }
        public int StockMinimo { get; set; }
        public sbyte Estado { get; set; }
        public DateTime? FechaVencimiento { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Imagen IdImagenNavigation { get; set; }
        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<Ofertaproducto> Ofertaproducto { get; set; }
        public virtual ICollection<Preciocompra> Preciocompra { get; set; }
        public virtual ICollection<Precioventa> Precioventa { get; set; }
    }
}
