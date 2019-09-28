using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGLibreria.Models;

namespace SGLibreria.Pages.Proveedores
{
    public class RegistroProveedorModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public Proveedor Proveedor { get; set; }
        public RegistroProveedorModel(AppDbContext context)
        {
            _context = context;
        }
        public async Task<JsonResult> OnPost()
        {
            this.Proveedor.Estado = (sbyte)1;
            if (!ModelState.IsValid)
            {
                return new JsonResult("");
            }
            if (!Proveedor.Enlace.Contains("http"))
            {
                Proveedor.Enlace = "http://" + Proveedor.Enlace;
            }
            _context.Proveedores.Add(Proveedor);
            await _context.SaveChangesAsync();
            return new JsonResult(this.Proveedor.Id);
        }
        public async Task<IActionResult> OnPostRest(int Id, string Principal, string Telefonos)
        {
            var ListaTelefonos = ConvetArray(Telefonos);
            Telefono telefono;
            foreach (var item in ListaTelefonos)
            {
                telefono = new Telefono();
                telefono.IdProveedor = Id;
                telefono.Numero = item;
                if(item.Equals(Principal)){
                    telefono.Principal = (sbyte)1;
                }
                await this._context.Telefonos.AddAsync(telefono);
            }
            await this._context.SaveChangesAsync();
            return Page();
        }
        public List<String> ConvetArray(string array){
            var result = new List<String>();
            var CharArray = array.ToCharArray();
            string Numero = "";
            int tam = CharArray.Length;
            for(var i = 0 ; i < tam ; i++){
                if(CharArray[i].Equals(',')){
                    result.Add(Numero);
                    Numero = "";
                }else{
                    Numero += CharArray[i];
                    if(i == (tam -1)){
                        result.Add(Numero);
                    }
                }
            }
            return result;
        }
    }
}