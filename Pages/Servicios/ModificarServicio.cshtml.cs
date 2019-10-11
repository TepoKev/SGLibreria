using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Servicios
{
    public class ModificarServicioModel : PageModel
    {
        [BindProperty]
        public Servicio Servicio { get; set; }
        [BindProperty]
        public Compania Compania { get; set; }
        [BindProperty]
        public Tiposervicio Tipo { get; set; }
        public ModificarServicioModel()
        {
        }
        public void OnGet(int? id)
        {
        }
    }
}