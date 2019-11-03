using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;
namespace SGLibreria.Pages.Ofertas {
    public class RegistroOfertaModel : PageModel {
        private readonly AppDbContext _context;
        [BindProperty]
        public Oferta Oferta {get; set;}
        public List<Producto> Productos { get; set; }
        public RegistroOfertaModel (AppDbContext context) {
            _context = context;
        }
        public void OnGet () {
        }
    }
}