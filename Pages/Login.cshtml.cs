using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;

namespace SGLibreria.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; }
        public string Mensaje {get;set;}
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
            if(Logout == true) {
                Session.Clear();
                return Page();
            }
            Usuario u = await _context.Usuarios
            .Where( us => 
                us.Nombre == Usuario.Correo
                || us.Correo == Usuario.Correo
            )
            .Include(us => us.IdImagenNavigation)
            .ThenInclude(Img => Img.IdRutaNavigation)
            .Include(us=> us.Empleado)
            .ThenInclude(e => e.IdPersonaNavigation)
            .SingleOrDefaultAsync();
            if(u==null) {
                Mensaje = "Su usuario no existe";
                return Page();
            }
            if(u!=null && u.Estado==0) {
                Mensaje = "¡Acceso denegado. Lo sentimos!";
                return Page();
            }
            Persona per = u.Empleado.IdPersonaNavigation;
            string NombreCompleto = per.NombreCompleto();
            string ruta = "";
            Imagen Imagen = u.IdImagenNavigation;
            if(Imagen!=null) {
                ruta = Imagen.IdRutaNavigation.Nombre+"/"
                    +Imagen.Nombre;
            }
            Session.SetInt32("IdUsuario", u.Id);
            Session.SetInt32("Privilegio", u.Privilegio);
            Session.SetString("NombreCompleto",NombreCompleto);
            Session.SetString("Ruta", ruta);
            return RedirectToPage("/Index");
        }
    }
}