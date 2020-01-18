(#ultimo entrada de producto
select kc.Id as Id,  prod.Id as IdProducto,
prod.Nombre as Producto, kc.Existencia, prod.`StockMinimo`, cat.Nombre as Categoria, 
 mar.Nombre as Marca, 
(
select Descuento from oferta ofer
inner join ofertaproducto ofprod on ofer.Id = ofprod.`IdOferta`
where idproducto = prod.`Id` and now() between ofer.FechaInicio and ofer.FechaFin limit 1
) as Descuento, 
(
select pv.`Valor` from precioventa pv where pv.`IdProducto` = prod.`Id` limit 1
) as PrecioVenta, 
{
select pv.`Valor` from precioventa pv where pv.`IdProducto` = prod.`Id` limit 1
) as PrecioVenta
from producto prod
inner join categoria cat
on cat.Id = prod.IdCategoria
inner join categoria mar
on mar.Id = prod.IdMarca
inner join detallecompra dc
on dc.IdProducto = prod.id
INNER JOIN kardex kc
on kc.IdDetalleCompra = dc.Id
group by prod.Id 
ORDER BY kc.Id desc
)
union all (
#ultimo salida por producto
select kv.Id as Id,  prod.Id as IdProducto, 
prod.Nombre as Proucto, kv.Existencia, prod.`StockMinimo`, 
cat.Nombre as Categoria, 
 mar.Nombre as Marca, 
(
select Descuento from oferta ofer
inner join ofertaproducto ofprod on ofer.Id = ofprod.`IdOferta`
where idproducto = prod.`Id` and now() between ofer.FechaInicio and ofer.FechaFin limit 1
) as Descuento, 
(
select pv.`Valor` from precioventa pv where pv.`IdProducto` = prod.`Id` limit 1
) as PrecioVenta
from producto prod
inner join precioventa pv
on pv.IdProducto = prod.Id
INNER JOIN detalleventa dv
on dv.IdPrecioVenta = pv.Id
INNER JOIN kardex kv
on kv.IdDetalleVenta = dv.Id
inner join categoria cat
on cat.Id = prod.IdCategoria
inner join categoria mar
on mar.Id = prod.IdMarca
group by prod.`Id`
ORDER BY kv.Id desc
)
order by idproducto, Id;
/*
select p.`Id` from producto p;
*/

(
#ultimo entrada de producto
select kc.Id as Id,  prod.Id as IdProducto,
prod.Nombre as Producto, kc.Existencia, prod.`StockMinimo`
from producto prod
inner join detallecompra dc
on dc.IdProducto = prod.id
INNER JOIN kardex kc
on kc.IdDetalleCompra = dc.Id
WHERE prod.Id = 1
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
WHERE prod.Id = 1
ORDER BY kv.Id desc
limit 1
)
order by Id asc;

