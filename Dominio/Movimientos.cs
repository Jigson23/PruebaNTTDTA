using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Dominio
{
    public class Movimientos
    {
        public Guid movimientoId { get; set; }
        public DateTime fecha { get; set; } = DateTime.Now;
        public string tipoMovimiento{ get; set; }
        public decimal valor { get; set; }
        public decimal saldo { get; set; }
        public Guid cuentaId { get; set; }
        public virtual Cuenta cuenta { get; set; }
    }
}
