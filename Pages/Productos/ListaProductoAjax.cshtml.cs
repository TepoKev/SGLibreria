using System;

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;
using SGLibreria.Informes;

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
            List<string> whereInLimit = new List<string>();
            List<object> whereInLimitParams = new List<object>();
            int i = 0;
            if (Id != null)
            {
                whereInLimit.Add("p.Id =  "+Id+"+");
                whereInLimitParams.Add(Id);
            }
            else if (IdCategoria != null)
            {
                whereInLimit.Add("IdCategoria = "+IdCategoria.Value+" and  (p.Nombre like '%"+NombreOCodigo+"%' or p.Codigo like '%"+NombreOCodigo+"%')");
                whereInLimitParams.Add(IdCategoria.Value);
                whereInLimitParams.Add(NombreOCodigo);
                whereInLimitParams.Add(NombreOCodigo);
            }
            else if(NombreOCodigo != null &&  NombreOCodigo!="")
            {
                whereInLimit.Add($"p.Nombre like '%"+NombreOCodigo+"%' or p.Codigo like '%"+NombreOCodigo+"%'");
                whereInLimitParams.Add(NombreOCodigo);
                whereInLimitParams.Add(NombreOCodigo);
            }
            
            if (IdCategoria == null)
            {
                // Consulta = Consulta.Skip((Pagina.Value)* Maximo.Value).Take(Maximo.Value);
            }
            string str = String.Join(" and ", whereInLimit.ToArray());
            string limit = " limit "+Pagina.Value*Maximo.Value+"," +Maximo.Value;
            string sql = ConsultaProducto.sqlAll(str, limit);
            Console.WriteLine(sql);
            
            string sqlCount = ConsultaProducto.sqlAllCount(str, limit);
            this.ListProductos = _context.ConsultaProducto.FromSql(sql).ToList();
            //var total  = _context.ConsultaProducto.FromSql(sqlCount).Single();
            return Page();
        }
    }
}