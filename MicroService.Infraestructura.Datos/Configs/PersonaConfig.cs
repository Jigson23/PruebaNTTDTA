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
    class PersonaConfig : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder
                .ToTable("tblPersona")
                .HasKey(k => k.personaId);

            builder.HasIndex(p => p.identificacion).IsUnique();
            
        }
    }
}
