<<<<<<< HEAD
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Ofertas {
    public class RegistroOfertaModel : PageModel {
        private readonly AppDbContext _context;
        public List<Producto> Productos { get; set; }
        public RegistroOfertaModel (AppDbContext context) {
            _context = context;

            Productos = new List<Producto> {
                new Producto {
                Nombre = "Borradores",
                IdImagenNavigation = new Imagen {
                Nombre = "/Productos/borradores.jpg"
                }

                },
                new Producto {
                Nombre = "Colores",
                IdImagenNavigation = new Imagen {
                Nombre = "/Productos/colores.jpg"
                }
                },
                new Producto {
                Nombre = "Cuadernos",
                IdImagenNavigation = new Imagen {
                Nombre = "/Productos/cuaderno.jpg"
                }
                },
                new Producto {
                Nombre = "Lapiceros",
                IdImagenNavigation = new Imagen {
                Nombre = "/Productos/lapiceros.jpg"
                }
                },
                new Producto {
                Nombre = "Borradores",
                IdImagenNavigation = new Imagen {
                Nombre = "/Productos/borradores.jpg"
                }

                },
                new Producto {
                Nombre = "Colores",
                IdImagenNavigation = new Imagen {
                Nombre = "/Productos/colores.jpg"
                }
                }
            };
        }

        public void OnGet () {

        }
    }
=======
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Ofertas {
    public class RegistroOfertaModel : PageModel {
        private readonly AppDbContext _context;

        public RegistroOfertaModel (AppDbContext context) {
            _context = context;
        }

    }
>>>>>>> f094bacc920d39e6c310500de6171d74823dff2c
}