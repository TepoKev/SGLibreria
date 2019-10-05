using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        [Required]
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        [Display(Name="Teléfono")]
        public string Telefono { get; set; }
        [Display(Name="Género")]
        public int Genero { get; set; }
        [Display(Name="Dirección")]
        public string Direccion { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}