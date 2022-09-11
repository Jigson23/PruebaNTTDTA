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
    public class ClienteServicio : IServicioBase<Cliente, Guid>
    {
        private readonly IRepositoryBase<Cliente, Guid> repository;
        public ClienteServicio(IRepositoryBase<Cliente, Guid> _repository) 
        {
            repository = _repository;
        }
        public Cliente Crear(Cliente entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El Cliente es requerido");

            if (entidad.Persona == null)
                throw new ArgumentNullException("La Persona no puede ser nula");


            var result = repository.Crear(entidad);
            repository.GuardarTodosLosCambios();
            return result;
                
        }

        public void Editar(Cliente entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El Cliente es requerido");

            if (entidad.Persona == null)
                throw new ArgumentNullException("La Persona no puede ser nula");

            repository.Editar(entidad);
            repository.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repository.Eliminar(entidadId);
            repository.GuardarTodosLosCambios();
        }

        public Cliente getById(Guid entidadID)
        {
            return repository.getById(entidadID);
        }

        public List<Cliente> Listar()
        {
            return repository.Listar();
        }
    }
}
