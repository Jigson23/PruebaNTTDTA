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
    public class MovimientosRespositorio : IRepositoryBase<Movimientos, Guid> 
    {
        private readonly DBContexto db;
        public MovimientosRespositorio(DBContexto _db)
        {
            db = _db;
        }

        public Movimientos Crear(Movimientos entidad)
        {
            entidad.movimientoId = Guid.NewGuid();

            Cuenta cuenta = db.Cuentas.Where( x => x.numeroCuenta == entidad.cuenta.numeroCuenta).FirstOrDefault();

            if (cuenta == null)
            {
                throw new Exception("La cuenta no existe");
            }

            Movimientos UltimoMovimiento =
                   db.Movimientos.Where(x => x.cuenta.cuentaId == cuenta.cuentaId)
                                  .OrderByDescending(x => x.fecha)
                                  .FirstOrDefault();

            entidad.cuenta = cuenta;

            
            if (entidad.tipoMovimiento.Trim().ToLower() == "credito")
            {
                if (UltimoMovimiento != null)
                {
                    entidad.saldo = UltimoMovimiento.saldo + entidad.valor;
                }
                else {
                    entidad.saldo = cuenta.saldoInicial + entidad.valor;
                }

            }

            if (entidad.tipoMovimiento.Trim().ToLower() == "debito")
            {

                if (UltimoMovimiento != null)
                {
                    if (UltimoMovimiento.saldo <= 0 || UltimoMovimiento.saldo < entidad.valor)
                    {
                        throw new Exception("Saldo no disponible");
                    }
                    entidad.saldo = UltimoMovimiento.saldo - entidad.valor;
                }
                else {
                    if (cuenta.saldoInicial <= 0)
                    {
                        throw new Exception("Saldo no disponible");
                    }
                    else
                    {
                        entidad.saldo = cuenta.saldoInicial - entidad.valor;
                    }
                }

                
            }

            db.Movimientos.Add(entidad);
            return entidad;
        }

        public void Editar(Movimientos entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Guid entidadId)
        {
            throw new NotImplementedException();
        }

        public List<Movimientos> Listar()
        {
            return db.Movimientos
                .Include(x => x.cuenta)
                .ThenInclude(cuenta => cuenta.Cliente)
                .ThenInclude(cliente => cliente.Persona)
                .ToList();
        }

        public Movimientos getById(Guid entidadID)
        {
            return db.Movimientos.Find(entidadID);
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        
    }
}
