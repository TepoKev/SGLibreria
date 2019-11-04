using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;
namespace SGLibreria.Pages.Empleados
{
    public class RegistroEmpleadoModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public Persona Persona { get; set; }
        [BindProperty]
        public Empleado Empleado { get; set; }
        [BindProperty]
        public Usuario Usuario { get; set; }
        [BindProperty]
        public IFormFile Archivo { get; set; }
        public RegistroEmpleadoModel(AppDbContext context)
        {
            this._context = context;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(){
            if(!ModelState.IsValid){
                return NotFound();
            }
            string Ruta = "Empleados";
            Imagen Imagen = new Imagen();
            if (Archivo != null)
            {
                //directorio de destino
                var filepath = "wwwroot/"+Ruta+"/";
                var filename = Archivo.FileName;
                //validar antes de subir
                var isValidName = ValidFileName(filepath, filename);
                //nombre valido y el archivo no existe
                if (isValidName && !FileExists(filepath, filename) )
                {
                    await UploadFile(filepath, filename, Archivo);
                    Imagen.Nombre = filename;
                    Imagen.IdRuta = this._context.Rutas.Where(r => r.Nombre.Equals(Ruta)).FirstOrDefault().Id;
                }
            }//envio imagen
            await this._context.Personas.AddAsync(this.Persona);
            await this._context.SaveChangesAsync();
            this.Usuario.Estado = (sbyte) 1;
            await this._context.Imagenes.AddAsync(Imagen);
            await this._context.SaveChangesAsync();
            this.Usuario.IdImagen = Imagen.Id;
            await this._context.Usuarios.AddAsync(this.Usuario);
            await this._context.SaveChangesAsync();
            this.Empleado.IdPersona = this.Persona.Id;
            this.Empleado.IdUsuario = this.Usuario.Id;
            await this._context.Empleados.AddAsync(this.Empleado);
            await this._context.SaveChangesAsync();
            return Page();
        }
        public bool ValidFileName(string filepath, string filename) {
            //validar antes de subir
            var isValidName = !string.IsNullOrEmpty(filename) &&
            filename.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
            return isValidName;
        }

        public bool FileExists(string filename, string filepath) {
            return System.IO.File.Exists(Path.Combine(filepath, filename));
        }

        public async Task<bool> UploadFile(string filepath, string filename, IFormFile archivo) {
            filepath = filepath + filename;
            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                //copiar el archivo al servidor
                await archivo.CopyToAsync(fileStream);
            }
            return true;
        }
    }
}