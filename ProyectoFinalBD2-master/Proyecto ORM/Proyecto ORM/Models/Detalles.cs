using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_ORM.Models
{
    public class Detalles
    {

       [Key]
        public string Serie { get; set; }
        public string Numero { get; set; }
        public string Codigo { get; set; }
        public int Cantidad { get; set; }
        public double Importe { get; set; }
        public virtual Productos Productos { get; set; }
        public virtual Boletas Boletas { get; set; }

    }
}