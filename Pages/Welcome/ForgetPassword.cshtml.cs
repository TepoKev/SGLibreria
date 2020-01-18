using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Utils;
using System.Linq;
using System;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;

namespace SGLibreria.Pages.Welcome
{
    public class ForgetPasswordModel : PageModel
    {
        [BindProperty]
        public string email { get; set; }
        public string Mensaje { get; set; }
        private readonly AppDbContext _context;
        public ForgetPasswordModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (email == null)
            {
                Mensaje = "Debe ingresar un email para poder enviar su código de recuperación";
                return Page();
            }
            Usuario Usuario = _context.Usuarios
            .Include(u => u.Empleado)
            .ThenInclude(e => e.IdPersonaNavigation)
            .Where(u => u.Correo == email)
            .FirstOrDefault();
            if (Usuario == null)
            {
                Mensaje = "El correo proporcionado no está vinculado a ninguna cuenta";
                return Page();
            }
            HttpContext.Session.SetString("email", Usuario.Correo);
            string sql = "UPDATE recuperacioncuenta r set r.Estado = @Estado Where IdUsuario = @IdUsuario ";
            var EstadoParam = new MySqlParameter("@Estado", "1");
            var IdUsuarioParam = new MySqlParameter("@IdUsuario", Usuario.Id);
            _context.Database.ExecuteSqlCommand(sql, EstadoParam, IdUsuarioParam);
            
            string recoveryCode = Encrypted.CreatePassword(8);
            Recuperacioncuenta rec = new Recuperacioncuenta
            {
                IdUsuario = Usuario.Id,
                //all codes generated will be 8 characteres
                Codigo = recoveryCode, 
                FechaEnvio = DateTime.Now,
                //mark as enabled for use
                Estado = 1, 
                FechaRecuperacion = null
            };
            _context.Recuperacioncuenta.Add(rec);
            SendCodeForEmail(email, recoveryCode, Usuario);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Welcome/LoginWithCode");
        }
        public void SendCodeForEmail(string email, string code, Usuario usuario) {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("SistemGLibreria@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Recuperación de contraseña de SGLibreria.";
                mail.Body = "<p style='font-size:16px'> Hola "+usuario.Empleado.IdPersonaNavigation.NombreCompleto()+", este es tu codigo de verificación para recuperar tu contraseña: <strong>"+code+"</strong></p>";
                mail.IsBodyHtml = true;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("SistemGLibreria@gmail.com", "sistemagestionlibreria");
                SmtpServer.EnableSsl = true;
                SmtpServer.Host = "smtp.gmail.com";

                SmtpServer.Send(mail);
                //MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                
                //MessageBox.Show(ex.ToString());
            }
        }
    }
}