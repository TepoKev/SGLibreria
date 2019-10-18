using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Categorias
{
    public class ListaCategoriaModel: PageModel
    {
         [BindProperty]
        public Categoria Categoria {get;set;}
        public List<Categoria> Categorias {get;set;}
        private readonly  AppDbContext _context;
        public ListaCategoriaModel(AppDbContext context) {
            this._context = context;
            Categorias = new List<Categoria>();

        }

        public async Task OnGetAsync(int? Id) {
            this.Categorias=  _context.Categorias.ToList();

            if(Id !=null){
                this.Categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == Id);
            }
        }
        public IActionResult OnPost(){
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(this.Categoria.Id == 0) {
                _context.Categorias.Add(Categoria);
                _context.SaveChanges();

            } else {
                _context.Attach(this.Categoria);
                _context.Entry(Categoria).Property(a => a.Nombre).IsModified = true;

                try
                {
                     _context.SaveChangesAsync();
                    return Page();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(Categoria.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            
            this.Categorias=_context.Categorias.ToList();
            
            return Page();
        }


        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}