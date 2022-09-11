using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Dominio
{
    public class Persona
    {
        public Guid personaId { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public int edad { get; set; }
        public string identificacion { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
    }
}
