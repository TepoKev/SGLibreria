using System;
namespace SGLibreria.Informes
{
    public class ConsultaProducto {
        public int Id {get;set;}
        public string Producto {get;set;}
        public string Marca {get;set;}
        public string Imagen { get;set; }
        public string Categoria {get;set; }
        public int Existencia {get;set; }
        public decimal PrecioVenta {get;set;}
        public decimal? PrecioOferta {get;set;}

    }
}