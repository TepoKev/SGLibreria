using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Ventas
{
    public class ListaVentaModel: PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public List<Venta> Ventas {get;set;}
        [BindProperty]
        public Venta Venta { get; set; }
        [BindProperty]
        public List<ProductoT> productosT { get; set; }
        public ListaVentaModel(AppDbContext context) {
            _context = context;
        }
        public async Task<IActionResult> OnGet() {
            this.Ventas = await this._context.Ventas
                .Include(v => v.Detalleventa)
                .ThenInclude(dtv => dtv.IdPrecioVentaNavigation)
                .ThenInclude(dtv => dtv.IdProductoNavigation)
                .Include(v => v.Detalleservicio)
                .ThenInclude(dts => dts.IdTipoServicioNavigation)
                .ThenInclude(tps => tps.IdServicioNavigation)
                .Include(v => v.IdUsuarioNavigation)
                .ThenInclude(u => u.Empleado)
                .ThenInclude(e => e.IdPersonaNavigation).ToListAsync();
            return Page();
        }
        public async Task<PartialViewResult> OnPostDetalle(int idVenta){
            this.Venta = await this._context.Ventas.Where(v => v.Id == idVenta)
                .Include(v => v.Detalleventa)
                    .ThenInclude(dtv => dtv.IdPrecioVentaNavigation)
                    .ThenInclude(dtv => dtv.IdProductoNavigation)
                .Include(v => v.Detalleservicio)
                    .ThenInclude(dts => dts.IdTipoServicioNavigation)
                        .ThenInclude(tps => tps.IdServicioNavigation)
                .Include(v => v.IdUsuarioNavigation)
                    .ThenInclude(u => u.Empleado)
                    .ThenInclude(e => e.IdPersonaNavigation).FirstOrDefaultAsync();
            foreach (var item in this.Venta.Detalleservicio)
            {
                item.IdTipoServicioNavigation.IdCompaniaNavigation = await this._context.Companias.Where(c => c.Id == item.IdTipoServicioNavigation.IdCompania).FirstOrDefaultAsync();
            }
            return Partial("_DetalleVentaPartial", this);
        }

        public PartialViewResult OnPostReporteVentaMes(){
            DateTime mes = DateTime.Now.Date;
            IList<Venta> ventas = this._context.Ventas
            .Where(v => v.Fecha.Date.CompareTo(mes) == 0 )
            .Include(v => v.Detalleventa).ThenInclude(dtv => dtv.IdPrecioVentaNavigation).ThenInclude(pv => pv.IdProductoNavigation).ThenInclude(p => p.Ofertaproducto).ThenInclude(ofp => ofp.IdOfertaNavigation)
            .ToList();
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
            productosT = new List<ProductoT>();
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
            return Partial("_ReporteVentaPartial", this);
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