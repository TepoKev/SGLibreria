using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public int Genero { get; set; }
        public string Direccion { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
    public enum genero
    {
        [Display(Name = "Seleccione")]
        Desconocido = 0,
        [Display(Name = "Masculino")]
        Masculino = 1,
        [Display(Name = "Femenino")]
        Femenino = 2
    }
}
