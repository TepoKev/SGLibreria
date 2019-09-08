using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Empleados
{
    public class BitacoraViewModel : PageModel
    {
        [BindProperty]
        public IList<Bitacora> Bitacoras { get; set; }
        [BindProperty]
        public DateTime FechaDesde { get; set; }
        [BindProperty]
        public DateTime FechaHasta { get; set; }
        public BitacoraViewModel()
        {
        }
        public IActionResult OnGetBitacoraPartial()
        {
            return Partial("_BitacoraPartial", this.Bitacoras);
        }
    }
}