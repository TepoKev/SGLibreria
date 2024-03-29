﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace SGLibreria.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detallecompra = new HashSet<Detallecompra>();
            Ofertaproducto = new HashSet<Ofertaproducto>();
            Precioventa = new List<Precioventa>();
        }

        public int Id { get; set; }
        [Display(Name="Código"), StringLength(25, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Codigo { get; set; }
        [Display(Name = "Categoría")]
        public int IdCategoria { get; set; }
        [NotMapped]
        public IFormFile Archivo {get;set;}
        public int? IdImagen { get; set; }
        [Required(ErrorMessage="El {0} es obligatorio"), StringLength(30, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Nombre { get; set; }
        [Display(Name = "Marca")]
        public int? IdMarca { get; set; }
        [Display(Name="Descripción"), StringLength(100, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Descripcion { get; set; }
        [Display(Name="Existencia mínima")]
        public int StockMinimo { get; set; }
        public sbyte Estado { get; set; }
        [Display(Name="Fecha de Vencimiento")]
        public DateTime? FechaVencimiento { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Imagen IdImagenNavigation { get; set; }
        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<Detallecompra> Detallecompra { get; set; }
        public virtual ICollection<Ofertaproducto> Ofertaproducto { get; set; }
        public virtual List<Precioventa> Precioventa { get; set; }
        public virtual List<Kardex> Kardex {get;set;}
    }
}