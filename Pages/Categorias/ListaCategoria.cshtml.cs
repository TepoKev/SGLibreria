using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> OnPostEstado(int IdCategoria, int Estado)
        {
            if(!CategoriaExists(IdCategoria)){
                return NotFound();
            }
            var cat = await this._context.Categorias.FirstOrDefaultAsync(x => x.Id == IdCategoria);
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
            Accion Accion = new Accion();
            Accion.IdBitacora = HttpContext.Session.GetInt32("IdBitacora").Value;
            Accion.Hora = DateTime.Now;
            Accion.Descripcion = "inhabilitó una categoria";
            this._context.Add(Accion);
            this._context.SaveChanges();
            return Page();
        }
        public async Task<JsonResult> OnPost(){
            this.Categoria.Estado = (sbyte) 1;
            if (!ModelState.IsValid)
            {
                return new JsonResult("");
            }
            _context.Categorias.Add(Categoria);
            await _context.SaveChangesAsync();
            this.Categorias=  _context.Categorias.ToList();
            Accion Accion = new Accion();
            Accion.IdBitacora = HttpContext.Session.GetInt32("IdBitacora").Value;
            Accion.Hora = DateTime.Now;
            Accion.Descripcion = "registro una categoria";
            this._context.Add(Accion);
            this._context.SaveChanges();
            return new JsonResult(this.Categorias);
        }
        public async Task<JsonResult> OnPostEditar(int IdCategoria, string Nombre){
            this.Categoria = await this._context.Categorias.FirstOrDefaultAsync(w => w.Id == IdCategoria);
            this.Categoria.Nombre = Nombre;
            if (!ModelState.IsValid)
            {
                return new JsonResult("");
            }
            _context.Entry(this.Categoria).Property("Nombre").IsModified = true;
            await _context.SaveChangesAsync();
            this.Categorias= await _context.Categorias.ToListAsync();
            Accion Accion = new Accion();
            Accion.IdBitacora = HttpContext.Session.GetInt32("IdBitacora").Value;
            Accion.Hora = DateTime.Now;
            Accion.Descripcion = "modificó una categoria";
            this._context.Add(Accion);
            this._context.SaveChanges();
            return new JsonResult(this.Categorias);
        }
        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}