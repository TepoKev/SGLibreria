﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage="El campo {0} es requerido"), StringLength(25, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Nombre { get; set; }
        public sbyte Estado { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
