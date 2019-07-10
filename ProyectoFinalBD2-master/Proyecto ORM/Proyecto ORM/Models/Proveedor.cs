using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_ORM.Models
{
    public class Proveedor
    {

        [Key]
        public string Dni { get; set; }
        public string Ruc { get; set; }
        public string Descripcion { get; set; }
        public string Telefono { get; set; }
        public string Rubro { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        


    }
}