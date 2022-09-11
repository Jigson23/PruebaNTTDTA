using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Dominio
{
    public class Cliente
    {
        public Cliente()
        {
            Cuentas = new HashSet<Cuenta>();
        }
        public Guid clienteId { get; set; }
        public Persona Persona { get; set; }
        public string contrasenia { get; set; }
        public Boolean estado { get; set; } = true;
        public virtual ICollection<Cuenta> Cuentas { get; set; }
    }
 
}
