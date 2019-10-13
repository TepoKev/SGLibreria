using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Proveedores
{
    public class RegistroProveedorModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public Proveedor Proveedor { get; set; }
        [BindProperty]
        public string[] Telefonos { get; set; }
        public RegistroProveedorModel(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var tamtel = Telefonos.Length;
            this.Proveedor.Estado = (sbyte)1;
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            if (!Proveedor.Enlace.Contains("http"))
            {
                Proveedor.Enlace = "http://" + Proveedor.Enlace;
            }
            this._context.Proveedores.Add(Proveedor);
            await this._context.SaveChangesAsync();
            if(tamtel > 0){
                Telefono telefono;
                telefono = new Telefono();
                telefono.IdProveedor = this.Proveedor.Id;
                telefono.Numero = Telefonos[0];
                telefono.Principal = (sbyte) 1;
                await this._context.Telefonos.AddAsync(telefono);
                for(var i = 1 ; i < Telefonos.Length ; i++)
                {
                    telefono = new Telefono();
                    telefono.IdProveedor = this.Proveedor.Id;
                    telefono.Numero = Telefonos[i];
                    telefono.Principal = (sbyte) 0;
                    await this._context.Telefonos.AddAsync(telefono);
                }
                await this._context.SaveChangesAsync();
            }
            return Page();
        }
    }
}