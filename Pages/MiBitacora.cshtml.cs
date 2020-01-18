using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages
{
    public class MiBitacoraModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public IList<Bitacora> Bitacoras { get; set; }

        public MiBitacoraModel(AppDbContext context){
            this._context = context;
        }
        public async Task OnGet(){
            int IdUsuario = HttpContext.Session.GetInt32("IdUsuario").Value;
            this.Bitacoras = await this._context.Bitacoras.Where(b => b.IdUsuario == IdUsuario).Include(b => b.Accion).OrderByDescending(b => b.InicioSesion).ToListAsync();
        }
        public async Task<PartialViewResult> OnPostBitacoraFechaOne(DateTime desde, DateTime hasta){
            int IdUsuario = HttpContext.Session.GetInt32("IdUsuario").Value;
            this.Bitacoras = await this._context.Bitacoras.Where(b => b.IdUsuario == IdUsuario && b.CierreSesion.CompareTo(desde) >= 0 && b.CierreSesion.CompareTo(hasta) <= 0).Include(b => b.Accion).OrderByDescending(b => b.InicioSesion).ToListAsync();
            return Partial("_MyBitacoraPartial", this);
        }
    }
}