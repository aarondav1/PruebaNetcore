namespace PruebaNetcore.DTOs
{
    public class FacturaCabeceraCreacionDTO
    {
        public DateTime? Fecha { get; set; }
        public List<FacturaDetalleDTO> DetallesDTO { get; set; }
    }
}
