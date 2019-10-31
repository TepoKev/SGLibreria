using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;
using System.Linq;

namespace SGLibreria.Pages.Compras {
    public class RegistroCompraModel : PageModel {
        private readonly AppDbContext _context;
        public List<Producto> Productos { get; set; }
        public RegistroCompraModel (AppDbContext context) {
            _context = context;            
        }

        [BindProperty]
        public Compra Compra { get; set; }
        [BindProperty]
        public Producto Producto { get; set; }
        [BindProperty]
        public Proveedor Proveedor { get; set; }
        [BindProperty]
        public string[] Telefonos { get; set; }
        [BindProperty]
        public Categoria Categoria { get; set; }
        [BindProperty]
        public Marca Marca { get; set; }
        public IList<Categoria> Categorias {get;set;}
        public IList<Marca> Marcas {get;set;}
        public IList<Proveedor> Proveedores {get;set;}

        public async Task<PartialViewResult> OnPostAgregarProducto(Producto Producto){
            if(!ModelState.IsValid) {
                return Partial("_ProductoPartial",null);
            }
            _context.Productos.Add(Producto);
            await _context.SaveChangesAsync();
            return Partial("_ProductoPartial",null);
        }

        public void OnGet () {
            //this.Categorias = _context.Categorias.ToList();
            //this.Categorias = _context.Categorias.ToList();
            //this.Proveedores = _context.Proveedores.ToList();
        }
        public JsonResult OnGetListaCategorias() {
            this.Categorias = _context.Categorias.ToList();
/*
            this.Categorias = _context.Categorias.ToList();
            this.Proveedores = _context.Proveedores.ToList();
*/
            return new JsonResult(this.Categorias);
        }
        public JsonResult OnGetListaMarcas(){
            this.Marcas = _context.Marcas.ToList();
            return new JsonResult(this.Marcas);
        }
        public async Task<IActionResult> OnPostAgregarMarca(){
            _context.Marcas.Add(Marca);
            await _context.SaveChangesAsync();
            return Page();
        }
        public JsonResult OnGetListaProveedores(){
            this.Proveedores = _context.Proveedores.ToList();
            return new JsonResult(this.Proveedores);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var tamtel = Telefonos.Length;
            this.Proveedor.Estado = (sbyte)1;
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            if(Proveedor.Enlace != null){
                if (!Proveedor.Enlace.Contains("http"))
                {
                    Proveedor.Enlace = "http://" + Proveedor.Enlace;
                }
            }
            this._context.Proveedores.Add(Proveedor);
            await this._context.SaveChangesAsync();
            if(tamtel > 0){
                Telefono telefono;
                telefono = new Telefono();
                telefono.IdProveedor = this.Proveedor.Id;
                telefono.Numero = Telefonos[0];
                telefono.Principal = (sbyte) 1;
                await this._context.Telefonos.AddAsync(telefono);
                for(var i = 1 ; i < Telefonos.Length ; i++)
                {
                    telefono = new Telefono();
                    telefono.IdProveedor = this.Proveedor.Id;
                    telefono.Numero = Telefonos[i];
                    telefono.Principal = (sbyte) 0;
                    await this._context.Telefonos.AddAsync(telefono);
                }
                await this._context.SaveChangesAsync();
            }
            return Page();
        }
    }
}
