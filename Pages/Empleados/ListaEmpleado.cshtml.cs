using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Empleados
{
    public class ListaEmpleadoModel : PageModel
    {
        private readonly AppDbContext _context;
        List<Empleado> Empleados {get;set;}

        public ListaEmpleadoModel(AppDbContext context)
        {
            this._context = context;
        }

        public void OnGet()
        {
        }
    }
}