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
    public class ListaEmpleadoModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public List<Empleado> Empleados {get;set;}
        [BindProperty]
        public Empleado Empleado {get;set;}
        public ListaEmpleadoModel(AppDbContext context)
        {
            this._context = context;
        }
        public async Task OnGet()
        {
            this.Empleados = await this._context.Empleados
            .Include(x => x.IdPersonaNavigation)
            .Include(x => x.IdUsuarioNavigation).ToListAsync();
        }
        public async Task<PartialViewResult> OnPostEmpleadoView(int IdEmpleado)
        {
            this.Empleado = await this._context.Empleados
            .Include(x => x.IdPersonaNavigation)
            .Include(x => x.IdUsuarioNavigation)
            .ThenInclude(u => u.IdImagenNavigation)
            .ThenInclude(i => i.IdRutaNavigation).FirstOrDefaultAsync(x => x.Id == IdEmpleado);
            return Partial("_EmpleadoPartial", this);
        }
        public async Task<IActionResult> OnPostEstado(int IdUsuario, int Estado)
        {
            if(!UsuarioExists(IdUsuario)){
                return NotFound();
            }
            var user = await this._context.Usuarios.FirstOrDefaultAsync(x => x.Id == IdUsuario);
            user.Estado = (sbyte) Estado;
            this._context.Attach(user).State = EntityState.Modified;
            try
            {
                await this._context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine("Mensaje ="+e.Message);
                throw;
            }
            return Page();
        }
        public async Task<JsonResult> OnPostEditEmpleado()
        {
            this._context.Attach(this.Empleado).State = EntityState.Modified;
            this._context.Attach(this.Empleado.IdPersonaNavigation).State = EntityState.Modified;
            this._context.Entry(this.Empleado.IdUsuarioNavigation).Property("Nombre").IsModified = true;
            this._context.Entry(this.Empleado.IdUsuarioNavigation).Property("Correo").IsModified = true;
            try
            {
                await this._context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine("Mensaje ="+e.Message);
                throw;
            }
            return new JsonResult(new {Nombre=(this.Empleado.IdPersonaNavigation.Nombres+" "+this.Empleado.IdPersonaNavigation.Apellidos), Telefono = this.Empleado.IdPersonaNavigation.Telefono, Privilegio = this.Empleado.IdUsuarioNavigation.Privilegio, Genero = this.Empleado.IdPersonaNavigation.Genero});
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(u => u.Id == id);
        }
        public async Task<PartialViewResult> OnGetEmpleadoSelectAsync() {
            this.Empleados = await this._context.
            Empleados
            .Include(e => e.IdPersonaNavigation)
            .ToListAsync();
            return Partial("/Pages/Shared/OthersPartials/_EmpleadoSelectPartial.cshtml", this);
        }
    }
}