using Api_Mongo_Backend.Services;
using ApiMongo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Api_Mongo_Backend.Models;

namespace Api_Mongo_Backend.Controllers
{
    [Route("api/Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteServicios _clientes;

        public ClienteController(ClienteServicios cliente)
        {
            _clientes = cliente;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> GeT()
        {
            try
            {
                return Ok(_clientes.Get());
            }
            catch (Exception ex)
            {
                return BadRequest("No se puede obtener los datos");
            }

        }

        [HttpPost]
        public ActionResult<Cliente> Create(Cliente cliente)
        {
            try
            {
                _clientes.Create(cliente);
                return Ok("Cliente Insertado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Update(Cliente cliente)
        {
            try
            {
                _clientes.Update(cliente.Id, cliente);
                return Ok("Producto Actualizado");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al actualizar el Cliente");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                _clientes.Delete(id);
                return Ok("Cliente Eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al eliminar el cliente");
            }
        }
    }
}
