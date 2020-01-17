using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;

namespace SGLibreria.Pages.Welcome
{
    public class LogoutModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; }
        public string Mensaje { get; set; }
        private readonly AppDbContext _context;

        public LogoutModel(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            Logout();
            return RedirectToPage("/Welcome/Login");
        }
        public IActionResult OnPost()
        {
            Logout();
            return RedirectToPage("/Welcome/Login");
        }
        public void Logout()
        {
            Bitacora bitacora = this._context.Bitacoras.FirstOrDefault(b => b.Id == HttpContext.Session.GetInt32("IdBitacora"));
            if (bitacora != null)
            {
                bitacora.CierreSesion = DateTime.Now;
                this._context.Entry(bitacora).Property(b => b.CierreSesion).IsModified = true;
                try
                {
                    this._context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    Console.WriteLine("Mensaje =" + e.Message);
                    throw;
                }
            }
            HttpContext.Session.Clear();
        }
    }
}