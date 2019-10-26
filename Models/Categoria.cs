using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        [StringLength(25)]
        public string Nombre { get; set; }
        public sbyte Estado { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
