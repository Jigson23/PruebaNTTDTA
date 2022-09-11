using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MicroService.Dominio;
using MicroService.Infraestructura.Datos.Contextos;
using MicroService.Dominio.interfaces.Repositorios;

namespace MicroService.Infraestructura.Datos.Repositorios
{
    public class CuentaRepositorio : IRepositoryBase<Cuenta, Guid>
    {
        private readonly DBContexto db;
        public CuentaRepositorio(DBContexto _db)
        {
            db = _db;
        }
        public Cuenta Crear(Cuenta entidad)
        {
            Cliente cliente =
                db.Clientes.Find(entidad.clienteId);

            if (cliente == null)
            {
                throw new Exception("El Cliente es requerido");  
            }

            entidad.cuentaId = Guid.NewGuid();
            entidad.Cliente = cliente;
            db.Cuentas.Add(entidad);

            return entidad;
        }

        public void Editar(Cuenta entidad)
        {
            Cuenta cuenta =
                db.Cuentas.Where(x => x.cuentaId == entidad.cuentaId).FirstOrDefault();
            if (cuenta != null)
            {
                cuenta.estado = entidad.estado;
                cuenta.numeroCuenta = entidad.numeroCuenta;
                cuenta.tipoCuenta = entidad.tipoCuenta;
                cuenta.saldoInicial = entidad.saldoInicial;

                db.Entry(cuenta).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            Cuenta cuenta =
                db.Cuentas.Where(x => x.cuentaId == entidadId).FirstOrDefault();

            if (cuenta != null)
            {
                db.Cuentas.Remove(cuenta);
            }
        }

        public Cuenta getById(Guid entidadID)
        {
            Cuenta cuenta = db.Cuentas.Where(x => x.cuentaId == entidadID)
                .Select( x => new Cuenta { 
                    Cliente = x.Cliente,
                    cuentaId = x.cuentaId,
                    estado = x.estado,
                    Movimientos = x.Movimientos,
                    numeroCuenta = x.numeroCuenta,
                    saldoInicial = x.saldoInicial,
                    tipoCuenta = x.tipoCuenta
                }).FirstOrDefault();

            return cuenta;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Cuenta> Listar()
        {
            return db.Cuentas.Select(x => new Cuenta
            {
                Cliente = x.Cliente,
                cuentaId = x.cuentaId,
                estado = x.estado,
                Movimientos = x.Movimientos,
                numeroCuenta = x.numeroCuenta,
                saldoInicial = x.saldoInicial,
                tipoCuenta = x.tipoCuenta
            }).ToList();
        }
    }
}
