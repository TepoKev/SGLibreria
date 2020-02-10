using System;

using System.Linq;

namespace SGLibreria.Informes
{
    public class ConsultaKardex
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public int Existencia { get; set; }
        public int StockMinimo { get; set; }

        public static string queryOne()
        {
            return @"
            (
select kc.Id as Id,  prod.Id as IdProducto,
prod.Nombre as Producto, kc.Existencia, prod.`StockMinimo`
from producto prod
inner join detallecompra dc
on dc.IdProducto = prod.id
INNER JOIN kardex kc
on kc.idDetalleCompra = dc.Id
WHERE prod.Id = {0}
ORDER BY kc.Id desc
limit 1
)
union all (
select kv.Id as Id,  prod.Id as IdProducto,
prod.Nombre as Producto, kv.Existencia, prod.`StockMinimo`
from producto prod
inner join precioventa pv
on pv.IdProducto = prod.Id
INNER JOIN detalleventa dv
on dv.IdPrecioVenta = pv.Id
INNER JOIN kardex kv
on kv.IdDetalleVenta = dv.Id
WHERE prod.Id = {1}
ORDER BY kv.Id desc
limit 1
)
order by Id;
            ";
        }
        public static string queryList()
        {
            return "";
        }
        public static IQueryable<ConsultaKardex> q()
        {
            return null;
        }
    }
}

