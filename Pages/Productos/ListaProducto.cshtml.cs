
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Productos
{
    
    public class ListaProductoModel: PageModel
    {
      public List<Producto> Productos {get;set;}
      public ListaProductoModel() {
                Productos = new List<Producto> {
           new Producto{
        Nombre = "Borradores", 
        IdImagenNavigation = new Imagen{
          Nombre = "/Productos/borradores.jpg"
        }

        }, 
        new Producto{
        Nombre = "Colores", 
        IdImagenNavigation = new Imagen{
          Nombre = "/Productos/colores.jpg"
        }
        }, 
        new Producto{
        Nombre = "Cuadernos", 
        IdImagenNavigation = new Imagen{
          Nombre = "/Productos/cuaderno.jpg"
        }
        }, 
        new Producto{
        Nombre = "Lapiceros", 
        IdImagenNavigation = new Imagen{
          Nombre = "/Productos/lapiceros.jpg"
        }
        }, 
        new Producto{
        Nombre = "Borradores", 
        IdImagenNavigation = new Imagen{
          Nombre = "/Productos/borradores.jpg"
        }
        
        }, 
        new Producto{
        Nombre = "Colores", 
        IdImagenNavigation = new Imagen{
          Nombre = "/Productos/colores.jpg"
        }
        }
        };

      }

      public void OnGet() {
      
      }

    }
}