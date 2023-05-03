using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaNetcore.DTOs;
using PruebaNetcore.Entities;

namespace PruebaNetcore.Servicios
{
    public class FacturaServicios
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public FacturaServicios(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<FacturaCabeceraDTO>> GetListaFacturas()
        {
            var facturas = await context.FacturaCabeceras.ToListAsync();
            return mapper.Map<List<FacturaCabeceraDTO>>(facturas);
        }

        public async Task<FacturaCabeceraDTO> GetFactura(int id)
        {
            var factura = await context.FacturaCabeceras.FirstOrDefaultAsync(fDb => fDb.Id == id);
            return mapper.Map<FacturaCabeceraDTO>(factura);
        }

        public async Task<FacturaCabeceraCreacionDTO> PostFactura(FacturaCabeceraCreacionDTO facturaCabeceraCreacionDTO)
        {

            var factura = mapper.Map<FacturaCabecera>(facturaCabeceraCreacionDTO);

            context.Add(factura);
            await context.SaveChangesAsync();
            return facturaCabeceraCreacionDTO;
        }
    }
}
