using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SGLibreria.Pages.Compras
{
    public class RegistroCompraModel : PageModel
    {
        private readonly AppDbContext _context;
        
        public RegistroCompraModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Compra Compra { get; set; }
        public Producto Producto { get; set;}
        public Categoria Categoria { get; set;}
        public Marca Marca { get; set; }
        public Proveedor Proveedor {get;set;}
        public List<Producto> Productos { get; set; }
        public IList<Categoria> Categorias { get; set; }
        public IList<Marca> Marcas { get; set; }
        public IList<Proveedor> Proveedores { get; set; }

        public void OnGet()
        {
        }
        public JsonResult OnGetListaCategorias()
        {
            this.Categorias = _context.Categorias.ToList();
            return new JsonResult(this.Categorias);
        }
        public JsonResult OnGetListaMarcas()
        {
            this.Marcas = _context.Marcas.ToList();
            return new JsonResult(this.Marcas);
        }
        public async Task<IActionResult> OnPostAgregarMarca(Marca Marca)
        {
            _context.Marcas.Add(Marca);
            await _context.SaveChangesAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAgregarCategoria(Categoria Categoria)
        {
            Categoria.Estado = (sbyte)1;
            _context.Categorias.Add(Categoria);
            await _context.SaveChangesAsync();
            return Page();
        }
        public JsonResult OnGetListaProveedores()
        {
            this.Proveedores = _context.Proveedores.ToList();
            return new JsonResult(this.Proveedores);
        }

        public async Task<IActionResult> OnPostRegistrarProveedor(string[] Telefonos,[BindRequired] Proveedor Proveedor)
        {
            var tamtel = Telefonos.Length;
            Proveedor.Estado = (sbyte)1;

            if (Proveedor.Enlace != null)
            {
                if (!Proveedor.Enlace.Contains("http"))
                {
                    Proveedor.Enlace = "http://" + Proveedor.Enlace;
                }
            }
            this._context.Proveedores.Add(Proveedor);
            await this._context.SaveChangesAsync();
            if (tamtel > 0)
            {
                Telefono telefono;
                telefono = new Telefono();
                telefono.IdProveedor = Proveedor.Id;
                telefono.Numero = Telefonos[0];
                telefono.Principal = (sbyte)1;
                await this._context.Telefonos.AddAsync(telefono);
                for (var i = 1; i < Telefonos.Length; i++)
                {
                    telefono = new Telefono();
                    telefono.IdProveedor = Proveedor.Id;
                    telefono.Numero = Telefonos[i];
                    telefono.Principal = (sbyte)0;
                    await this._context.Telefonos.AddAsync(telefono);
                }
                await this._context.SaveChangesAsync();
            }
            return Page();
        }

        public async Task<JsonResult> OnPostProductoNuevoAsync(Producto Producto)
        {
            string Mensaje = "";
            Producto objRet = null;//producto a retornar
            if (!ModelState.IsValid)
            {
                return new JsonResult(
                  new
                  {
                      Error = "Ha proporcionado datos incorrectos", 
                      Producto = (object) null, 
                  }
                );
            }
            Imagen Imagen = new Imagen();
            
            //envio imagen
            if (Producto.Archivo != null)
            {
                string Ruta = "Productos";
                //directorio de destino
                var filepath = "wwwroot/" + Ruta + "/";
                var filename = Producto.Archivo.FileName;
                //validar antes de subir
                var isValidName = ValidFileName(filepath, filename);
                //nombre valido y el archivo no existe
                if (isValidName && !FileExists(filepath, filename))
                {
                    await UploadFile(filepath, filename, Producto.Archivo);
                    Imagen.Nombre = filename;
                    
                    //Como es producto nuevo, hay que agregar un nuevo registro
                    Imagen.IdRuta = (await _context.Rutas.Where(r => EF.Functions.Like(r.Nombre, $"%{Ruta}%")).FirstOrDefaultAsync()).Id;
                    _context.Imagenes.Add(Imagen);
                    
                    await _context.SaveChangesAsync();
                    Producto.IdImagen = Imagen.Id;
                    _context.Entry(Producto).State = EntityState.Added;
                    await _context.SaveChangesAsync();
                    Mensaje = "Se agrego correctamente";
                    objRet = Producto;
                    //
                    //
                    //
                }
                else if (FileExists(filepath, filename))
                { //el ya archivo existe

                    Mensaje = "La imagen: " + filename + " ya existe. por favor cambie el nombre del archivo que quiere subir e intentelo de nuevo";
                    objRet = null;
                }
                else if (!isValidName)
                {
                    Mensaje = "El nombre de archivo: " + filename + " es incorrecto";
                    objRet = null;
                }
                return new JsonResult(
                  new
                  {
                      Mensaje, Producto = objRet
                  }
                );
            }//envio imagen

            _context.Productos.Attach(Producto);
            _context.Entry(Producto).State = EntityState.Added;
            await _context.SaveChangesAsync();
            Mensaje = "Se ha registrado correctamente";
            objRet = Producto;
            return new JsonResult(
              new
              {
                  Mensaje, Producto = objRet
              }
            );
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

    }
}
