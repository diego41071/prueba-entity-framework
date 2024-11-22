using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EmpresaApp.Models;

namespace EmpresaApp.Data
{
    public class EmpresaContext : DbContext
    {
        // Constructor que define la cadena de conexión
        public EmpresaContext() : base("name=EmpresaDBConnection")
        {
        }

        // DbSet para la entidad Empresa
        public DbSet<Empresa> Empresas { get; set; }

        // Configuración adicional si es necesario
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
