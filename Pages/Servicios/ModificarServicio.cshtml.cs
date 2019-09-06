using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Servicios
{
    public class ModificarServicioModel : PageModel
    {
        [BindProperty]
        public Servicio Servicio { get; set; }
        public void OnGet(int? id)
        {
        }
    }
}