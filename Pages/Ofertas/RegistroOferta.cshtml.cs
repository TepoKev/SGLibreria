using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Ofertas {
    public class RegistroOfertaModel : PageModel {
        private readonly AppDbContext _context;

        public RegistroOfertaModel (AppDbContext context) {
            _context = context;
        }

    }
}