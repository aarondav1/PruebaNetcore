using AutoMapper;
using PruebaNetcore.DTOs;
using PruebaNetcore.Entities;

namespace ServicioTransporte.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<FacturaCabeceraCreacionDTO, FacturaCabecera>()
                .ForMember(fact => fact.Detalles, opciones => opciones.MapFrom(MapCabeceraDetalles));
            CreateMap<FacturaCabecera, FacturaCabeceraDTO>();
            CreateMap<FacturaCabeceraDTO, FacturaCabecera>();

            CreateMap<FacturaDetalleCreacionDTO, FacturaDetalle>();
            CreateMap<FacturaDetalle, FacturaDetalleDTO>();
            CreateMap<FacturaDetalleDTO, FacturaDetalle>();

            CreateMap<ProductoCreacionDTO, Producto>();
            CreateMap<Producto, ProductoDTO>();
            CreateMap<ProductoDTO, Producto>();

        }
        private List<FacturaDetalleDTO> MapCabeceraDetalles(FacturaCabeceraCreacionDTO facturaCabeceraCreacionDTO,
            FacturaCabecera facturaCabecera)
        {
            var resultado = new List<FacturaDetalleDTO>();
            foreach (var detalle in facturaCabeceraCreacionDTO.DetallesDTO)
            {
                resultado.Add(detalle);
            }
            return resultado;
        }
    }
}
