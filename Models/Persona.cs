using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Al menos ingrese un nombre"), StringLength(50, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Al menos ingrese un apellido"), StringLength(50, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Apellidos { get; set; }
        [Display(Name="Teléfono"), StringLength(9, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Telefono { get; set; }
        [Required(ErrorMessage="Seleccioné un {0}"), Display(Name="Género")]
        public int Genero { get; set; }
        [Display(Name="Dirección") , StringLength(250, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Direccion { get; set; }

        public virtual Empleado Empleado { get; set; }

        public string NombreCompleto() {
            return $"{this.Nombres} {this.Apellidos}";
        }
    }
}
