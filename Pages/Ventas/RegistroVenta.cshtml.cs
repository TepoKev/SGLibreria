using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Ventas
{
    public class RegistroVentaModel : PageModel
    {
        [BindProperty]
        public Venta Venta { get; set; }
        private readonly AppDbContext _context;
        public RegistroVentaModel(AppDbContext context)
        {
            _context = context;
        }
    }
}