using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Proveedores
{
    public class RegistroProveedorModel : PageModel
    {
        private readonly AppDbContext _context;
        public RegistroProveedorModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Proveedor Proveedor { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            this.Proveedor.Estado = 1;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(!Proveedor.Enlace.Contains("http"))
            {
                Proveedor.Enlace = "http://" + Proveedor.Enlace;
            }
            _context.Proveedores.Add(Proveedor);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Proveedores/RegistroProveedor");
        } 
    }
}