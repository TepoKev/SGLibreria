using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Ventas
{
    public class ListaVentaModel: PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public List<Venta> Ventas {get;set;}
        [BindProperty]
        public Venta Venta { get; set; }
        public ListaVentaModel(AppDbContext context) {
            _context = context;
        }
        public async Task<IActionResult> OnGet() {
            this.Ventas = await this._context.Ventas
                .Include(v => v.Detalleventa)
                .ThenInclude(dtv => dtv.IdPrecioVentaNavigation)
                .ThenInclude(dtv => dtv.IdProductoNavigation)
                .Include(v => v.Detalleservicio)
                .ThenInclude(dts => dts.IdTipoServicioNavigation)
                .ThenInclude(tps => tps.IdServicioNavigation)
                .Include(v => v.IdUsuarioNavigation)
                .ThenInclude(u => u.Empleado)
                .ThenInclude(e => e.IdPersonaNavigation).ToListAsync();
            return Page();
        }
        public async Task<PartialViewResult> OnPostDetalle(int idVenta){
            this.Venta = await this._context.Ventas.Where(v => v.Id == idVenta)
                .Include(v => v.Detalleventa)
                    .ThenInclude(dtv => dtv.IdPrecioVentaNavigation)
                    .ThenInclude(dtv => dtv.IdProductoNavigation)
                .Include(v => v.Detalleservicio)
                    .ThenInclude(dts => dts.IdTipoServicioNavigation)
                        .ThenInclude(tps => tps.IdServicioNavigation)
                .Include(v => v.IdUsuarioNavigation)
                    .ThenInclude(u => u.Empleado)
                    .ThenInclude(e => e.IdPersonaNavigation).FirstOrDefaultAsync();
            foreach (var item in this.Venta.Detalleservicio)
            {
                item.IdTipoServicioNavigation.IdCompaniaNavigation = await this._context.Companias.Where(c => c.Id == item.IdTipoServicioNavigation.IdCompania).FirstOrDefaultAsync();
            }
            return Partial("_DetalleVentaPartial", this);
        }
    }
}