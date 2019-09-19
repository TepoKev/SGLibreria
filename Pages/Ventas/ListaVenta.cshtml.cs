using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Ventas
{
    public class ListaVentaModel: PageModel
    {
        private readonly AppDbContext _context;
        public List<Venta> Ventas {get;set;}
        public ListaVentaModel(AppDbContext context) {
            _context = context;
        }
        public void OnGet() {

        }
    }
}