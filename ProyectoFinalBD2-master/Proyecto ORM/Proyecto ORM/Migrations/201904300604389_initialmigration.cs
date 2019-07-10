namespace Proyecto_ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boletas",
                c => new
                    {
                        Serie = c.String(nullable: false, maxLength: 128),
                        Numero = c.String(),
                        Fecha = c.String(),
                        Total = c.Double(nullable: false),
                        Estado = c.String(),
                        Ruc = c.String(maxLength: 128),
                        Dni = c.String(maxLength: 128),
                        Codigo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Serie)
                .ForeignKey("dbo.Clientes", t => t.Dni)
                .ForeignKey("dbo.Empleados", t => t.Codigo)
                .ForeignKey("dbo.Empresas", t => t.Ruc)
                .Index(t => t.Ruc)
                .Index(t => t.Dni)
                .Index(t => t.Codigo);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Dni = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Apellidos = c.String(),
                        Telefono = c.String(),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.Dni);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        Codigo = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        Correo = c.String(),
                        Estado = c.String(),
                        Clave = c.String(),
                        Cargo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Cargos", t => t.Cargo)
                .Index(t => t.Cargo);
            
            CreateTable(
                "dbo.Cargos",
                c => new
                    {
                        Cargo = c.String(nullable: false, maxLength: 128),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Cargo);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Ruc = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.Ruc);
            
            CreateTable(
                "dbo.Detalles",
                c => new
                    {
                        Serie = c.String(nullable: false, maxLength: 128),
                        Numero = c.String(),
                        Codigo = c.String(maxLength: 128),
                        Cantidad = c.Int(nullable: false),
                        Importe = c.Double(nullable: false),
                        Boletas_Serie = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Serie)
                .ForeignKey("dbo.Boletas", t => t.Boletas_Serie)
                .ForeignKey("dbo.Productos", t => t.Codigo)
                .Index(t => t.Codigo)
                .Index(t => t.Boletas_Serie);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        Codigo = c.String(nullable: false, maxLength: 128),
                        Descripcion = c.String(),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Double(nullable: false),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Proveedor_Dni = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Proveedors", t => t.Proveedor_Dni)
                .Index(t => t.Proveedor_Dni);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        Dni = c.String(nullable: false, maxLength: 128),
                        Ruc = c.String(),
                        Descripcion = c.String(),
                        Telefono = c.String(),
                        Rubro = c.String(),
                        Direccion = c.String(),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.Dni);
            
            CreateTable(
                "dbo.Inventarios",
                c => new
                    {
                        Codigo = c.String(nullable: false, maxLength: 128),
                        Descripcion = c.String(),
                        Cantidad = c.String(),
                        Precio = c.String(),
                        Estado = c.String(),
                        Producto = c.String(),
                        Productos_Codigo = c.String(maxLength: 128),
                        Proveedor_Dni = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Productos", t => t.Productos_Codigo)
                .ForeignKey("dbo.Proveedors", t => t.Proveedor_Dni)
                .Index(t => t.Productos_Codigo)
                .Index(t => t.Proveedor_Dni);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        Codigo = c.String(nullable: false, maxLength: 128),
                        Fecha = c.String(),
                        Descripcion = c.String(),
                        Total = c.String(),
                        Cliente = c.String(),
                        Empleado = c.String(),
                        Estado = c.String(),
                        Clientes_Dni = c.String(maxLength: 128),
                        Empleados_Codigo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Clientes", t => t.Clientes_Dni)
                .ForeignKey("dbo.Empleados", t => t.Empleados_Codigo)
                .Index(t => t.Clientes_Dni)
                .Index(t => t.Empleados_Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidos", "Empleados_Codigo", "dbo.Empleados");
            DropForeignKey("dbo.Pedidos", "Clientes_Dni", "dbo.Clientes");
            DropForeignKey("dbo.Inventarios", "Proveedor_Dni", "dbo.Proveedors");
            DropForeignKey("dbo.Inventarios", "Productos_Codigo", "dbo.Productos");
            DropForeignKey("dbo.Detalles", "Codigo", "dbo.Productos");
            DropForeignKey("dbo.Productos", "Proveedor_Dni", "dbo.Proveedors");
            DropForeignKey("dbo.Detalles", "Boletas_Serie", "dbo.Boletas");
            DropForeignKey("dbo.Boletas", "Ruc", "dbo.Empresas");
            DropForeignKey("dbo.Boletas", "Codigo", "dbo.Empleados");
            DropForeignKey("dbo.Empleados", "Cargo", "dbo.Cargos");
            DropForeignKey("dbo.Boletas", "Dni", "dbo.Clientes");
            DropIndex("dbo.Pedidos", new[] { "Empleados_Codigo" });
            DropIndex("dbo.Pedidos", new[] { "Clientes_Dni" });
            DropIndex("dbo.Inventarios", new[] { "Proveedor_Dni" });
            DropIndex("dbo.Inventarios", new[] { "Productos_Codigo" });
            DropIndex("dbo.Productos", new[] { "Proveedor_Dni" });
            DropIndex("dbo.Detalles", new[] { "Boletas_Serie" });
            DropIndex("dbo.Detalles", new[] { "Codigo" });
            DropIndex("dbo.Empleados", new[] { "Cargo" });
            DropIndex("dbo.Boletas", new[] { "Codigo" });
            DropIndex("dbo.Boletas", new[] { "Dni" });
            DropIndex("dbo.Boletas", new[] { "Ruc" });
            DropTable("dbo.Pedidos");
            DropTable("dbo.Inventarios");
            DropTable("dbo.Proveedors");
            DropTable("dbo.Productos");
            DropTable("dbo.Detalles");
            DropTable("dbo.Empresas");
            DropTable("dbo.Cargos");
            DropTable("dbo.Empleados");
            DropTable("dbo.Clientes");
            DropTable("dbo.Boletas");
        }
    }
}
