using Api_Mongo_Backend.Services;
using ApiMongo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Api_Mongo_Backend.Models;

namespace Api_Mongo_Backend.Controllers
{
    [Route("api/Producto")]
    [ApiController]
    public class ProductoController : Controller
    {
        private ProductoServicios _producto;

        public ProductoController(ProductoServicios producto)
        {
            _producto = producto;
        }

        [HttpGet]
        public ActionResult<List<Producto>> GeT()
        {
            try
            {
                return Ok(_producto.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
        public ActionResult<Producto> Create(Producto prod)
        {
            try
            {
                _producto.Create(prod);
                return Ok("Producto Insertado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Update(Producto prod)
        {
            try
            {
                _producto.Update(prod.Id, prod);
                return Ok("Producto Actualizado");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al actualizar el producto");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                _producto.Delete(id);
                return Ok("Producto Eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al eliminar el producto");
            }
        }
    }
}
