using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detallecompra = new HashSet<Detallecompra>();
            Kardex = new HashSet<Kardex>();
            Ofertaproducto = new HashSet<Ofertaproducto>();
            ProductoPerecedero = new HashSet<ProductoPerecedero>();
        }

        public int Id { get; set; }
        public int Codigo { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public int StockMinimo { get; set; }
        public sbyte Estado { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<Detallecompra> Detallecompra { get; set; }
        public virtual ICollection<Kardex> Kardex { get; set; }
        public virtual ICollection<Ofertaproducto> Ofertaproducto { get; set; }
        public virtual ICollection<ProductoPerecedero> ProductoPerecedero { get; set; }
    }
}
