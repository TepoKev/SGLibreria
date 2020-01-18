using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Reportes
{
    public class ReporteVentasModel : PageModel
    {
        private readonly AppDbContext _context;
        public ReporteVentasModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            // return View(await _context.Customers.ToListAsync());
            //return new ViewAsPdf("ReporteVentas", await ReporteVentaMes());
            return Page();
        }

        public async Task<List<ProductoT>> ReporteVentaMes(){
            DateTime mes = DateTime.Now.Date;
            IList<Venta> ventas = await this._context.Ventas
            .Where(v => v.Fecha.Date.CompareTo(mes) == 0 )
            .Include(v => v.Detalleventa).ThenInclude(dtv => dtv.IdPrecioVentaNavigation).ThenInclude(pv => pv.IdProductoNavigation).ThenInclude(p => p.Ofertaproducto).ThenInclude(ofp => ofp.IdOfertaNavigation)
            .ToListAsync();
            List<Conjunto> Conjuntos = new List<Conjunto>();
            Conjunto Conjunto;
            foreach(var venta in ventas){
                foreach (var detalleventa in venta.Detalleventa)
                {
                    Conjunto = new Conjunto();
                    Conjunto.Producto = detalleventa.IdPrecioVentaNavigation.IdProductoNavigation;
                    Conjunto.Detalleventa = detalleventa;
                    foreach (var ofertaproducto in detalleventa.IdPrecioVentaNavigation.IdProductoNavigation.Ofertaproducto)
                    {
                        if(ofertaproducto.IdOfertaNavigation.FechaInicio.CompareTo(mes) >= 0){
                            Conjunto.Ofertaproducto = ofertaproducto;
                        }
                    }
                    Conjuntos.Add(Conjunto);
                }
            }
            List<ProductoT> productosT = new List<ProductoT>();
            ProductoT productoT ;
            foreach (var conjunto in Conjuntos)
            {
                if(productosT.Exists(p => p.Producto.Id == conjunto.Producto.Id)){
                    var aux = productosT.Find(p => p.Producto.Id == conjunto.Producto.Id);
                    productosT.Remove(aux);
                    aux.Cantidad = aux.Cantidad;
                    aux.PrecioUnitario = conjunto.Detalleventa.IdPrecioVentaNavigation.Valor;
                    aux.Total = aux.Total + (aux.PrecioUnitario * aux.Cantidad);
                    if(conjunto.Ofertaproducto != null){
                        aux.TotalDesc = aux.TotalDesc + aux.PrecioUnitario * ((Decimal)conjunto.Ofertaproducto.IdOfertaNavigation.Descuento * (Decimal) 0.01);
                    }
                    productosT.Add(aux);
                }else{
                    productoT = new ProductoT();
                    productoT.Producto = conjunto.Producto;
                    productoT.Venta = conjunto.Detalleventa.IdVentaNavigation;
                    productoT.Cantidad = conjunto.Detalleventa.Cantidad;
                    productoT.PrecioUnitario = conjunto.Detalleventa.IdPrecioVentaNavigation.Valor;
                    productoT.Total = productoT.Cantidad * productoT.PrecioUnitario;
                    if(conjunto.Ofertaproducto != null){
                        productoT.TotalDesc = productoT.PrecioUnitario * ((Decimal)conjunto.Ofertaproducto.IdOfertaNavigation.Descuento * (Decimal) 0.01);
                    }
                    productosT.Add(productoT);
                }
            }
            return productosT;
        }
    }
    public class Conjunto{
        public Producto Producto { get; set; }
        public Detalleventa Detalleventa { get; set; }
        public Ofertaproducto Ofertaproducto { get; set; }
        public Conjunto(){

        }
    }
    public class ProductoT{
        public Producto Producto { get; set; }
        public Venta Venta { get; set; }
        public int Cantidad { get; set; }
        public Decimal PrecioUnitario { get; set; }
        public Decimal Total { get; set; }
        public Decimal TotalDesc { get; set; }
        public ProductoT(){
            this.Cantidad = 0;
            this.PrecioUnitario = 0;
            this.Total = 0;
            this.TotalDesc = 0;
        }
    }
}