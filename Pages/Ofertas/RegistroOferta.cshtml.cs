using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;
namespace SGLibreria.Pages.Ofertas {
    public class RegistroOfertaModel : PageModel {
        private readonly AppDbContext _context;
        [BindProperty]
        public Oferta Oferta {get; set;}
        [BindProperty]
        public int[] IdProductos { get; set; }
        public List<Producto> Productos { get; set; }
        public RegistroOfertaModel (AppDbContext context) {
            _context = context;
        }
        public void OnGet () {
        }
        public async Task<IActionResult> OnPostAsync(){
            if(!ModelState.IsValid){
                return NotFound();
            }
            await this._context.AddAsync(this.Oferta);
            await this._context.SaveChangesAsync();
            for(int i = 0 ; i < this.IdProductos.Length ; i ++){
                var OfertaPrducto = new Ofertaproducto();
                OfertaPrducto.IdProducto = this.IdProductos[i];
                OfertaPrducto.IdOferta = Oferta.Id;
                OfertaPrducto.Cantidad = 1;
                await this._context.AddAsync(OfertaPrducto);
                await this._context.SaveChangesAsync();
            }
            return Page();
        }
    }
}