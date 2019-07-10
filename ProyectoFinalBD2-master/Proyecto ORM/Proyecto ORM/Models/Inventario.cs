using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_ORM.Models
{
    public class Inventario
    {

        [Key]
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Cantidad { get; set; }
        public string Precio { get; set; }
        public string Estado { get; set; }
        public string Producto { get; set; }
 
        public virtual Productos Productos { get; set; }
        public virtual Proveedor Proveedor { get; set; }

    }
}