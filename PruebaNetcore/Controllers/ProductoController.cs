using Microsoft.AspNetCore.Mvc;
using PruebaNetcore.DTOs;
using PruebaNetcore.Servicios;

namespace PruebaNetcore.Controllers
{
    [ApiController]
    [Route("api/Producto")]
    public class ProductoController: ControllerBase
    {
        private readonly ProductoServicios productoServicios;

        public ProductoController(ProductoServicios productoServicios)
        {
            this.productoServicios = productoServicios;
        }

        [HttpGet("ListarProductos", Name = "ListarProductos")]
        public async Task<ActionResult<List<ProductoDTO>>> ListarProductos()
        {
            try
            {
                var productos = await productoServicios.GetListaProductos();
                return productos;
            }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("{id:int}", Name = "ObtenerProductoPorId")]
        public async Task<ActionResult<ProductoDTO>> ObtenerProductoPorId(int id)
        {
            try
            {
                var producto = await productoServicios.GetProducto(id);
                if (producto == null)
                {
                    return NotFound($"No existe producto con el id {id}");
                }
                return producto;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "RegistrarProducto")]
        public async Task<ActionResult> RegistrarProducto([FromBody] ProductoCreacionDTO productoCreacionDTO)
        {
            try
            {
                await productoServicios.PostProducto(productoCreacionDTO);
                return Ok("Producto agregado exitosamente");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
