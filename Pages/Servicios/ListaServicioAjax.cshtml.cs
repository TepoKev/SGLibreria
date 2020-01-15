using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGLibreria.Models;

namespace SGLibreria.Pages.Servicios
{
    public class ListaServicioAjaxModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<Tiposervicio> Tiposervicio { get; set; }
        public int Pagina { get; set; }
        public int CantidadPorFila { get; set; }
        public int Maximo { get; set; }
        public string NombreOCodigo { get; set; }
        public int Total { get; set; }
        public ListaServicioAjaxModel(AppDbContext context)
        {
            this.Pagina = 0;
            this.CantidadPorFila = 6;
            this.Maximo = this.CantidadPorFila * 2;
            _context = context;
        }
        public IActionResult OnGet(int? Pagina, int? CantidadPorFila, int? Maximo, string NombreOCodigo)
        {
            IQueryable<Tiposervicio> Consulta = _context.Tiposervicio
            .Include(p => p.IdCompaniaNavigation)
            .Include(p => p.IdServicioNavigation)
            .Include(x => x.IdImagenNavigation)
            .ThenInclude(x => x.IdRutaNavigation);

            if(Pagina == null){
                Pagina = this.Pagina;
            }
            if(CantidadPorFila == null){
                CantidadPorFila = this.CantidadPorFila;
            }
            if(Maximo == null){
                Maximo = this.Maximo;
            }

            Consulta = Consulta.Where(p => EF.Functions.Like(p.Nombre, $"%{NombreOCodigo}%"));

            var total = _context.Servicios.Select(
                        q => new
                        {
                            co = Consulta.Count()
                        }
                    ).FirstOrDefault();
            this.Total = total.co;

            this.Tiposervicio = Consulta.ToList();
            Consulta = Consulta.Skip((Pagina.Value)* Maximo.Value).Take(Maximo.Value);
            this.Tiposervicio = Consulta.ToList();
            return Page();
        }
    }
}