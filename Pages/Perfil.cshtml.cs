using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages
{
    public class PerfilModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; }
        public PerfilModel()
        {
        }
    }
}