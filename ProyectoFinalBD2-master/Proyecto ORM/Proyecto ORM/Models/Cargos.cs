using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_ORM.Models
{
    public class Cargos
    {

        [Key]
        public string Cargo { get; set; }
        public string Descripcion { get; set; }
       
        
    }
}