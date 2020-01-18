using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Reportes
{
    public class ReporteVentasModel : PageModel
    {
        private readonly AppDbContext _context;
        public ReporteVentasModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // return View(await _context.Customers.ToListAsync());
            //return new ViewAsPdf("ReporteVentas", this);
            return Page();
        }
    }
}