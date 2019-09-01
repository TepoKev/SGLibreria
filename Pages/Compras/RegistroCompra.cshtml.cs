using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Compras {
    public class RegistroCompraModel : PageModel {
        private readonly AppDbContext _context;

        public RegistroCompraModel (AppDbContext context) {
            _context = context;
        }

        [BindProperty]
        public Compra Compra { get; set; }

        [BindProperty]

        public Proveedor Proveedor { get; set; }

        public async Task<IActionResult> OnPostAsync () {
            if (!ModelState.IsValid) {
                return Page ();
            }
            if (!Proveedor.Enlace.Contains ("http")) {
                Proveedor.Enlace = "http://" + Proveedor.Enlace;
            }
            _context.Proveedores.Add (Proveedor);
            await _context.SaveChangesAsync ();
            return RedirectToPage ("/Proveedores/RegistroProveedor");
        }
    }
}