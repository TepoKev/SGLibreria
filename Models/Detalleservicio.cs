namespace SGLibreria.Models
{
    public partial class Detalleservicio
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int Cantidad { get; set; }
        public int IdTipoServicio { get; set; }

        public virtual Tiposervicio IdTipoServicioNavigation { get; set; }
        public virtual Venta IdVentaNavigation { get; set; }
    }
}
