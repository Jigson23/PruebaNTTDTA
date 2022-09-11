using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MicroService.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroService.Infraestructura.Datos.Configs
{
    class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("tblCliente");
            builder.HasKey(k => k.clienteId);
            

            builder
                .HasOne(cliente => cliente.Persona);

  
            
            builder
                .HasMany(cliente => cliente.Cuentas)
                .WithOne(cuentas => cuentas.Cliente);
        }
    }
}
