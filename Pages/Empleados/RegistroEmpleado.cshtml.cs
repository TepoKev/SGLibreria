using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Empleados
{
    public class RegistroEmpleadoModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public Persona Persona { get; set; }
        [BindProperty]
        public Empleado Empleado { get; set; }
        [BindProperty]
        public Usuario Usuario { get; set; }
        public RegistroEmpleadoModel(AppDbContext context)
        {
            this._context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(){
            if(!ModelState.IsValid){
                return NotFound();
            }
            await this._context.Personas.AddAsync(this.Persona);
            await this._context.SaveChangesAsync();
            this.Empleado.IdPersona = this.Persona.Id;
            await this._context.Empleados.AddAsync(this.Empleado);
            await this._context.SaveChangesAsync();
            this.Usuario.IdEmpleado = this.Empleado.Id;
            await this._context.Usuarios.AddAsync(this.Usuario);
            await this._context.SaveChangesAsync();
            return Page();
        }
    }
}