namespace EmpresaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Codigo = c.Int(nullable: false),
                        Direccion = c.String(maxLength: 200),
                        Telefono = c.String(maxLength: 15),
                        Ciudad = c.String(maxLength: 50),
                        Departamento = c.String(maxLength: 50),
                        Pais = c.String(maxLength: 50),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmpresaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empresas");
        }
    }
}
