using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Compras {
    public class RegistroCompraModel : PageModel {
        private readonly AppDbContext _context;
        public List<Producto> Productos { get; set; }
        public RegistroCompraModel (AppDbContext context) {
            _context = context;            
        }

        [BindProperty]
        public Compra Compra { get; set; }
        [BindProperty]
        public Producto Producto { get; set; }
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
        public async Task<JsonResult> OnPostAgregarProducto(Producto Producto){
            _context.Productos.Add(Producto);
            await _context.SaveChangesAsync();
            return new JsonResult(Producto);
        }

        public void OnGet () {

        }

    }
}