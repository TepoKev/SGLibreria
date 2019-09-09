using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Compras {
    public class RegistroCompraModel : PageModel {
        private readonly AppDbContext _context;
        public List<Producto> Productos { get; set; }
        public RegistroCompraModel (AppDbContext context) {
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

        [BindProperty]
        public Compra Compra { get; set; }

        [BindProperty]

        public Proveedor Proveedor { get; set; }

        public async Task<IActionResult> OnPostAsync () {
            if (!ModelState.IsValid) {
                return Page ();
            }
            if (!Proveedor.Enlace.Contains ("http")) {
                Proveedor.Enlace = "http://" + Proveedor.Enlace;
            }
            _context.Proveedores.Add (Proveedor);
            await _context.SaveChangesAsync ();
            return RedirectToPage ("/Proveedores/RegistroProveedor");
        }

        public void OnGet () {

        }

    }
}