using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Net.Mail;

namespace SGLibreria.Pages.Welcome
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; }
        public string Mensaje { get; set; }
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(Boolean Logout)
        {
            var Session = HttpContext.Session;
            if (Logout == true || Usuario.Correo == null)
            {
                Session.Clear();
                return Page();
            }
            if(Usuario.Correo == null || Usuario.Clave==null) {
                Mensaje = "Complete los campos!";
                return Page();
            }else{
                var user = await _context.Usuarios.AnyAsync(uc => uc.Correo == this.Usuario.Correo);
                var clave = await _context.Usuarios.AnyAsync(uc => uc.Clave == Encrypted.Encrypt(this.Usuario.Clave));
                Usuario u = await _context.Usuarios
                .Where(us =>
                us.Nombre == Usuario.Correo
                || us.Correo == Usuario.Correo
                )
                .Include(us => us.IdImagenNavigation)
                .ThenInclude(Img => Img.IdRutaNavigation)
                .Include(us => us.Empleado)
                .ThenInclude(e => e.IdPersonaNavigation)
                .SingleOrDefaultAsync();
                if (u == null)
                {
                    Mensaje = "Su usuario no existe";
                    return Page();
                }
                if (u != null && u.Estado == 0)
                {
                    Mensaje = "¡Acceso denegado. Lo sentimos!";
                    return Page();
                }
                if(!clave){
                    Mensaje = "Contraseña incorrecta!.";
                    return Page();
                }
                if(u!=null && u.Estado == 1 && user && clave){
                    
                
                    Persona per = u.Empleado.IdPersonaNavigation;
                    string NombreCompleto = per.NombreCompleto();
                    string ruta = "";
                    Imagen Imagen = u.IdImagenNavigation;
                    if (Imagen != null)
                    {
                        ruta = Imagen.IdRutaNavigation.Nombre + "/"
                            + Imagen.Nombre;
                    }
                    Bitacora Bitacora = new Bitacora();
                    Bitacora.IdUsuario = u.Id;
                    Bitacora.InicioSesion = DateTime.Now;
                    this._context.Bitacoras.Add(Bitacora);
                    this._context.SaveChanges();
                    Session.SetInt32("IdUsuario", u.Id);
                    Session.SetInt32("IdBitacora", Bitacora.Id);
                    Session.SetInt32("Privilegio", u.Privilegio);
                    Session.SetString("NombreCompleto", NombreCompleto);
                    Session.SetString("Ruta", ruta);
                }
            }
            
            
            return RedirectToPage("/Index");
        }

        public void sendEmailTo()
        {
            
        }
    }
}