using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Servicios
{
    public class ListaServicioModel : PageModel
    {
        [BindProperty]
        public IList<Servicio> Servicios { get; set; }

        public void OnGet()
        {
        }
    }
}