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
    public class LoginWithCodeModel : PageModel
    {
        public string Mensaje { get; set; }
        private readonly AppDbContext _context;
        public LoginWithCodeModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost(string codigo)
        {
            string email = HttpContext.Session.GetString("email");
            if (email == null)
            {
                return RedirectToPage("/Welcome/ForgetPassword");
            }
            if (codigo == null)
            {
                Mensaje = "Debe proporcionar un código de recuperación de cuenta";
                return Page();
            }
            DateTime fechaActual = DateTime.Now;

            Recuperacioncuenta rec = _context.Recuperacioncuenta
               .Include(r => r.IdUsuarioNavigation)
               .Where(
                   //el codigo de recuperacion aun es valido
                   r => r.Estado == 1
                   //y no ha caducado por exceso de tiempo de espera (1 hora)
                   && r.FechaEnvio.AddMinutes(60) > fechaActual
                   //la fecha de caducidad 
                   && r.FechaRecuperacion == null
                   && r.IdUsuarioNavigation.Correo == email
               ).Last();
            if(rec==null) {
                Mensaje = "Esta cuenta no tiene asignado códigos de recuperación";
                return Page();
            }
            if (rec.Codigo == codigo)
            {
                rec.Estado = 0;
                rec.FechaRecuperacion = DateTime.Now;
                _context.SaveChanges();
                HttpContext.Session.SetInt32("IdUsuarioTemporal", rec.IdUsuario);
                return RedirectToPage("/Welcome/ChangePassword");
            }
            else
            {
                Mensaje = "El código ingresado no coincide con el código enviado a su correo";
                return Page();
            }
        }
    }
}