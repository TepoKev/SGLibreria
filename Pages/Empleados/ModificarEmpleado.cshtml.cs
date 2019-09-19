using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Empleados
{
    public class ModificarEmpleadoModel : PageModel
    {
        private readonly DbContext _context;
        public Persona Persona { get; set; }
        [BindProperty]
        public Empleado Empleado { get; set; }
        [BindProperty]
        public Usuario Usuario { get; set; }
        public ModificarEmpleadoModel(AppDbContext context)
        {
            this._context = context;
        }
    }
}