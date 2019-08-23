using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Proveedores
{
    public class ListaProveedorModel : PageModel
    {
        private readonly AppDbContext _context;
        public ListaProveedorModel(AppDbContext context)
        {
            _context = context;
        }
        public IList<Proveedor> Proveedor { get; set; }

        public async Task OnGetAsync()
        {
            Proveedor = await _context.Proveedores.ToListAsync();
        }
    }
}