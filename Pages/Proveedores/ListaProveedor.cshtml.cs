using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;
namespace SGLibreria.Pages.Proveedores
{
    public class ListaProveedorModel : PageModel
    {
        private readonly AppDbContext _context;
        public ListaProveedorModel(AppDbContext context)
        {
            _context = context;
        }
        public IList<Proveedor> Proveedor { get; set; }
        public List<Telefono> Telefonos { get; set; }
        public async Task OnGetAsync()
        {
            Proveedor = await this._context.Proveedores.Include(x => x.Telefono).ToListAsync();
        }
        public async Task OnPostAsync(int id, int estado){
            if(ProveedorExists(id)){
                Proveedor proveedor = await _context.Proveedores.FirstOrDefaultAsync(p => p.Id == id);
                proveedor.Estado = (sbyte) estado;
                _context.Attach(proveedor).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                    Proveedor = await _context.Proveedores.ToListAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
        }

        public async Task<PartialViewResult> OnPostTelefono(int IdProveedor){
            this.Proveedor = await this._context.Proveedores.Include(x => x.Telefono).ToListAsync();
            this.Telefonos = await this._context.Telefonos.Where(x => x.IdProveedor == IdProveedor).ToListAsync();
            return Partial("_TelefonoPartial", this);
        }
        private bool ProveedorExists(int id)
        {
            return _context.Proveedores.Any(p => p.Id == id);
        }
    }
}