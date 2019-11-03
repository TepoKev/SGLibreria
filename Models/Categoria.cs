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
        [Required(ErrorMessage = "El {0} es obligatorio"), StringLength(25, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Nombre { get; set; }
        public sbyte Estado { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
