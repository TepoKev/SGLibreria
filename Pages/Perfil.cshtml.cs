using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace SGLibreria.Pages
{
    public class PerfilModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public Usuario Usuario { get; set; }
        public PerfilModel(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> OnGet(int? Id)
        {
            if(Id == null){
                return RedirectToPage("/Login");
            }
            this.Usuario = await this._context.Usuarios.Include(u => u.IdImagenNavigation).ThenInclude(i => i.IdRutaNavigation).Include(u => u.Empleado).ThenInclude(e => e.IdPersonaNavigation).FirstOrDefaultAsync(u => u.Id == Id);
            return Page();
        }

        public async Task<JsonResult> OnPostValidateUsername(string username, int idUsuario){
            if(username == null || username == ""){
                return new JsonResult("Existe");
            }
            int cant = await this._context.Usuarios.Where(u => u.Nombre == username && u.Id != idUsuario).CountAsync();
            if(cant > 0){
                return new JsonResult("Existe");
            }else{
                return new JsonResult("No Existe");
            }
        }
        public async Task<JsonResult> OnPostValidateCorreo(string correo, int idUsuario){
            if(correo == null || correo == ""){
                return new JsonResult("Existe");
            }
            int cant = await this._context.Usuarios.Where(u => u.Correo == correo && u.Id != idUsuario).CountAsync();
            if(cant > 0){
                return new JsonResult("Existe");
            }else{
                return new JsonResult("No Existe");
            }
        }
        public async Task<JsonResult> OnPostValidateTelefono(string telefono, int idPersona){
            if(telefono == null || telefono == ""){
                return new JsonResult("Existe");
            }
            int cant = await this._context.Personas.Where(p => p.Telefono == telefono && p.Id != idPersona).CountAsync();
            if(cant > 0){
                return new JsonResult("Existe");
            }else{
                return new JsonResult("No Existe");
            }
        }
        public async Task<JsonResult> OnPostValidateDui(string dui, int idEmpleado){
            if(dui == null || dui == ""){
                return new JsonResult("Existe");
            }
            int cant = await this._context.Empleados.Where(e => e.Dui == dui && e.Id != idEmpleado).CountAsync();
            if(cant > 0){
                return new JsonResult("Existe");
            }else{
                return new JsonResult("No Existe");
            }
        }
        public async Task<JsonResult> OnPostValidatePass(string password, int idUsuario){
            if(password == null || password == ""){
                return new JsonResult("Existe");
            }
            password = Encrypted.Encrypt(password);
            int cant = await this._context.Usuarios.Where(u => u.Clave == password && u.Id != idUsuario).CountAsync();
            if(cant > 0){
                return new JsonResult("Existe");
            }else{
                return new JsonResult("No Existe");
            }
        }
    }
}