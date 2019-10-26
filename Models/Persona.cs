using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Este campo solo puede constar de 50 caracteres")]
        public string Nombres { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Este campo solo puede constar de 50 caracteres")]
        public string Apellidos { get; set; }
        [Required]
        [StringLength(9, ErrorMessage = "Este campo solo puede constar de 9 caracteres")]
        [Display(Name="Teléfono")]
        public string Telefono { get; set; }
        [Required]
        public int Genero { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Este campo solo puede constar de 250 caracteres")]
        [Display(Name="Dirección")]
        public string Direccion { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
