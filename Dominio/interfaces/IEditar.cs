﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Dominio.interfaces
{
    public interface IEditar<TEntidad>
    {
        void Editar(TEntidad entidad);
    }
}
