using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SGLibreria.Models
{
    public partial class Compania
    {
        public Compania()
        {
            Tiposervicio = new HashSet<Tiposervicio>();
        }
        public int Id { get; set; }
        [StringLength(20, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Nombre { get; set; }
        public sbyte Estado { get; set; }
        public virtual ICollection<Tiposervicio> Tiposervicio { get; set; }
    }
}