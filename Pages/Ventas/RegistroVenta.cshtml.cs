using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SGLibreria.Informes;
using SGLibreria.Models;

namespace SGLibreria.Pages.Ventas
{
    public class RegistroVentaModel : PageModel
    {
        public List<Categoria> Categorias { get; set; }
        [BindProperty]
        public Venta Venta { get; set; }
        private readonly AppDbContext _context;
        public RegistroVentaModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Categorias = _context.Categorias.ToList();
        }

        public async Task<IActionResult> OnPost(int[] IdProducto, int[] CantProducto, int[] IdServicio, int[] CantServicio)
        {
            Venta venta = new Venta();
            venta.IdUsuario = 15;
            venta.Fecha = DateTime.Now;
            await this._context.Ventas.AddAsync(venta);
            await this._context.SaveChangesAsync();
            //En el siguiente for se van a registrar los detalles de venta (Productos)
            int i;
            int len = IdProducto.Length;
            int pv;
            Precioventa precioventa;
            Detalleventa dtv = null;
            Detalleservicio dts = null;
            for(i = 0 ;i < len ; i++) {
                dtv = new Detalleventa();
                dtv.IdVenta = venta.Id;
                dtv.Cantidad = CantProducto[i];
                precioventa = this._context.Precioventa.Where(p => p.IdProducto == IdProducto[i]).OrderByDescending(p => p.Fecha).FirstOrDefault();
                dtv.IdPrecioVenta = precioventa.Id;
                dtv.IdPrecioVentaNavigation = precioventa;; 
                await this._context.Detalleventa.AddAsync(dtv);
                await this._context.SaveChangesAsync();

                int Existencia = 0;
                //traer la existencia del ultimo kardex 
                IList<ConsultaKardex> ck =  _context.ConsultaKardex.FromSql(ConsultaKardex.queryOne(), precioventa.IdProducto, precioventa.IdProducto).ToList();
                if(ck !=null && ck.Count>0) {
                    Existencia = ck.Last().Existencia;
                }
                Existencia += dtv.Cantidad;
                Kardex kardex = new Kardex {
                    Existencia = Existencia, 
                    IdDetalleVenta = dtv.Id, 
                    IdProducto = precioventa.IdProducto
                };
                _context.Kardex.Add(kardex);
                await _context.SaveChangesAsync();
            }
            len = IdServicio.Length;
            for(i = 0 ;i < len ; i++){
                dts = new Detalleservicio();
                dts.IdVenta = venta.Id;
                dts.Cantidad = CantServicio[i];
                dts.IdTipoServicio = IdServicio[i];
                await this._context.Detalleservicio.AddAsync(dts);
                await this._context.SaveChangesAsync();
            }
            return RedirectToPage("/Ventas/ListaVenta");
        }
    }
}