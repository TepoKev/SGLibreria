select k.`Id`, p.`Id` as IdProducto, p.`Nombre` as Producto, 
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
from kardex k
inner join producto p
on p.`Id` = k.`IdProducto`

inner join categoria c
on c.`Id`= p.`IdCategoria`
inner join marca m
on m.`Id` = p.`IdMarca`
where k.`IdProducto` in (
select p.Id from producto p
)
