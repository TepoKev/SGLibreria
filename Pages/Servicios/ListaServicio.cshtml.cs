using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Servicios
{
    public class ListaServicioModel : PageModel
    {
        public List<Servicio> Servicios { get; set; }
        public List<Compania> Companias { get; set; }
        private readonly AppDbContext _context;
        [BindProperty]
        public Tiposervicio Tiposervicio { get; set; }
        [BindProperty]
        public IFormFile Archivo { get; set; }
        public string Mensaje {get;set;}
        //[BindProperty]
        //public IList<Servicio> Servicios { get; set; }
        public void OnGet()
        {
            Servicios = _context.Servicios.ToList();
            Companias = _context.Companias.ToList();
        }
        public ListaServicioModel(AppDbContext context)
        {
            _context = context;
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
        public async Task<IActionResult> OnPostAgregarTiposervicioModificado(){
            
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
            _context.Imagenes.Attach(Imagen);
            await this._context.SaveChangesAsync();
            this.Tiposervicio.IdImagen = Imagen.Id;
            //_context.Entry(Tiposervicio).State = EntityState.Modified;
            _context.Tiposervicio.Attach(Tiposervicio);
            _context.Entry(Tiposervicio).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
            return Page();
        }
        public JsonResult OnPostTipoServicio(int? IdTiposervicio)
        {
          JsonResult json;
            Tiposervicio prod = _context.Tiposervicio
            .Include( p => p.IdImagenNavigation)

            .ThenInclude( i => i.IdRutaNavigation)

            .Where(p => p.Id == IdTiposervicio).SingleOrDefault();
            json = new JsonResult(prod);
            //json.StatusCode = 200;
            return json;
        }

        public JsonResult OnPostServicios()
        {
            IList<Tiposervicio> Tiposervicios = _context.Tiposervicio.ToList();
            return new JsonResult(Tiposervicios);
        }
        public JsonResult OnPostServiciosCompania()
        {
            IList<Servicio> Servicios = _context.Servicios.ToList();
            IList<Compania> Companias = _context.Companias.ToList();
            var resultado = new
            {
                servicios = Servicios,
                companias = Companias
            };
            return new JsonResult(resultado);
        }
        public JsonResult OnPostCompanias()
        {
            IList<Compania> Companias = _context.Companias.ToList();
            return new JsonResult(Companias);
        }
    }
}