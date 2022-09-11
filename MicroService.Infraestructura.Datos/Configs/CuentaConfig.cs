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
    class CuentaConfig : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.ToTable("tblCuenta")
            .HasIndex(c => c.numeroCuenta).IsUnique();
            builder.HasKey(k => k.cuentaId);
   

            builder
                .HasOne(cuenta => cuenta.Cliente)
                .WithMany(cliente => cliente.Cuentas);

            builder
                .HasMany(cuenta => cuenta.Movimientos)
                .WithOne(movimiento => movimiento.cuenta);
        }
    }
}
