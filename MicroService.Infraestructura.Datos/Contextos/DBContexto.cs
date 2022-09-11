using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MicroService.Dominio;
using MicroService.Infraestructura.Datos.Configs;
using Microsoft.EntityFrameworkCore;

namespace MicroService.Infraestructura.Datos.Contextos
{
    public class DBContexto: DbContext
    {
        string SERVER = Environment.GetEnvironmentVariable("SERVER");
        string PORT = Environment.GetEnvironmentVariable("PORT");
        string DATABASE = Environment.GetEnvironmentVariable("DATABASE");
        string USERNAME = Environment.GetEnvironmentVariable("USERNAME");
        string PASSWORD = Environment.GetEnvironmentVariable("PASSWORD");
        string INTEGRATED_SECURITY = Environment.GetEnvironmentVariable("INTEGRATED_SECURITY");
        string TRUST_SERVER_CERTIFICATE = Environment.GetEnvironmentVariable("TRUST_SERVER_CERTIFICATE");

        public DBContexto()
        {
            this.Database.EnsureCreated();
            
        }

        public DbSet<Persona> personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer($"Server={SERVER},{PORT};Initial Catalog={DATABASE};Persist Security Info=False;User ID={USERNAME};Password={PASSWORD};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate={TRUST_SERVER_CERTIFICATE}; Integrated Security={INTEGRATED_SECURITY};Connection Timeout=30;");
            //options.UseSqlServer($"Data Source=localhost,14333;Initial Catalog=BancoDB;Persist Security Info=False;User ID=sa;Password=Channel321*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=true; Integrated Security=false;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PersonaConfig());
            builder.ApplyConfiguration(new ClienteConfig());
            builder.ApplyConfiguration(new CuentaConfig());
            builder.ApplyConfiguration(new MovimientoConfig());

          
        }
    }
}
