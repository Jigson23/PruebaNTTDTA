using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MicroService.Dominio;
using MicroService.Dominio.interfaces;
using MicroService.Dominio.interfaces.Repositorios;
using MicroService.Aplicaciones.Interfaces;

namespace MicroService.Aplicaciones.Servicios
{
    public class MovimientoServicio : IServicioBase<Movimientos, Guid>
    {

        private readonly IRepositoryBase<Movimientos, Guid> repoMovimiento;
        

        public MovimientoServicio(
            IRepositoryBase<Movimientos, Guid> _repoMovimiento)
        {
            repoMovimiento = _repoMovimiento;
        }

        public Movimientos Crear(Movimientos entidad)
        {
            if(entidad == null)
                throw new ArgumentNullException("El Movimiento es requerdo");

            if (entidad.cuenta == null)
                throw new ArgumentNullException("La cuenta no puede ser nula");

            var result = repoMovimiento.Crear(entidad);
            repoMovimiento.GuardarTodosLosCambios();
            return result;

        }

        public void Editar(Movimientos entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El Movimiento es requerdo");

            if (entidad.cuenta == null)
                throw new ArgumentNullException("La cuenta no puede ser nula");

            repoMovimiento.Editar(entidad);
            repoMovimiento.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoMovimiento.Eliminar(entidadId);
            repoMovimiento.GuardarTodosLosCambios();
        }

        public Movimientos getById(Guid entidadID)
        {
            return repoMovimiento.getById(entidadID);
        }

        public List<Movimientos> Listar()
        {
            return repoMovimiento.Listar();
        }
 
    }
}
