using Microsoft.AspNetCore.Mvc;
using PruebaNetcore.DTOs;
using PruebaNetcore.Servicios;

namespace PruebaNetcore.Controllers
{
    [ApiController]
    [Route("api/Factura")]
    public class FacturaController: ControllerBase
    {
        private readonly FacturaServicios facturaServicios;

        public FacturaController(FacturaServicios facturaServicios)
        {
            this.facturaServicios = facturaServicios;
        }

        [HttpGet(Name = "ListarFacturas")]
        public async Task<ActionResult<List<FacturaCabeceraDTO>>> ListarFacturas()
        {
            try
            {
                var facturas = await facturaServicios.GetListaFacturas();
                return facturas;
            }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("{id:int}", Name = "ObtenerFacturaPorId")]
        public async Task<ActionResult<FacturaCabeceraDTO>> ObtenerFacturaPorId(int id)
        {
            try
            {
                var factura = await facturaServicios.GetFactura(id);
                if (factura == null)
                {
                    return NotFound($"No existe factura con el id {id}");
                }
                return factura;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "RegistrarFactura")]
        public async Task<ActionResult> RegistrarFactura([FromBody] FacturaCabeceraCreacionDTO facturaCabeceraCreacionDTO)
        {
            try
            {
                await facturaServicios.PostFactura(facturaCabeceraCreacionDTO);
                return Ok("Factura agregada exitosamente");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
