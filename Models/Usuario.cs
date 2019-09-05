using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Bitacora = new HashSet<Bitacora>();
            Recuperacioncuenta = new HashSet<Recuperacioncuenta>();
        }

        public int Id { get; set; }
        public int IdPersona { get; set; }
        public int IdImagen { get; set; }
        public string Nombre { get; set; }
        public int Privilegio { get; set; }
        [EmailAddressAttribute]
        public string Correo { get; set; }
        public string Clave { get; set; }
        public sbyte Estado { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual ICollection<Bitacora> Bitacora { get; set; }
        public virtual ICollection<Recuperacioncuenta> Recuperacioncuenta { get; set; }
    }
}
