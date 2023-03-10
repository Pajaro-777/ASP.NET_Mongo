using Api_Mongo_Backend.Services;
using ApiMongo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api_Mongo_Backend.Controllers
{
    [Route("api/Productos")]
    [ApiController]
    public class ProductosController : Controller
    {
        private ProductosServices _productos;

        public ProductosController(ProductosServices productos)
        {
            _productos = productos;
        }

        [HttpGet]
        public ActionResult<List<Productos>> GeT()
        {
            try
            {
                return Ok(_productos.Get());
            }
            catch(Exception ex)
            {
                return BadRequest("No se puede obtener los datos");
            }
            
        }

        [HttpPost]
        public ActionResult<Productos> Create(Productos prod)
        {
            try
            {
                _productos.Create(prod);
                return Ok("Producto Insertado");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Update(Productos prod)
        {
            try
            {
                _productos.Update(prod.Id, prod);
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
                _productos.Delete(id);
                return Ok("Producto Eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al eliminar el producto");
            }
        }
    }
}
