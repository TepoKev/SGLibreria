using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Marcas
{
    public class ListaMarcaModel: PageModel
    {
        [BindProperty]
        public Marca Marca {get;set;}
        public List<Marca> Marcas {get;set;}
        private readonly  AppDbContext _context;
        public ListaMarcaModel(AppDbContext context) {
            this._context = context;
            Marcas = new List<Marca>();
        }

        public async Task OnGetAsync(int? Id) {
            this.Marcas=  _context.Marcas.ToList();
            if(Id !=null){
                this.Marca = await _context.Marcas.FirstOrDefaultAsync(c => c.Id == Id);
            }
        }
        public async Task<IActionResult> OnPostEstado(int IdMarca, int Estado)
        {
            if(!MarcaExists(IdMarca)){
                return NotFound();
            }
            var cat = await this._context.Marcas.FirstOrDefaultAsync(x => x.Id == IdMarca);
            cat.Estado = (sbyte) Estado;
            this._context.Attach(cat).State = EntityState.Modified;
            try
            {
                await this._context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine("Mensaje ="+e.Message);
                throw;
            }
            return Page();
        }
        public async Task<JsonResult> OnPost(){
            this.Marca.Estado = (sbyte) 1;
            if (!ModelState.IsValid)
            {
                return new JsonResult("");
            }
            _context.Marcas.Add(Marca);
            await _context.SaveChangesAsync();
            this.Marcas=  _context.Marcas.ToList();
            return new JsonResult(this.Marcas);
        }
        public async Task<JsonResult> OnPostEditar(int IdMarca, string Nombre){
            this.Marca = await this._context.Marcas.FirstOrDefaultAsync(w => w.Id == IdMarca);
            this.Marca.Nombre = Nombre;
            if (!ModelState.IsValid)
            {
                return new JsonResult("");
            }
            _context.Entry(this.Marca).Property("Nombre").IsModified = true;
            await _context.SaveChangesAsync();
            this.Marcas= await _context.Marcas.ToListAsync();
            return new JsonResult(this.Marcas);
        }
        private bool MarcaExists(int id)
        {
            return _context.Marcas.Any(e => e.Id == id);
        }
    }
}