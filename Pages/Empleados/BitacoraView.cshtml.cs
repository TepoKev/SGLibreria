using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Empleados
{
    public class BitacoraViewModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public IList<Bitacora> Bitacoras { get; set; }
        [BindProperty]
        public Empleado Empleado { get; set; }
        public BitacoraViewModel(AppDbContext context)
        {
            this._context = context;
        }
        public async Task OnGet(int? id)
        {
            this.Empleado = await this._context.Empleados.Where(e => e.Id == id).Include(e => e.IdPersonaNavigation).Include(e => e.IdUsuarioNavigation).FirstOrDefaultAsync();
            this.Bitacoras = await this._context.Bitacoras.Where(b => b.IdUsuario == this.Empleado.IdUsuarioNavigation.Id).Include(b => b.Accion).OrderByDescending(b => b.InicioSesion).ToListAsync();
        }

        public async Task<PartialViewResult> OnPost(){
            this.Bitacoras = await this._context.Bitacoras.Include(b => b.Accion).Include(b => b.IdUsuarioNavigation).ThenInclude(u => u.Empleado).ThenInclude( e => e.IdPersonaNavigation).OrderByDescending(b => b.InicioSesion).ToListAsync();
            return Partial("_BitacoraPartial", this);
        }

        public async Task<PartialViewResult> OnPostBitacora(int? IdUsuario){
            this.Bitacoras = await this._context.Bitacoras.Where(b => b.IdUsuario ==IdUsuario).Include(b => b.Accion).OrderByDescending(b => b.InicioSesion).ToListAsync();
            return Partial("_BitacoraPartialOne", this);
        }
        public async Task<PartialViewResult> OnPostBitacoraFechaAll(DateTime desde, DateTime hasta){
            this.Bitacoras = await this._context.Bitacoras.Where(b => b.CierreSesion.CompareTo(desde) >= 0 && b.CierreSesion.CompareTo(hasta) <= 0).Include(b => b.Accion).Include(b => b.IdUsuarioNavigation).ThenInclude(u => u.Empleado).ThenInclude( e => e.IdPersonaNavigation).OrderByDescending(b => b.InicioSesion).ToListAsync();
            return Partial("_BitacoraPartial", this);
        }
        public async Task<PartialViewResult> OnPostBitacoraFechaOne(DateTime desde, DateTime hasta, int? IdUsuario){
            this.Bitacoras = await this._context.Bitacoras.Where(b => b.IdUsuario == IdUsuario && b.CierreSesion.CompareTo(desde) >= 0 && b.CierreSesion.CompareTo(hasta) <= 0).Include(b => b.Accion).OrderByDescending(b => b.InicioSesion).ToListAsync();
            return Partial("_BitacoraPartialOne", this);
        }
    }
}