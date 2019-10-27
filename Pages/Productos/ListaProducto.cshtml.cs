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
        
    public ListaProductoModel(AppDbContext context) {
       _context = context;
    }

    public void OnGet() {
      Categorias = _context.Categorias.ToList();
    }
  }
}