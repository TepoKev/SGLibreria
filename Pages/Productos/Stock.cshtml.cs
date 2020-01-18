using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Informes;
using SGLibreria.Models;
namespace SGLibreria.Pages.Productos
{
    public class StockModel : PageModel
    {
        
        private readonly AppDbContext _context;
        public IList<ConsultaProducto> ListProductos {get; set;}

        public StockModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(){
            this.ListProductos = _context.ConsultaProducto.FromSql(ConsultaProducto.agotados()).ToList();
            return Page();
        }
    }
}