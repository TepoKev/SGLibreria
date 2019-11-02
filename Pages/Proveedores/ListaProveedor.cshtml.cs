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
                Proveedor proveedor = await this._context.Proveedores.FirstOrDefaultAsync(p => p.Id == id);
                proveedor.Estado = (sbyte) estado;
                this._context.Attach(proveedor).State = EntityState.Modified;
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
        public async Task<JsonResult> OnPostRegistroTel(int IdProveedor, string Telefono){
            if(!ProveedorExists(IdProveedor) || Telefono.Equals("")){
                return new JsonResult("Error");
            }
            var Tel = new Telefono();
            Tel.IdProveedor = IdProveedor;
            Tel.Numero = Telefono;
            Tel.Principal = 0;
            await this._context.Telefonos.AddAsync(Tel);
            await this._context.SaveChangesAsync();
            return new JsonResult(Tel);
        }
        public async Task<PartialViewResult> OnPostTelefono(int IdProveedor){
            this.Proveedor = await this._context.Proveedores.Include(x => x.Telefono).ToListAsync();
            this.Telefonos = await this._context.Telefonos.Where(x => x.IdProveedor == IdProveedor).ToListAsync();
            return Partial("_TelefonoPartial", this);
        }
        public async Task<PartialViewResult> OnPostDelTelefono(int IdTelefono){
            int IdProveedor = -1;
            int Principal = 0;
            if(TelefonoExists(IdTelefono)){
                var Telefono = await this._context.Telefonos.FirstOrDefaultAsync(t => t.Id == IdTelefono);
                Principal = Telefono.Principal;
                IdProveedor = Telefono.IdProveedor;
                this._context.Telefonos.Remove(Telefono);
                await this._context.SaveChangesAsync();
                if(Principal == 1){
                    Telefono = await this._context.Telefonos.FirstAsync();
                    Telefono.Principal = (sbyte) 1;
                    this._context.Attach(Telefono).State = EntityState.Modified;
                    await this._context.SaveChangesAsync();
                }
            }
            this.Telefonos = await this._context.Telefonos.Where(x => x.IdProveedor == IdProveedor).ToListAsync();
            return Partial("_TelefonoPartial", this);
        }
        public async Task<PartialViewResult> OnPostEstadoTelefono(int IdTelefono){
            var telefono = await this._context.Telefonos.FirstOrDefaultAsync(x => x.Id == IdTelefono);
            if(telefono.Principal == 0){
                var telefonoPrincipal = await this._context.Telefonos.FirstOrDefaultAsync(x => (x.Principal == 1 && x.IdProveedor == telefono.IdProveedor));
                telefono.Principal = (sbyte) 1;
                telefonoPrincipal.Principal = (sbyte) 0;
                this._context.Attach(telefono).State = EntityState.Modified;
                this._context.Attach(telefonoPrincipal).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                    this.Telefonos = await this._context.Telefonos.Where(x => x.IdProveedor == telefono.IdProveedor).ToListAsync();
                    this.Proveedor = await _context.Proveedores.ToListAsync();
                    return Partial("_TelefonoPartial", this);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return Partial("_TelefonoPartial", this);
        }
        public async Task<PartialViewResult> OnPostNumTelefono(int IdTelefono, string Numero){
            var telefono = await this._context.Telefonos.FirstOrDefaultAsync(x => x.Id == IdTelefono);
            telefono.Numero = Numero;
            this._context.Attach(telefono).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            this.Telefonos = await this._context.Telefonos.Where(x => x.IdProveedor == telefono.IdProveedor).ToListAsync();
            this.Proveedor = await _context.Proveedores.ToListAsync();
            return Partial("_TelefonoPartial", this);
        }
        private bool ProveedorExists(int id)
        {
            return _context.Proveedores.Any(p => p.Id == id);
        }
        private bool TelefonoExists(int id)
        {
            return _context.Telefonos.Any(t => t.Id == id);
        }
    }
}