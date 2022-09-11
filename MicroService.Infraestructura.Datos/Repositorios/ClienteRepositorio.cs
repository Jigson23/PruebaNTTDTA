using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MicroService.Dominio;
using MicroService.Infraestructura.Datos.Contextos;
using MicroService.Dominio.interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace MicroService.Infraestructura.Datos.Repositorios
{


    public class ClienteRepositorio : IRepositoryBase<Cliente, Guid>
    {
        private readonly DBContexto db;
        public ClienteRepositorio(DBContexto _db)
        {
            db = _db;
        }
        public Cliente Crear(Cliente entidad)
        {
            entidad.clienteId = Guid.NewGuid();
            db.Clientes.Add(entidad);
            return entidad;
        }

        public void Editar(Cliente entidad)
        {
            var clienteSeleccionado =
                db.Clientes.Where(x => x.clienteId == entidad.clienteId).FirstOrDefault();
            if (clienteSeleccionado != null)
            {
                clienteSeleccionado.contrasenia = entidad.contrasenia;
                clienteSeleccionado.estado = entidad.estado;
                clienteSeleccionado.Persona.nombre = entidad.Persona.nombre;
                clienteSeleccionado.Persona.genero = entidad.Persona.genero;
                clienteSeleccionado.Persona.edad = entidad.Persona.edad;
                clienteSeleccionado.Persona.direccion = entidad.Persona.direccion;
                clienteSeleccionado.Persona.telefono = entidad.Persona.telefono;

                db.Entry(clienteSeleccionado).State = 
                    EntityState.Modified;

            }
        }

        public void Eliminar(Guid entidadId)
        {
            var clienteSeleccionado =
                db.Clientes.Where(x => x.clienteId == entidadId).FirstOrDefault();
            if (clienteSeleccionado != null)
            {
                db.Clientes.Remove(clienteSeleccionado);
            }
        }

        public Cliente getById(Guid entidadID)
        {
            var clienteSeleccionado =
                db.Clientes.Where(x => x.clienteId == entidadID).FirstOrDefault();
            return clienteSeleccionado;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Cliente> Listar()
        {
            return db.Clientes.Select(x => new Cliente {
                clienteId  = x.clienteId,
                Cuentas = x.Cuentas,
                Persona  = x.Persona,
                contrasenia = x.contrasenia,
                estado = x.estado
            }).ToList();
        }
    }
}
