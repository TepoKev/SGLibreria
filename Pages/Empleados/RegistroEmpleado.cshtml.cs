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

        public void OnPost(){
           
        }
    }
}