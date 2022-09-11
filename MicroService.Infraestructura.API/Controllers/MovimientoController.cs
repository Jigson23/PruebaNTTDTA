using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MicroService.Dominio;
using MicroService.Aplicaciones.Servicios;
using MicroService.Infraestructura.Datos.Contextos;
using MicroService.Infraestructura.Datos.Repositorios;
using MicroService.Infraestructura.API.DTOs;
using System.Net.Http;

namespace MicroService.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {

        MovimientoServicio CrearServicio()
        {
            DBContexto db = new DBContexto();
            MovimientosRespositorio repo = new MovimientosRespositorio(db);
            MovimientoServicio servicio = new MovimientoServicio(repo);
            return servicio;
        }

        // GET: api/<MovimientoController>
        [HttpGet]
        public ActionResult<List<Movimientos>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<MovimientoController>/5
        [HttpGet("{id}")]
        public ActionResult<Movimientos> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.getById(id));
        }

        // POST api/<MovimientoController>
        [HttpPost]
        public ActionResult Post([FromBody] Movimientos movimientos)
        {
            try
            {
                var servicio = CrearServicio();
                servicio.Crear(movimientos);
                return Ok("Creado");
            }
            catch (Exception e)
            {
                return BadRequest(e); 
            }
            
        }

        // PUT api/<MovimientoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Movimientos movimientos)
        {
            try
            {
                var servicio = CrearServicio();
                movimientos.movimientoId = id;
                servicio.Editar(movimientos);
                return Ok("Editado");
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
           
        }

        // DELETE api/<MovimientoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Eliminado");
        }

        [HttpGet("reporte")]
        public ActionResult GetReport([FromQuery] ReportMovimientoQueryParameters parameters) {
            var servicio = CrearServicio();
            List<Movimientos> movimientos = servicio.Listar();

            List<ReporteMovimientos> listado = new List<ReporteMovimientos>();
            if (movimientos.Any())
            {
                listado = movimientos.Where(x =>
                               x.cuenta.numeroCuenta == parameters.cuenta &&
                           (x.fecha >= parameters.beginDate && x.fecha < parameters.endDate)
                           ).Select(s => new ReporteMovimientos
                           {
                               Cliente = s.cuenta.Cliente.Persona.nombre,
                               estado = s.cuenta.estado,
                               Fecha = s.fecha,
                               Movimiento = s.tipoMovimiento == "debito" ? string.Concat("-",s.valor) : s.valor.ToString(),
                               NumeroCuenta = s.cuenta.numeroCuenta,
                               SaldoDisponible = s.saldo,
                               SaldoInicial = s.cuenta.saldoInicial,
                               Tipo = s.tipoMovimiento
                           }).OrderByDescending(x => x.Fecha).ToList();

            }
            return Ok(listado);
        }
    }
}
