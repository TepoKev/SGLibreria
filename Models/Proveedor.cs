using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Compra = new HashSet<Compra>();
            Telefono = new HashSet<Telefono>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Enlace { get; set; }
        public sbyte Estado { get; set; }

        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Telefono> Telefono { get; set; }
    }
}
