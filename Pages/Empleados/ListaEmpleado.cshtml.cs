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
        public List<Persona> Personas {get;set;}

        public ListaEmpleadoModel(AppDbContext context)
        {
            this._context = context;
        }

        public async Task OnGet()
        {
            this.Personas = await this._context.Personas.Include(p => p.Empleado).ThenInclude(e => e.Usuario).ToListAsync();
        }
    }
}