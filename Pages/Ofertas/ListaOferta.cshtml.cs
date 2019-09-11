<<<<<<< HEAD
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Ofertas {
    public class ListaOfertaModel : PageModel {
        private readonly AppDbContext _context;

        public ListaOfertaModel (AppDbContext context) {
            _context = context;
        }

     
    }
=======
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Ofertas {
    public class ListaOfertaModel : PageModel {
        private readonly AppDbContext _context;

        public ListaOfertaModel (AppDbContext context) {
            _context = context;
        }

     
    }
>>>>>>> f094bacc920d39e6c310500de6171d74823dff2c
}