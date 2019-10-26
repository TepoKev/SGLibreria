using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Empleados
{
    public class ListaEmpleadoModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<Empleado> Empleados {get;set;}

        public ListaEmpleadoModel(AppDbContext context)
        {
            this._context = context;
        }

        public async Task OnGet()
        {
            this.Empleados = await this._context.Empleados.Include(e => e.IdPersonaNavigation).Include(e => e.IdUsuarioNavigation).ToListAsync();
        }
    }
}