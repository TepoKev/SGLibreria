using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Compras{
    public class RegistroCompraModel : PageModel
    {
        [BindProperty]
        public Compra Compra { get; set; }
        public RegistroCompraModel()
        {
        }
    }
}