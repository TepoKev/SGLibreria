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
        public int? Pagina {get;set;}
        public int? Maximo {get;set;}
        public int Total{get;set;}
        public ListaCategoriaModel(AppDbContext context) {
            this._context = context;
            Categorias = new List<Categoria>();
            this.Pagina = 0;
            this.Maximo = 2;
        }



        public  async Task<PartialViewResult> OnGetTabla(int? Id, int? Pagina, int? Maximo) {
            if(Pagina != null){
                this.Pagina = Pagina.Value;
            }
            if(Maximo != null){
                this.Maximo = Maximo.Value;
            }
            this.Categorias = _context.Categorias.ToList();
            var total = _context.Categorias.Select(
                        q => new
                        {
                            co = Categorias.Count()
                        }
                    ).FirstOrDefault();
            this.Total = total.co;
            this.Categorias =  _context.Categorias.Where(c => c.Estado!= 0).
            Skip((this.Pagina.Value)* this.Maximo.Value).Take(this.Maximo.Value).ToList();
            
            if(Id !=null){
                this.Categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == Id);
            }
            return Partial("/Pages/Shared/OthersPartials/_TablaCategoriasPartial.cshtml", this);
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
            var existe = _context.Categorias.Where(m => m.Nombre == this.Categoria.Nombre).Any();
            string error=null;
            if(existe){
                error = "Ya existe un registro con el mismo nombre";
            }else{
                this.Categoria.Estado = (sbyte) 1;
                if (!ModelState.IsValid)
                {
                    return new JsonResult("");
                }
                _context.Categorias.Add(Categoria);
                await _context.SaveChangesAsync();
                Accion Accion = new Accion();
                Accion.IdBitacora = HttpContext.Session.GetInt32("IdBitacora").Value;
                Accion.Hora = DateTime.Now;
                Accion.Descripcion = "registro una categoria";
                this._context.Add(Accion);
                this._context.SaveChanges();
            }
            
            this.Categorias=  _context.Categorias.ToList();
            
            return new JsonResult(new {categorias = this.Categorias, error = error});
        }
        public async Task<JsonResult> OnPostEditar(int IdCategoria, string Nombre){
            this.Categoria = await this._context.Categorias.FirstOrDefaultAsync(w => w.Id == IdCategoria);
            this.Categoria.Nombre = Nombre;
            var existe = _context.Categorias.Where(m => m.Nombre == Nombre).Any();
            string error=null;
            if(existe){
                error = "Ya existe un registro con el mismo nombre";
            }else{
                if (!ModelState.IsValid)
                {
                    return new JsonResult("");
                }
                _context.Entry(this.Categoria).Property("Nombre").IsModified = true;
                await _context.SaveChangesAsync();
                Accion Accion = new Accion();
                Accion.IdBitacora = HttpContext.Session.GetInt32("IdBitacora").Value;
                Accion.Hora = DateTime.Now;
                Accion.Descripcion = "modificó una categoria";
                this._context.Add(Accion);
                this._context.SaveChanges();
            }
            
            this.Categorias= await _context.Categorias.ToListAsync();
           
            return new JsonResult(new {categorias = this.Categorias, error = error});
        }
        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}