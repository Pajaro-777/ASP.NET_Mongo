using Api_Mongo_Backend.Services;
using ApiMongo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Api_Mongo_Backend.Models;

namespace Api_Mongo_Backend.Controllers
{
    [Route("api/Venta")]
    [ApiController]
    public class VentaController : Controller
    {
        private VentaServicios _ventas;

        public VentaController(VentaServicios venta)
        {
            _ventas = venta;
        }

        [HttpGet]
        public ActionResult<List<Venta>> GeT()
        {
            try
            {
                return Ok(_ventas.Get());
            }
            catch (Exception ex)
            {
                return BadRequest("No se puede obtener los datos");
            }

        }

        [HttpPost]
        public ActionResult<Venta> Create(Venta ventas)
        {
            try
            {
                _ventas.Create(ventas);
                return Ok("Venta Insertado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Update(Venta ventas)
        {
            try
            {
                _ventas.Update(ventas.Id, ventas);
                return Ok("Venta Actualizada");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al actualizar la venta");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                _ventas.Delete(id);
                return Ok("Producto Eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al eliminar el producto");
            }
        }
    }
}
