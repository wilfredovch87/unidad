using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_ORM.Models
{
    public class Productos
    {

        [Key]
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public Double Precio { get; set; }
        public decimal Importe { get; set; }
        public virtual Proveedor Proveedor { get; set; }



    }
}