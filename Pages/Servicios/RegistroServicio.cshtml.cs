using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Servicios
{
    public class RegistroServicioModel : PageModel
    {
        private readonly AppDbContext _context;
        public RegistroServicioModel(AppDbContext context)
        {
            _context = context;
        }

        //[BindProperty]
        public Servicio Servicio { get; set; }
        //[BindProperty]
        public Compania Compania { get; set; }
        [BindProperty]
        public Tiposervicio Tiposervicio { get; set; }
        [BindProperty]
        public IFormFile Archivo { get; set; }
        public IList<Servicio> Servicios { get; set; }
        public IList<Compania> Companias { get; set; }
        public async Task<IActionResult> OnPostAgregarTiposervicio(){
            
            string Ruta = "Servicios";
            Imagen Imagen = new Imagen();
            if (Archivo != null)
            {
                //directorio de destino
                var filepath = "wwwroot/"+Ruta+"/";
                var filename = Archivo.FileName;
                //validar antes de subir
                var isValidName = ValidFileName(filepath, filename);
                //nombre valido y el Archivo no existe
                if (isValidName && !FileExists(filepath, filename) )
                {
                    await UploadFile(filepath, filename, Archivo);
                    Imagen.Nombre = filename;
                    Imagen.IdRuta = this._context.Rutas.Where(r => r.Nombre.Equals(Ruta)).FirstOrDefault().Id;
                }
            }//envio imagen
            await this._context.Imagenes.AddAsync(Imagen);
            await this._context.SaveChangesAsync();
            this.Tiposervicio.IdImagen = Imagen.Id;
            await this._context.Tiposervicio.AddAsync(Tiposervicio);
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

        public async Task<bool> UploadFile(string filepath, string filename, IFormFile Archivo) {
            filepath = filepath + filename;
            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                //copiar el Archivo al servidor
                await Archivo.CopyToAsync(fileStream);
            }
            return true;
        }
    
        public JsonResult OnGetListaServicio(){
            this.Servicios = _context.Servicios.ToList();
            return new JsonResult(this.Servicios);
        }

        public JsonResult OnGetListaCompania(){
            this.Companias = _context.Companias.ToList();
            return new JsonResult(this.Companias);
        }
        public async Task<IActionResult> OnPostAgregarServicio(Servicio Servicio)
        {
            Servicio.Estado = (sbyte)1;
            _context.Servicios.Add(Servicio);
            await _context.SaveChangesAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAgregarCompania(Compania Compania)
        {
            Compania.Estado = (sbyte)1;
            _context.Companias.Add(Compania);
            await _context.SaveChangesAsync();
            return Page();
        }
    }
}