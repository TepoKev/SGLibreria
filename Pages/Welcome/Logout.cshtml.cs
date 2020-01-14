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
        public void Logout() {
            HttpContext.Session.Clear();
        }
    }
}