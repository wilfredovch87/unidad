using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_ORM.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() :base("conexion")
        {

        }
        #region
        public DbSet<Boletas> Boletas { get; set; }
        public DbSet<Cargos> Cargos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Detalles> Detalles { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Inventario> Inventario { get; set; }

        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Productos> Productos { get; set; }

        public DbSet<Proveedor> Proveedor { get; set; }

        #endregion
    }

}