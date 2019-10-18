using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Categorias
{
    public class RegistroCategoriaModel: PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public Categoria Categoria {get;set;}

        public RegistroCategoriaModel(AppDbContext _context) {
            this._context = _context;
        }
        public void OnGet() {

        }
        public void OnPost() {
            _context.Categorias.Add(Categoria);
            _context.SaveChanges();
        }
    }
}