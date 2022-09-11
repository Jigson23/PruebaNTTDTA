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
    class MovimientoConfig : IEntityTypeConfiguration<Movimientos>
    {
        public void Configure(EntityTypeBuilder<Movimientos> builder)
        {
            builder.ToTable("tblMovimientos");
            builder.HasKey(k => k.movimientoId);

            builder
                .HasOne(movimiento => movimiento.cuenta)
                .WithMany(cuenta => cuenta.Movimientos);
        }
    }
}
