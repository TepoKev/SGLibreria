using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Ofertas {
    public class ListaOfertaModel : PageModel {
        private readonly AppDbContext _context;
        public IList<Ofertaproducto> OfertaProducto {get; set;}

        public ListaOfertaModel (AppDbContext context) {
            _context = context;
        }

        public void OnGet(int? Pagina, int? CantidadPorFila, int? Maximo){
            this.OfertaProducto = this._context.Ofertaproducto
            .Include(of => of.IdOfertaNavigation).OrderBy(of => of.IdOfertaNavigation.FechaFin)
            .Include(of => of.IdProductoNavigation).ThenInclude(p => p.Precioventa).ToList();
        }
    }
}