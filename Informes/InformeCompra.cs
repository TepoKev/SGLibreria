using System; 

namespace SGLibreria.Informes
{
    public class InformeCompra
    {
            public int Id {get; set;}
            public string Proveedor {get;set; }
            public int Cantidad {get; set;}
            public decimal Total {get; set; }
            public DateTime Fecha {get;set;}
            public string Comprobante { get; set; }
            //public string Ruta {get; set; }


            
            public static string query() {
                return @"

SELECT c.`Id`, p.`Nombre` as Proveedor, `Fecha`, count(c.`Id`) as Cantidad, 
sum(d.`PrecioCompra`) as Total,
(select concat(rut.`Nombre`,'/', doc.`Nombre`) 
	from documento doc 
	inner join ruta rut 
	on doc.`IdRuta`= rut.`Id`
	where `IdCompra` = c.`Id` 
	limit 1
) as Comprobante
FROM compra c
inner join detallecompra d
on d.`IdCompra`= c.`Id`
inner join proveedor p
on c.`IdProveedor` = p.`Id`
inner join producto prod
on prod.`Id` = d.`IdProducto`
group by
c.`Id`
;
                ";
            }
    }
   
}