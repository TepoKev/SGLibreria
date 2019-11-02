using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;
namespace SGLibreria.Pages.Productos {

  public class ListaProductoModel : PageModel {
    
    public List<Categoria> Categorias { get; set; }
    private readonly AppDbContext _context;
    [BindProperty]
    public Producto Producto {get;set;}

    public ListaProductoModel(AppDbContext context) {
       _context = context;
    }
    public JsonResult OnPostProducto(int? IdProducto) {
      Producto prod = _context.Productos.Where(p => p.Id == IdProducto).SingleOrDefault();
      return new JsonResult(prod);
    }
    public JsonResult OnPostCategorias() {
      IList<Categoria> Categorias = _context.Categorias.ToList();
      return new JsonResult(Categorias);
    }
    public JsonResult OnPostCategoriasMarcas() {
      IList<Categoria> Categorias = _context.Categorias.ToList();
      IList<Marca> Marcas = _context.Marcas.ToList();
      var resultado = new {
        marcas = Marcas, 
        categorias = Categorias
      };
      return new JsonResult(resultado);
    }
    public JsonResult OnPostMarcas() {
      IList<Marca> Marcas = _context.Marcas.ToList();
      return new JsonResult(Marcas);
    }
    public void OnGet() {
      Categorias = _context.Categorias.ToList();
    }
  }
}