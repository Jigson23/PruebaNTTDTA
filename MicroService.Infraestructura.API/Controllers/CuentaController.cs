using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MicroService.Dominio;
using MicroService.Aplicaciones.Servicios;
using MicroService.Infraestructura.Datos.Contextos;
using MicroService.Infraestructura.Datos.Repositorios;


namespace MicroService.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        CuentaServicio CrearServicio() {
            DBContexto db = new DBContexto();
            CuentaRepositorio repo = new CuentaRepositorio(db);
            CuentaServicio servicio = new CuentaServicio(repo);
            return servicio;
        }

        // GET: api/<CuentaController>
        [HttpGet]
        public ActionResult<List<Cuenta>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<CuentaController>/5
        [HttpGet("{id}")]
        public ActionResult<Cuenta> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.getById(id));
        }

        // POST api/<CuentaController>
        [HttpPost]
        public ActionResult Post([FromBody] Cuenta cuenta)
        {
            try
            {
                var servicio = CrearServicio();
                servicio.Crear(cuenta);
                return Ok("Creado");
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
            
        }

        // PUT api/<CuentaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Cuenta cuenta)
        {
            try
            {
                var servicio = CrearServicio();
                cuenta.cuentaId = id;
                servicio.Editar(cuenta);
                return Ok("Editado");
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
           
        }

        // DELETE api/<CuentaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Eliminado");
        }
    }
}
