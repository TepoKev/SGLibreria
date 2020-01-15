using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        [BindProperty]
        public Empleado Empleado { get; set; }
        [BindProperty]
        public Persona Persona { get; set; }
        [BindProperty]
        public Imagen Imagen { get; set; }
        [BindProperty]
        public Ruta Ruta { get; set; }

        [BindProperty]
        public string NewPass { get; set; }
        [BindProperty]
        public string Pass { get; set; }
        [BindProperty]
        public IFormFile Archivo { get; set; }
        public PerfilModel(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> OnGet(int? Id)
        {
            if (Id == null)
            {
                return RedirectToPage("/Login");
            }
            this.Usuario = await this._context.Usuarios.Include(u => u.IdImagenNavigation).ThenInclude(i => i.IdRutaNavigation).Include(u => u.Empleado).ThenInclude(e => e.IdPersonaNavigation).FirstOrDefaultAsync(u => u.Id == Id);
            this.Empleado = this.Usuario.Empleado;
            this.Persona = this.Empleado.IdPersonaNavigation;
            this.Imagen = this.Usuario.IdImagenNavigation;
            this.Ruta = this.Imagen.IdRutaNavigation;
            return Page();
        }

        public JsonResult OnPostValidateUsername(string username, int idUsuario)
        {
            if (UsernameExists(username, idUsuario))
            {
                return new JsonResult("Existe");
            }
            else
            {
                return new JsonResult("No Existe");
            }
        }
        public JsonResult OnPostValidateCorreo(string correo, int idUsuario)
        {
            if (CorreoExists(correo, idUsuario))
            {
                return new JsonResult("Existe");
            }
            else
            {
                return new JsonResult("No Existe");
            }
        }
        public JsonResult OnPostValidateTelefono(string telefono, int idPersona)
        {
            if (TelefonoExists(telefono, idPersona))
            {
                return new JsonResult("Existe");
            }
            else
            {
                return new JsonResult("No Existe");
            }
        }
        public JsonResult OnPostValidateDui(string dui, int idEmpleado)
        {
            if (DuiExists(dui, idEmpleado))
            {
                return new JsonResult("Existe");
            }
            else
            {
                return new JsonResult("No Existe");
            }
        }
        public JsonResult OnPostValidatePass(string password, int idUsuario)
        {
            if (PassExists(password, idUsuario))
            {
                return new JsonResult("Existe");
            }
            else
            {
                return new JsonResult("No Existe");
            }
        }
        public async Task<JsonResult> OnPostActualizar()
        {
            //Verificacion y actualizacion de datos de Imagen
            Imagen newImagen = null;
            bool cambios = false;
            if (this.Archivo != null)
            {
                newImagen = new Imagen();
                //directorio de destino
                var filepath = "wwwroot/Empleados/";
                var filename = Archivo.FileName;
                //validar antes de subir
                var isValidName = ValidFileName(filepath, filename);
                //nombre valido y el archivo no existe
                if (isValidName && !FileExists(filepath, filename))
                {
                    await UploadFile(filepath, filename, Archivo);
                    newImagen.Nombre = filename;
                    newImagen.IdRuta = 3;
                }
                this._context.Imagenes.Add(newImagen);
                this._context.SaveChanges();
            }//envio imagen
            //Verificacion y actualizacion de datos de Usuario
            if (newImagen == null)
            {
                this._context.Entry(Usuario).Property(u => u.IdImagen).IsModified = false;
            }
            else
            {
                this.Usuario.IdImagen = newImagen.Id;
                this._context.Entry(Usuario).Property(u => u.IdImagen).IsModified = true;
                this.HttpContext.Session.SetString("Ruta","Empleados/"+newImagen.Nombre);
                cambios = true;
            }
            if (this.Usuario.Nombre == "" || this.Usuario.Nombre == null || _context.Usuarios.Any(u => u.Nombre == this.Usuario.Nombre))
            {
                this._context.Entry(Usuario).Property(u => u.Nombre).IsModified = false;
            }
            else
            {
                this._context.Entry(Usuario).Property(u => u.Nombre).IsModified = true;
                cambios = true;
            }
            if (_context.Usuarios.Any(u => u.Correo == this.Usuario.Correo))
            {
                this._context.Entry(Usuario).Property(u => u.Correo).IsModified = false;
            }
            else
            {
                this._context.Entry(Usuario).Property(u => u.Correo).IsModified = true;
                cambios = true;
            }
            if (!PassExists(this.Pass, this.Usuario.Id) || this.NewPass == "" || this.NewPass == null || this.Pass == "" || this.Pass == null)
            {
                this._context.Entry(Usuario).Property(u => u.Clave).IsModified = false;
            }
            else
            {
                this.NewPass = Encrypted.Encrypt(this.NewPass);
                this.Usuario.Clave = this.NewPass;
                this._context.Entry(Usuario).Property(u => u.Clave).IsModified = true;
                cambios = true;
            }
            //Verificacion y actualizacion de datos de Empleado
            this._context.Entry(Empleado).Property(e => e.FechaIngreso).IsModified = false;
            if (this.Empleado.Dui == "" || this.Empleado.Dui == null || _context.Empleados.Any(u => u.Dui == this.Empleado.Dui))
            {
                this._context.Entry(Empleado).Property(e => e.Dui).IsModified = false;
            }
            else
            {
                this._context.Entry(Empleado).Property(e => e.Dui).IsModified = true;
                cambios = true;
            }
            if (Empleado.FechaNacimiento == null || Empleado.FechaNacimiento == null || _context.Empleados.Any(e => e.FechaNacimiento == this.Empleado.FechaNacimiento && e.Id == this.Empleado.Id))
            {
                this._context.Entry(Empleado).Property(e => e.FechaNacimiento).IsModified = false;
            }
            else
            {

                this._context.Entry(Empleado).Property(e => e.FechaNacimiento).IsModified = true;
                cambios = true;
            }
            //Verificacion y actualizacion de datos de Persona
            if (this.Persona.Telefono == "" || this.Persona.Telefono == null || _context.Personas.Any(p => p.Telefono == this.Persona.Telefono))
            {
                this._context.Entry(Persona).Property(p => p.Telefono).IsModified = false;
            }
            else
            {
                this._context.Entry(Persona).Property(p => p.Telefono).IsModified = true;
                cambios = true;
            }
            if (Persona.Nombres == "" || Persona.Nombres == null || _context.Personas.Any(p => p.Nombres == this.Persona.Nombres && p.Id == this.Persona.Id))
            {
                this._context.Entry(Persona).Property(p => p.Nombres).IsModified = false;
            }
            else
            {
                this._context.Entry(Persona).Property(p => p.Nombres).IsModified = true;
                this.HttpContext.Session.SetString("NombreCompleto",(this.Persona.Nombres+" "+this.Persona.Apellidos));
                cambios = true;
            }
            if (Persona.Apellidos == "" || Persona.Apellidos == null || _context.Personas.Any(p => p.Apellidos == this.Persona.Apellidos && p.Id == this.Persona.Id))
            {
                this._context.Entry(Persona).Property(p => p.Apellidos).IsModified = false;
            }
            else
            {
                this._context.Entry(Persona).Property(p => p.Apellidos).IsModified = true;
                this.HttpContext.Session.SetString("NombreCompleto",(this.Persona.Nombres+" "+this.Persona.Apellidos));
                cambios = true;
            }
            if (Persona.Genero > 1 || Persona.Genero < 0 || _context.Personas.Any(p => p.Genero == this.Persona.Genero && p.Id == this.Persona.Id))
            {
                this._context.Entry(Persona).Property(p => p.Genero).IsModified = false;
            }
            else
            {
                this._context.Entry(Persona).Property(p => p.Genero).IsModified = true;
                cambios = true;
            }
            if (_context.Personas.Any(p => p.Direccion == this.Persona.Direccion && p.Id == this.Persona.Id))
            {
                this._context.Entry(Persona).Property(p => p.Direccion).IsModified = false;
            }
            else
            {
                this._context.Entry(Persona).Property(p => p.Direccion).IsModified = true;
                cambios = true;
            }
            try
            {
                await this._context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine("Mensaje =" + e.Message);
                throw;
            }
            if (cambios == true)
            {
                return new JsonResult("Cambios");
            }
            else
            {
                return new JsonResult("No Cambios");
            }
        }
        public bool ValidFileName(string filepath, string filename)
        {
            //validar antes de subir
            var isValidName = !string.IsNullOrEmpty(filename) &&
            filename.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
            return isValidName;
        }

        public bool FileExists(string filename, string filepath)
        {
            return System.IO.File.Exists(Path.Combine(filepath, filename));
        }
        private bool UsernameExists(string username, int idUsuario)
        {
            if (username == "" || username == null)
            {
                return false;
            }
            return _context.Usuarios.Any(u => u.Nombre == username && u.Id != idUsuario);
        }
        public async Task<bool> UploadFile(string filepath, string filename, IFormFile archivo)
        {
            filepath = filepath + filename;
            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                //copiar el archivo al servidor
                await archivo.CopyToAsync(fileStream);
            }
            return true;
        }
        private bool CorreoExists(string correo, int idUsuario)
        {
            if (correo == "" || correo == null)
            {
                return false;
            }
            return _context.Usuarios.Any(u => u.Correo == correo && u.Id != idUsuario);
        }
        private bool TelefonoExists(string telefono, int idPersona)
        {
            if (telefono == "" || telefono == null)
            {
                return false;
            }
            return _context.Personas.Any(p => p.Telefono == telefono && p.Id != idPersona);
        }
        private bool DuiExists(string dui, int idEmpleado)
        {
            if (dui == "" || dui == null)
            {
                return false;
            }
            return _context.Empleados.Any(e => e.Dui == dui && e.Id != idEmpleado);
        }
        private bool PassExists(string password, int idUsuario)
        {
            if (password == "" || password == null)
            {
                return false;
            }
            password = Encrypted.Encrypt(password);
            return _context.Usuarios.Any(u => u.Clave == password && u.Id == idUsuario);
        }
    }
}