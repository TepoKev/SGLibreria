using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Welcome
{
    public class ChangePasswordModel : PageModel
    {
        public string Mensaje { get; set; }
        [BindProperty]
        public string Clave { get; set; }
        [BindProperty]
        public string ReClave { get; set; }
        private readonly AppDbContext _context;
        public ChangePasswordModel(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            int? IdUsuarioTemporal = HttpContext.Session.GetInt32("IdUsuarioTemporal");
            if (IdUsuarioTemporal == null)
            {
                return RedirectToPage("Welcome/Login");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            int? IdUsuarioTemporal = HttpContext.Session.GetInt32("IdUsuarioTemporal");
            if (IdUsuarioTemporal == null)
            {

                return RedirectToPage("Welcome/Login");
            }

            if (Clave == null || ReClave == null)
            {
                Mensaje = "Complete los campos";
                return Page();//
            }
            else if (Clave != ReClave)
            {
                Mensaje = "Las contraseñas no coinciden";
                return Page();
            }
            else
            {

                Usuario Usuario = _context.Usuarios
                .Where(us =>
                    us.Id == IdUsuarioTemporal.Value
                )
                .Include(us => us.IdImagenNavigation)
                .ThenInclude(Img => Img.IdRutaNavigation)
                .Include(us => us.Empleado)
                .ThenInclude(e => e.IdPersonaNavigation)
                .SingleOrDefault();
                
               if (Usuario == null)
                {
                    Mensaje = "Su usuario no existe";
                    return Page();
                }
                if (Usuario != null && Usuario.Estado == 0)
                {
                    Mensaje = "¡Acceso denegado. Lo sentimos!";
                    return Page();
                }
                //proceder a cambiar contraseña
                Usuario.Clave = Encrypted.Encrypt(this.Clave);
                _context.Usuarios.Attach(Usuario);
                _context.Entry(Usuario).Property(r => r.Clave).IsModified = true;
                _context.SaveChanges(); 

                Persona per = Usuario.Empleado.IdPersonaNavigation;
                string NombreCompleto = per.NombreCompleto();
                string ruta = "";
                Imagen Imagen = Usuario.IdImagenNavigation;
                if (Imagen != null)
                {
                    ruta = Imagen.IdRutaNavigation.Nombre + "/"
                        + Imagen.Nombre;
                }
                HttpContext.Session.Clear();
                HttpContext.Session.SetInt32("IdUsuario", Usuario.Id);
                HttpContext.Session.SetInt32("Privilegio", Usuario.Privilegio);
                HttpContext.Session.SetString("NombreCompleto", NombreCompleto);
                HttpContext.Session.SetString("Ruta", ruta);
                return RedirectToPage("/Index");
            }

        }
        public IActionResult OnPostCancelProcess()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Welcome/Login");
        }
    }
}