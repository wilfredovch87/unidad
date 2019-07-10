using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_ORM.Models
{
    public class Proyecto_ORMContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Proyecto_ORMContext() : base("name=Proyecto_ORMContext")
        {
        }

        public System.Data.Entity.DbSet<Proyecto_ORM.Models.Clientes> Clientes { get; set; }

        public System.Data.Entity.DbSet<Proyecto_ORM.Models.Proveedor> Proveedors { get; set; }

        public System.Data.Entity.DbSet<Proyecto_ORM.Models.Empleados> Empleados { get; set; }

        public System.Data.Entity.DbSet<Proyecto_ORM.Models.Cargos> Cargos { get; set; }

        public System.Data.Entity.DbSet<Proyecto_ORM.Models.Productos> Productos { get; set; }

        public System.Data.Entity.DbSet<Proyecto_ORM.Models.Empresa> Empresas { get; set; }
    }
}
