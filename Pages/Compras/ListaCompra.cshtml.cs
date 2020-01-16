using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;
using System;
using MySql.Data.MySqlClient;
using SGLibreria.Informes;
namespace SGLibreria.Pages.Compras {
    public class ListaCompraModel : PageModel {
        private readonly AppDbContext _context;

        public ListaCompraModel (AppDbContext context) {
            _context = context;
        }

        [BindProperty]
        public Compra Compra { get; set; }
        [BindProperty]

        public Proveedor Proveedor { get; set; }
        public IList<Compra> Compras {get;set;}
        public IList<InformeCompra> Informes{get;set;}
        public IList<Detallecompra> Detalles {get;set;}

       
        public async Task OnGet() {
            Informes = _context.InformeCompra.FromSql(InformeCompra.query()).ToList();
            
        }
        public IActionResult OnGetCompra(int? IdCompra ) {
            Compra = _context.Compras
            .Include( c=> c.IdProveedorNavigation)
            .Where(c => c.Id == IdCompra).FirstOrDefault();
            Detalles = _context.Detallecompra
            .Where(d => d.IdCompra == IdCompra)
            .Include(x => x.IdProductoNavigation)
            .ToList();
            return Partial("_DetalleCompraPartial", this);
        }
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
    }
}

/*

var result = _context.Detallecompra
            .Include(dc=> dc.IdCompraNavigation)
             //   .ThenInclude(c => c.IdProveedorNavigation)
            .GroupBy(x => x.IdCompraNavigation)
            .Select(g => new {
                Compra = g.Key, 
                Cantidad = g.Count(),
            })
            .ToList();
            
*/
/*
var query = from detalle in _context.Set<Detallecompra>()
            join compra in _context.Set<Compra>()
            on detalle.IdCompra equals compra.Id
            join proveedor in _context.Set<Proveedor>()
            on compra.IdProveedor
            equals proveedor.Id
            group compra by new {
                prov = proveedor.Nombre, 
                cantidad = detalle.Cantidad,
                Fecha = compra.Fecha
            } into g
            select new {
                g.Key,
            }
            ;
        var result = query.ToList();
*/
 
 /*Compras = await _context.Compras
            .Include(c => c.IdProveedorNavigation)
            .Include(c => c.Detallecompra)
            .Include(c => c.Documento)
            .ThenInclude(d => d.IdRutaNavigation)
            .OrderByDescending(x => x.Fecha)
            .ToListAsync();
            */