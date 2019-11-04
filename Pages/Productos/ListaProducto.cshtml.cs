using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;
using Microsoft.AspNetCore.Http;

namespace SGLibreria.Pages.Productos
{

    public class ListaProductoModel : PageModel
    {

        public List<Categoria> Categorias { get; set; }
        private readonly AppDbContext _context;
        [BindProperty]
        public Producto Producto { get; set; }
        public string Mensaje {get;set;}

        public ListaProductoModel(AppDbContext context)
        {
            _context = context;
        }
        public JsonResult OnPostProducto(int? IdProducto)
        {
          JsonResult json;
            Producto prod = _context.Productos
            .Include( p => p.IdImagenNavigation)

            .ThenInclude( i => i.IdRutaNavigation)

            .Where(p => p.Id == IdProducto).SingleOrDefault();
            json = new JsonResult(prod);
            //json.StatusCode = 200;
            return json;
        }
        public JsonResult OnPostCategorias()
        {
            IList<Categoria> Categorias = _context.Categorias.ToList();
            return new JsonResult(Categorias);
        }
        public JsonResult OnPostCategoriasMarcas()
        {
            IList<Categoria> Categorias = _context.Categorias.ToList();
            IList<Marca> Marcas = _context.Marcas.ToList();
            var resultado = new
            {
                marcas = Marcas,
                categorias = Categorias
            };
            return new JsonResult(resultado);
        }
        public JsonResult OnPostMarcas()
        {
            IList<Marca> Marcas = _context.Marcas.ToList();
            return new JsonResult(Marcas);
        }
        public void OnGet()
        {
            Categorias = _context.Categorias.ToList();
        }
        public async Task<JsonResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(
                  new
                  {
                      Error = "Ha proporcionado datos incorrectos"
                  }
                );
            }
            Imagen Imagen = new Imagen();
            var temporal = await  _context.Productos.Select(
              p => new {
                p.Id, 
                p.IdImagen
              }
            ).Where( p => p.Id == Producto.Id).FirstOrDefaultAsync();
            
            if(temporal == null) {
              return new JsonResult(
                new {
                  Error = "No existe ningún objeto PRODUCTO con el Identificador proporcionado"
                }
              );
            }
            //envio imagen
            if (Producto.Archivo != null)
            {
                string Ruta = "Productos";
                //directorio de destino
                var filepath = "wwwroot/"+Ruta+"/";
                var filename = Producto.Archivo.FileName;
                //validar antes de subir
                var isValidName = ValidFileName(filepath, filename);
                //nombre valido y el archivo no existe
                if (isValidName && !FileExists(filepath, filename) )
                {
                    await UploadFile(filepath, filename, Producto.Archivo);             
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
                    Producto.IdImagen = Imagen.Id;
                    _context.Entry(Producto).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    Mensaje = "Se agrego correctamente";
                    //
                    //
                    //
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
            }//envio imagen

            _context.Productos.Attach(Producto);
            _context.Entry(Producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            Mensaje = "Se ha registrado correctamente";
            return new JsonResult(
              new {
                Mensaje
              }
            );
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