using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Venta
    {
        public Venta()
        {
            Detalleservicio = new HashSet<Detalleservicio>();
            Detalleventa = new HashSet<Detalleventa>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        [Required(ErrorMessage="La {0} es obligatoria")]
        public DateTime Fecha { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Detalleservicio> Detalleservicio { get; set; }
        public virtual ICollection<Detalleventa> Detalleventa { get; set; }
        public decimal montoTotal(){
            decimal monto = 0;
            foreach(var item in Detalleventa){
                monto = monto + (item.Cantidad * item.IdPrecioVentaNavigation.Valor);
            }
            foreach(var item in Detalleservicio){
                monto = monto + (item.Cantidad * item.IdTipoServicioNavigation.Precio);
            }
            return monto;
        }
        public decimal montoTotalP(){
            decimal monto = 0;
            foreach(var item in Detalleventa){
                monto = monto + (item.Cantidad * item.IdPrecioVentaNavigation.Valor);
            }
            return monto;
        }
        public decimal montoTotalS(){
            decimal monto = 0;
            foreach(var item in Detalleservicio){
                monto = monto + (item.Cantidad * item.IdTipoServicioNavigation.Precio);
            }
            return monto;
        }
    }
}
