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
        [BindProperty]
        public string Principal { get; set; }
        public RegistroProveedorModel(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            this.Proveedor.Estado = (sbyte)1;
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            if (!Proveedor.Enlace.Contains("http"))
            {
                Proveedor.Enlace = "http://" + Proveedor.Enlace;
            }
            _context.Proveedores.Add(Proveedor);
            await _context.SaveChangesAsync();
            Telefono telefono;
            for(var i = 0 ; i < Telefonos.Length ; i++)
            {
                telefono = new Telefono();
                telefono.IdProveedor = this.Proveedor.Id;
                telefono.Numero = Telefonos[i];
                if(i > 0){
                    if(!Telefonos[i].Equals(Telefonos[i-1])){
                        if(Telefonos[i].Equals(this.Principal)){
                            telefono.Principal = (sbyte) 1;
                        }else{
                            telefono.Principal = (sbyte) 0;
                        }
                        await this._context.Telefonos.AddAsync(telefono);
                    }else{
                        continue;
                    }
                }else{
                    if(Telefonos[i].Equals(this.Principal)){
                        telefono.Principal = (sbyte) 1;
                    }else{
                        telefono.Principal = (sbyte) 0;
                    }
                }
            }
            await this._context.SaveChangesAsync();
            return Page();
        }
    }
}