using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_ORM.Models
{
    public class Boletas
    {

        [Key]
        public string Serie { get; set; }
        public string Numero { get; set; }

        public string Fecha { get; set; }
        public double Total { get; set; }
        public string Estado { get; set; }
        public string Ruc { get; set; }
        public string Dni { get; set; }
        public string Codigo { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual Clientes Clientes { get; set; }
        public virtual Empleados Empleados { get; set; }

        
    }
}