using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;
using System.Linq;

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
        public IList<Categoria> Categorias {get;set;}
        public IList<Marca> Marca {get;set;}
        public IList<Proveedor> Proveedores {get;set;}
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
        public async Task<PartialViewResult> OnPostAgregarProducto(Producto Producto){
            if(!ModelState.IsValid) {
                return Partial("_ProductoPartial",null);
            }
            //_context.Productos.Add(Producto);
            //await _context.SaveChangesAsync();
            return Partial("_ProductoPartial",null);
        }

        public void OnGet () {
            this.Categorias = _context.Categorias.ToList();
            this.Categorias = _context.Categorias.ToList();
            this.Proveedores = _context.Proveedores.ToList();
        }
        public JsonResult OnGetListaCategorias() {
            this.Categorias = _context.Categorias.ToList();
/*
            this.Categorias = _context.Categorias.ToList();
            this.Proveedores = _context.Proveedores.ToList();
*/
            return new JsonResult(this.Categorias);
        }
    }
}