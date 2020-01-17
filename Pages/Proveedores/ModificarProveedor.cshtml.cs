using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SGLibreria.Models;

namespace SGLibreria.Pages.Proveedores{
    public class ModificarProveedorModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Proveedor Proveedor { get; set; }
        public ModificarProveedorModel(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Proveedor = await _context.Proveedores.Include(x => x.Telefono).FirstOrDefaultAsync(p => p.Id == id);

            if (Proveedor == null)
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
            if (!ProveedorExists(Proveedor.Id))
            {
                return NotFound();
            }
            if(Proveedor.Enlace != null){
                if (!Proveedor.Enlace.Contains("http"))
                {
                    Proveedor.Enlace = "http://" + Proveedor.Enlace;
                }
            }
            this._context.Attach(this.Proveedor).State = EntityState.Modified;
            this._context.Entry(this.Proveedor).Property(p => p.Nombre).IsModified = true;
            this._context.Entry(this.Proveedor).Property(p => p.Estado).IsModified = false;
            this._context.Entry(this.Proveedor).Property(p => p.Correo).IsModified = true;
            this._context.Entry(this.Proveedor).Property(p => p.Direccion).IsModified = true;
            this._context.Entry(this.Proveedor).Property(p => p.Enlace).IsModified = true;
            try
            {
                await this._context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine("Mensaje ="+e.Message);
                throw;
            }
            Accion Accion = new Accion();
            Accion.IdBitacora = HttpContext.Session.GetInt32("IdBitacora").Value;
            Accion.Hora = DateTime.Now;
            Accion.Descripcion = "modificó datos de un proveedor";
            this._context.Add(Accion);
            this._context.SaveChanges();
            return RedirectToPage("/Proveedores/ListaProveedor");
        }
        private bool ProveedorExists(int id)
        {
            return _context.Proveedores.Any(p => p.Id == id);
        }
    }
}