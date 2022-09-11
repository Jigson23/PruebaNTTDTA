using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MicroService.Dominio.interfaces;

namespace MicroService.Dominio.interfaces.Repositorios
{
    public interface IRepositorioMovimiento<TEntidad, TEntidadID>
        : ICrear<TEntidad>, IListar<TEntidad, TEntidadID>, ITransaccion
    {
    }
}
