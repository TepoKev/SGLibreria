using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

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
        public List<Producto> Productos {get;set;}
        public int Pagina {get;set;}
        public int CantidadPorFila {get;set;}
        public int Maximo {get;set;}
        public string NombreOCodigo { get; set;}
        public ListaProductoAjaxModel(AppDbContext context) {
            this.Pagina = 0;
            this.CantidadPorFila = 6;
            this.Maximo = this.CantidadPorFila * 3;
            _context = context;
        }

        public IActionResult OnGet(int? Pagina, int? CantidadPorFila, int? Maximo, string NombreOCodigo, int? IdCategoria) {
            IQueryable<Producto> Consulta = _context.Productos
            .Include(p => p.IdCategoriaNavigation)
            .Include(p => p.IdMarcaNavigation)
            .Include(x=>x.Precioventa)
            .Include(x=>x.IdImagenNavigation)
            .ThenInclude(x=>x.IdRutaNavigation);
            if(IdCategoria!=null) {
                Consulta = Consulta.Where(p => p.IdCategoria == IdCategoria && EF.Functions.Like(p.Nombre, $"%{NombreOCodigo}%"));
            } else {
                Consulta = Consulta.Where(p => EF.Functions.Like(p.Nombre, $"%{NombreOCodigo}%"));
            }
            this.Productos = Consulta.ToList();
            return Page();
        }
    }
}