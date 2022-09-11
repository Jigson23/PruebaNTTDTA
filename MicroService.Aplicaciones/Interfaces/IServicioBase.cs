using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MicroService.Dominio.interfaces;

namespace MicroService.Aplicaciones.Interfaces
{
    interface IServicioBase<TEntidad, TEntidadID>
        : ICrear<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>
    {

    }
}
