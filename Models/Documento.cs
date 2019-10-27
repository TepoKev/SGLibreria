using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Documento
    {
        public int Id { get; set; }
        public int IdRuta { get; set; }
        public int IdCompra { get; set; }
        [StringLength(256, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Nombre { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
        public virtual Ruta IdRutaNavigation { get; set; }
    }
}
