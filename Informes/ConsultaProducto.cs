using System;
using System.Linq;

namespace SGLibreria.Informes
{
    public class ConsultaProducto {
        public int Id {get;set;}
        public int IdProducto {get;set;}
        public string Producto {get;set;}
        public string Marca {get;set;}
        public string Imagen { get;set; }
        public string Categoria {get;set; }
        public int Existencia {get;set; }
        public decimal? PrecioVenta {get;set;}
        public double? Descuento {get;set;}
        public int StockMinimo {get;set;}
        public static string sqlAllCount(string whereIn="", string limit = "") {
            string sql = ConsultaProducto.sqlAll(whereIn, limit);
            return "select count(*) from {"+sql+"} as Total";
        } 
        public static string sqlAll(string whereIn = "", string limit = "") {
            whereIn = whereIn == null || whereIn == "" ? "" : " where "+whereIn;
            string sql = @"
select uk.Id, 
p.`Id` as IdProducto, p.`Nombre` as Producto, 
c.`Nombre` as Categoria, 
p.`StockMinimo` as StockMinimo, k.`Existencia`, 
m.`Nombre` as Marca, 
(select concat(r.`Nombre`, '/', i.`Nombre` )
from imagen i
inner join ruta r
on i.`IdRuta` = r.`Id`
where i.`Id` = p.`IdImagen`
limit 1
) 
 as Imagen, 
(
select pv.`Valor` from precioventa pv where pv.`IdProducto` = p.`Id`
order by pv.`Id` desc
limit 1
) as PrecioVenta, 
(
select Descuento from oferta ofer
inner join ofertaproducto ofprod on ofer.Id = ofprod.`IdOferta`
where idproducto = p.`Id` and now() between ofer.FechaInicio and ofer.FechaFin limit 1
) as Descuento
from (
select max(kar.Id) as Id
from kardex kar
where kar.`IdProducto` in (
select p.Id from producto p 
inner join categoria c
on c.Id = p.IdCategoria
"+whereIn+@" 
)
group by kar.IdProducto
"+limit+@" 
) as uk

inner join kardex k 
on k.`Id` = uk.Id
inner join producto p
on p.`Id` = k.`IdProducto`

inner join categoria c
on c.`Id`= p.`IdCategoria`
inner join marca m
on m.`Id` = p.`IdMarca`
where k.Existencia > 0 ;
            ";
            return sql;
        }

        
        public static string agotados() {
            string sql = @"

select uk.Id, 
p.`Id` as IdProducto, p.`Nombre` as Producto, 
c.`Nombre` as Categoria, 
p.`StockMinimo` as StockMinimo, k.`Existencia`, 
m.`Nombre` as Marca, 
(select concat(r.`Nombre`, '/', i.`Nombre` )
from imagen i
inner join ruta r
on i.`IdRuta` = r.`Id`
where i.`Id` = p.`IdImagen`
limit 1
) 
 as Imagen, 
(
select pv.`Valor` from precioventa pv where pv.`IdProducto` = p.`Id`
order by pv.`Id` desc
limit 1
) as PrecioVenta, 
(
select Descuento from oferta ofer
inner join ofertaproducto ofprod on ofer.Id = ofprod.`IdOferta`
where idproducto = p.`Id` and now() between ofer.FechaInicio and ofer.FechaFin limit 1
) as Descuento
from (
select max(kar.Id) as Id
from kardex kar
where kar.`IdProducto` in (
select p.Id from producto p
)
group by kar.IdProducto
) as uk

inner join kardex k 
on k.`Id` = uk.Id
inner join producto p
on p.`Id` = k.`IdProducto`

inner join categoria c
on c.`Id`= p.`IdCategoria`
inner join marca m
on m.`Id` = p.`IdMarca`
where k.Existencia <= p.StockMinimo

            ";
            return sql;
        }
    }
}