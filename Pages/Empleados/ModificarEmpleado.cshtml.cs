using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Empleados
{
    public class ModificarEmpleadoModel : PageModel
    {
        private readonly AppDbContext _context;
        public Empleado Empleado { get; set; }
        public ModificarEmpleadoModel(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> OnGet(int? id){
            if (id == null)
            {
                return NotFound();
            }
            this.Empleado = await _context.Empleados.Include(e => e.IdPersonaNavigation).Include(e => e.IdUsuarioNavigation).FirstOrDefaultAsync(e => e.Id == id);
            if (Empleado == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(Empleado.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Proveedores/ListaProveedor");
        }
        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}