using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Infraestructura.API.DTOs
{
    public class ReporteMovimientos
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public Boolean estado { get; set; }
        public string Movimiento { get; set; }
        public decimal SaldoDisponible { get; set; }
    }
}
