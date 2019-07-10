using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_ORM.Models
{
    public class Empleados
    {

        [Key]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }
        public string Clave { get; set; }
        public string Cargo { get; set; }

        public virtual Cargos Cargos { get; set; }
    }
}