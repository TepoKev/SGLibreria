using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Compras {
    public class ListaCompraModel : PageModel {
        private readonly AppDbContext _context;

        public ListaCompraModel (AppDbContext context) {
            _context = context;
        }

        [BindProperty]
        public Compra Compra { get; set; }
        [BindProperty]

        public Proveedor Proveedor { get; set; }
        public IList<Compra> Compras {get;set;}
        public IList<Detallecompra> Detalles {get;set;}
        public async Task OnGet() {
            Compras = await _context.Compras
            .Include(c => c.IdProveedorNavigation)
            .Include(c => c.Detallecompra)
            .ThenInclude ( d => d.IdPrecioCompraNavigation)
            .ToListAsync();
        }
        public IActionResult OnGetCompra(int? IdCompra) {
            Compra = _context.Compras
            .Include( c=> c.IdProveedorNavigation)
            .Where(c => c.Id == IdCompra).FirstOrDefault();
            Detalles = _context.Detallecompra
            .Include(d => d.IdPrecioCompraNavigation)
            .ThenInclude( p => p.IdProductoNavigation)
            .Where(d => d.IdCompra == IdCompra)
            .ToList();
            return Partial("_DetalleCompraPartial", this);
        }
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