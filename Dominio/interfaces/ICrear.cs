using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Dominio.interfaces
{
    public interface ICrear<TEntidad>
    {
        TEntidad Crear(TEntidad entidad);
    }
}
