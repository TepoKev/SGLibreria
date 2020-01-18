using System;
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
            
            Imagen Imagen = new Imagen();
            var temporal = await  _context.Tiposervicio.Select(
              p => new {
                p.Id, 
                p.IdImagen
              }
            ).Where( p => p.Id == Tiposervicio.Id).FirstOrDefaultAsync();
            
            if(temporal == null) {
              return new JsonResult(
                new {
                  Error = "No existe ningún objeto SERVICIO con el Identificador proporcionado"
                }
              );
            }
            //envio imagen
            if (Tiposervicio.Archivo != null)
            {
                string Ruta = "Servicios";
                //directorio de destino
                var filepath = "wwwroot/"+Ruta+"/";
                var filename = Tiposervicio.Archivo.FileName;
                //validar antes de subir
                var isValidName = ValidFileName(filepath, filename);
                //nombre valido y el archivo no existe
                if (isValidName && !FileExists(filepath, filename) )
                {
                    await UploadFile(filepath, filename, Tiposervicio.Archivo);             
                    Imagen.Nombre = filename;
                    //si el producto tiene una imagen, hay que actualizar el nombre de la imagen
                    if( temporal.IdImagen!=null ) {
                      Imagen.Id = temporal.IdImagen.Value;
                      _context.Attach(Imagen);
                      _context.Entry(Imagen).Property(i=> i.Nombre).IsModified = true;
                    } else {//si el producto no tiene imagen, hay que agregar un nuevo registro
                       Imagen.IdRuta = (await _context.Rutas.Where(r => EF.Functions.Like(r.Nombre, $"%{Ruta}%")).FirstOrDefaultAsync()).Id;
                      _context.Imagenes.Add(Imagen);
                    }
                    await _context.SaveChangesAsync();
                    Tiposervicio.IdImagen = Imagen.Id;
                    _context.Entry(Tiposervicio).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    Mensaje = "Se modifico correctamente";
                } else if (FileExists(filepath, filename))
                { //el ya archivo existe
                    
                    Mensaje = "La imagen: " + filename + " ya existe. por favor cambie el nombre del archivo que quiere subir e intentelo de nuevo";
                }
                else if (!isValidName)
                {
                    Mensaje = "El nombre de archivo: " + filename + " es incorrecto";
                }
                return new JsonResult(
                  new {
                    Mensaje
                  }
                );
            }else{
                Imagen.Id = temporal.IdImagen.Value;
                await _context.SaveChangesAsync();
                Tiposervicio.IdImagen = Imagen.Id;
            }

            _context.Tiposervicio.Attach(Tiposervicio);
            _context.Entry(Tiposervicio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            Accion Accion = new Accion();
            Accion.IdBitacora = HttpContext.Session.GetInt32("IdBitacora").Value;
            Accion.Hora = DateTime.Now;
            Accion.Descripcion = "modificó datos de un tipo de servicio";
            this._context.Add(Accion);
            this._context.SaveChanges();
            Mensaje = "Se ha modificado correctamente";
            return new JsonResult(
              new {
                Mensaje
              }
            );
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