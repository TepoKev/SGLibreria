using System;
using System.ComponentModel.DataAnnotations;
namespace SGLibreria.Models
{
    public partial class Empleado
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaIngreso { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Este campo solo puede constar de 10 caracteres")]
        [Display(Name="DUI")]
        public string Dui { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaSalida { get; set; }
        public decimal Salario { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}