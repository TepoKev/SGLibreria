using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Productos {

  public class ListaProductoModel : PageModel {
    public List<Producto> Productos { get; set; }
    public ListaProductoModel () {

    }

    public void OnGet () {

    }

  }
}