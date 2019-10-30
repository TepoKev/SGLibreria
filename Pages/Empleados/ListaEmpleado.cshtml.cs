using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;
namespace SGLibreria.Pages.Empleados
{
    public class ListaEmpleadoModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<Empleado> Empleados {get;set;}
        [BindProperty]
        public Empleado Empleado {get;set;}
        public ListaEmpleadoModel(AppDbContext context)
        {
            this._context = context;
        }
        public async Task OnGet()
        {
            this.Empleados = await this._context.Empleados.Include(x => x.IdPersonaNavigation).Include(x => x.IdUsuarioNavigation).ToListAsync();
        }
        public async Task<PartialViewResult> OnPostEmpleadoEdit(int IdEmpleado)
        {
            this.Empleado = await this._context.Empleados.Include(x => x.IdPersonaNavigation).Include(x => x.IdUsuarioNavigation).FirstOrDefaultAsync(x => x.Id == IdEmpleado);
            return Partial("_EmpleadoPartial", this);
        }
    }
}