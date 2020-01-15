(#ultimo entrada de producto
select kc.Id as Id,  prod.Id as IdProducto,
prod.Nombre, kc.Existencia, prod.`StockMinimo`
from producto prod
inner join detallecompra dc
on dc.IdProducto = prod.id
INNER JOIN kardex kc
on kc.idDetalleCompra = dc.Id
group by prod.Id 
ORDER BY kc.Id desc
)
union all (
#ultimo salida por producto
select kv.Id as Id,  prod.Id as IdProducto, 
prod.Nombre, kv.Existencia, prod.`StockMinimo`
from producto prod
inner join precioventa pv
on pv.IdProducto = prod.Id
INNER JOIN detalleventa dv
on dv.IdPrecioVenta = pv.Id
INNER JOIN kardex kv
on kv.IdDetalleVenta = dv.Id
group by prod.`Id`
ORDER BY kv.Id desc
);
/*
select p.`Id` from producto p;
*/