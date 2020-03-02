using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;
using MySql.Data.MySqlClient;
using SGLibreria.Informes;
using Microsoft.AspNetCore.Http;

namespace SGLibreria.Pages.Compras {
    public class ListaCompraModel : PageModel {
        private readonly AppDbContext _context;

        public ListaCompraModel (AppDbContext context) {
            this.Pagina = 0;
            this.Maximo = 4;
            _context = context;
        }

        [BindProperty]
        public Compra Compra { get; set; }
        [BindProperty]

        public Proveedor Proveedor { get; set; }
        public IList<Compra> Compras {get;set;}
        public IList<InformeCompra> Informes{get;set;}
        public IList<Detallecompra> Detalles {get;set;}

        public int? Pagina {get;set;}
        public int CantidadPorFila {get;set;}
        public int? Maximo {get;set;}
        public int Total{get;set;}
       
        public  async Task<PartialViewResult> OnGetTabla(int? IdProveedor, int? Pagina, int? Maximo) {
            string sql = InformeCompra.query();
            if(Pagina != null){
                this.Pagina = Pagina.Value;
            }
            if(Maximo != null){
                this.Maximo = Maximo.Value;
            }

            Informes =  await _context.InformeCompra.FromSql(sql).ToListAsync();
            /**/
            var total = _context.InformeCompra
            .FromSql(sql)
            .Count();
            this.Total = total;


            //IdProveedor = 65;//???????
            List<string> whereIn = new List<string>();
            List<MySqlParameter> wParams = new List<MySqlParameter>();
            int i = 0;
            if (IdProveedor != null)
            {
                //@Id le puedes poner como quieras
                //pero es mejor que sea algo representativo ya que es idproveedor no idcompra
                whereIn.Add("c.IdProveedor = @IdProveedor");
                wParams.Add(new MySqlParameter("@IdProveedor", IdProveedor));
            }
            
            string str = String.Join(" and ", whereIn.ToArray());
            //string limit = " limit "+Pagina.Value*Maximo.Value+"," +Maximo.Value;

            /*
            MySqlParameter mysqlp;
            mysqlp = new MySqlParameter("@NombreOCodigo", "%Cuaderno%");
            string lquery = "Select * from Producto where Nombre LIKE @NombreOCodigo or Codigo LIKE @NombreOCodigo";
            var list = _context.Productos.FromSql(lquery, mysqlp).ToList();
            */
            string sqlprueba = InformeCompra.query(str);
            //Console.WriteLine(sqlprueba);
            /*
            this.Informes = _context.InformeCompra.FromSql(sqlprueba, wParams.ToArray())
            .ToList();
            */
            this.Informes = _context.InformeCompra.FromSql(sqlprueba, wParams.ToArray())
            .Skip((this.Pagina.Value)* this.Maximo.Value).Take(this.Maximo.Value).ToList();

            Total = _context.InformeCompra.FromSql(sqlprueba, wParams.ToArray()).Count();
            return Partial("/Pages/Shared/OthersPartials/_TablaComprasPartial.cshtml", this);
        }

        

        public PartialViewResult OnGetCompra(int? IdCompra) {
            
            Compra = _context.Compras
            .Include( c=> c.IdProveedorNavigation)
            .Where(c => c.Id == IdCompra).FirstOrDefault();
            Detalles = _context.Detallecompra
            .Where(d => d.IdCompra == IdCompra)
            .Include(x => x.IdProductoNavigation)
            .ToList();

            return Partial("_DetalleCompraPartial", this);
        }
    }
}

/*

var result = _context.Detallecompra
            .Include(dc=> dc.IdCompraNavigation)
             //   .ThenInclude(c => c.IdProveedorNavigation)
            .GroupBy(x => x.IdCompraNavigation)
            .Select(g => new {
                Compra = g.Key, 
                Cantidad = g.Count(),
            })
            .ToList();
            
*/
/*
var query = from detalle in _context.Set<Detallecompra>()
            join compra in _context.Set<Compra>()
            on detalle.IdCompra equals compra.Id
            join proveedor in _context.Set<Proveedor>()
            on compra.IdProveedor
            equals proveedor.Id
            group compra by new {
                prov = proveedor.Nombre, 
                cantidad = detalle.Cantidad,
                Fecha = compra.Fecha
            } into g
            select new {
                g.Key,
            }
            ;
        var result = query.ToList();
*/
 
 /*Compras = await _context.Compras
            .Include(c => c.IdProveedorNavigation)
            .Include(c => c.Detallecompra)
            .Include(c => c.Documento)
            .ThenInclude(d => d.IdRutaNavigation)
            .OrderByDescending(x => x.Fecha)
            .ToListAsync();
            */