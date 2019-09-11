using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SGLibreria.Pages
{
    public class MiBitacoraModel : PageModel
    {
        [BindProperty]
        public DateTime Desde { get; set; }
        [BindProperty]
        public DateTime Hasta { get; set; }
    }
}