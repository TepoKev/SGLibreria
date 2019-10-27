using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Configuracion
    {
        public int Id { get; set; }
        [Display(Name="Nombre de la Institución"), StringLength(50, ErrorMessage="El {0} no puede contener mas de {1} caracteres")]
        public string NombreInstitucion { get; set; }
        [StringLength(256, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Logo { get; set; }
        [Display(Name="Tiempo de Sesión")]
        public int TiempoSesion { get; set; }
    }
}
