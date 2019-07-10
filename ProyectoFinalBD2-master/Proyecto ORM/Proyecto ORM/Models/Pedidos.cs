using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_ORM.Models
{
    public class Pedidos
    {

        [Key]
        public string Codigo { get; set; }
        public string Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Total { get; set; }
        public string Cliente { get; set; }
        public string Empleado { get; set; }
        public string Estado { get; set; }
        public virtual Clientes Clientes { get; set; }
        public virtual Empleados Empleados { get; set; }
    }
}