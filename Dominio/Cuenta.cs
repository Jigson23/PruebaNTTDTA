using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Dominio
{
    public class Cuenta
    {
        public Cuenta()
        {
            Movimientos = new HashSet<Movimientos>();       
        }

        public Guid cuentaId { get; set; }
        public string numeroCuenta { get; set; }
        public string tipoCuenta { get; set; }
        public decimal saldoInicial { get; set; }
        public Boolean estado { get; set; }
        public Guid clienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public ICollection<Movimientos> Movimientos{get; set;}
    }
}
