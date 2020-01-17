using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;
using MySql.Data.MySqlClient;
using SGLibreria.Informes;
using Microsoft.AspNetCore.Http;

namespace SGLibreria.Pages.Compras {
    public class ListaCompraModel : PageModel {
        private readonly AppDbContext _context;

        public ListaCompraModel (AppDbContext context) {
            this.Pagina = 0;
            this.CantidadPorFila = 1;
            this.Maximo = this.CantidadPorFila * 2;
            _context = context;
        }

        [BindProperty]
        public Compra Compra { get; set; }
        [BindProperty]

        public Proveedor Proveedor { get; set; }
        public IList<Compra> Compras {get;set;}
        public IList<InformeCompra> Informes{get;set;}
        public IList<Detallecompra> Detalles {get;set;}

        public int Pagina {get;set;}
        public int CantidadPorFila {get;set;}
        public int Maximo {get;set;}
        public int Total{get;set;}
       
        public async Task OnGet() {
            Informes = await _context.InformeCompra.FromSql(InformeCompra.query()).ToListAsync();
        }
        public PartialViewResult OnGetCompra(int? IdCompra) {
            
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
            Accion Accion = new Accion();
            Accion.IdBitacora = HttpContext.Session.GetInt32("IdBitacora").Value;
            Accion.Hora = DateTime.Now;
            Accion.Descripcion = "modificó datos de un proveedor";
            this._context.Add(Accion);
            this._context.SaveChanges();
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