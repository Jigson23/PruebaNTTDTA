using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MicroService.Dominio;
using MicroService.Dominio.interfaces.Repositorios;
using MicroService.Aplicaciones.Interfaces;

namespace MicroService.Aplicaciones.Servicios
{
    public class CuentaServicio : IServicioBase<Cuenta, Guid>
    {
        private readonly IRepositoryBase<Cuenta, Guid> repository;
        public CuentaServicio(IRepositoryBase<Cuenta, Guid> _repository) {
            repository = _repository;
        }
        public Cuenta Crear(Cuenta entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La Cuenta es requerida");
                
            var result = repository.Crear(entidad);
            repository.GuardarTodosLosCambios();
            return result;
        }

        public void Editar(Cuenta entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La Cuenta es requerida");

            if (entidad.Cliente == null)
                throw new ArgumentNullException("El Cliente es requerido");

            repository.Editar(entidad);
            repository.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repository.Eliminar(entidadId);
            repository.GuardarTodosLosCambios();
        }

        public Cuenta getById(Guid entidadID)
        {
            return repository.getById(entidadID);
        }

        public List<Cuenta> Listar()
        {
            return repository.Listar();
        }
    }
}
