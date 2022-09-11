using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Dominio.interfaces
{
    public interface IReportes<TEntidad, TPamUno, TPamDos, TPamTres>
    {
        List<TEntidad> GetReporteMovimientos(TPamUno pamUno, TPamDos pamDos, TPamTres pamTres);
    }
}
