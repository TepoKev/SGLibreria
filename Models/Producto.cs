using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detallecompra = new HashSet<Detallecompra>();
            Detalleventa = new HashSet<Detalleventa>();
            Ofertaproducto = new HashSet<Ofertaproducto>();
        }

        public int Id { get; set; }
        public int Codigo { get; set; }
        public int IdCategoria { get; set; }
        public int IdImagen { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public int StockMinimo { get; set; }
        public sbyte Estado { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Imagen IdImagenNavigation { get; set; }
        public virtual ICollection<Detallecompra> Detallecompra { get; set; }
        public virtual ICollection<Detalleventa> Detalleventa { get; set; }
        public virtual ICollection<Ofertaproducto> Ofertaproducto { get; set; }
    }
}
