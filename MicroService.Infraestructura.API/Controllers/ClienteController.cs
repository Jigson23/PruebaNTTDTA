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
    public class ClienteController : ControllerBase
    {
        ClienteServicio CrearServicio() {
            DBContexto db = new DBContexto();
            ClienteRepositorio repo = new ClienteRepositorio(db);
            ClienteServicio servicio = new ClienteServicio(repo);
            return servicio;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.getById(id));
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                var servicio = CrearServicio();
                servicio.Crear(cliente);
                return Ok("Creado");
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
            
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Cliente cliente)
        {
            try
            {
                var servicio = CrearServicio();
                cliente.clienteId = id;
                servicio.Editar(cliente);
                return Ok("Editado");
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
            
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Eliminado");
        }
    }
}
