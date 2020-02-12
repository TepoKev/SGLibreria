using System;

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;
using SGLibreria.Informes;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
namespace SGLibreria.Pages.Productos
{
    public class ListaProductoAjaxModel : PageModel
    {
        /*
        Maximo es el número máximo de registros que mostrará está pagina
        Pagina es el número de página o paginación que se va a mostrar
        CantidadPorFila: número de productos que irán en cada <div class="card-group">
        */
        private readonly AppDbContext _context;
        public int Pagina { get; set; }
        public int CantidadPorFila { get; set; }
        public int Maximo { get; set; }
        public string NombreOCodigo { get; set; }
        public int Estado { get; set; }
        public bool? Boton { get; set; }
        public int Total { get; set; }
        public IList<ConsultaProducto> ListProductos {get; set;}
        public ListaProductoAjaxModel(AppDbContext context)
        {
            this.Pagina = 0;
            this.CantidadPorFila = 6;
            this.Maximo = this.CantidadPorFila * 18;
            _context = context;
        }
        public IActionResult OnGet(int? Id, int? Pagina, int? CantidadPorFila, int? Maximo, string NombreOCodigo, int? IdCategoria, bool? Boton)
        {
            this.Boton = Boton;
           
            this.Boton = Boton;

            if (Pagina == null)
            {
                Pagina = this.Pagina;
            }
            if (CantidadPorFila == null)
            {
                CantidadPorFila = this.CantidadPorFila;
            }
            if (Maximo == null)
            {
                Maximo = this.Maximo;
            }
            List<string> whereIn = new List<string>();
            List<MySqlParameter> wParams = new List<MySqlParameter>();
            int i = 0;
            if (Id != null)
            {
                whereIn.Add("p.Id = @Id");
                wParams.Add(new MySqlParameter("@Id", Id));
            }
            else if (IdCategoria != null)
            {
                whereIn.Add("IdCategoria = @IdCategoria and  (p.Nombre like @NombreOCodigo or p.Codigo like @NombreOCodigo)");
                wParams.Add(new MySqlParameter("@IdCategoria", IdCategoria.Value));
                wParams.Add(new MySqlParameter("@NombreOCodigo", "%"+NombreOCodigo+"%"));
            }
            else if(NombreOCodigo != null &&  NombreOCodigo!="")
            {
                whereIn.Add("p.Nombre like @NombreOCodigo or p.Codigo like @NombreOCodigo");
                wParams.Add(new MySqlParameter("@NombreOCodigo", "%"+NombreOCodigo+"%"));
            }
            if (IdCategoria == null)
            {
                // Consulta = Consulta.Skip((Pagina.Value)* Maximo.Value).Take(Maximo.Value);
            }
            string str = String.Join(" and ", whereIn.ToArray());
            string limit = " limit "+Pagina.Value*Maximo.Value+"," +Maximo.Value;

            /*
            MySqlParameter mysqlp;
            mysqlp = new MySqlParameter("@NombreOCodigo", "%Cuaderno%");
            string lquery = "Select * from Producto where Nombre LIKE @NombreOCodigo or Codigo LIKE @NombreOCodigo";
            var list = _context.Productos.FromSql(lquery, mysqlp).ToList();
            */
            string sql = ConsultaProducto.sqlAll(str, limit);
            Console.WriteLine(sql);
            string sqlCount = ConsultaProducto.sqlAllCount(str, limit);
            this.ListProductos = _context.ConsultaProducto.FromSql(sql, wParams.ToArray())
            .ToList();

            Total = _context.ConsultaProducto.FromSql(sql, wParams.ToArray()).Count();
            return Page();
        }
    }
}