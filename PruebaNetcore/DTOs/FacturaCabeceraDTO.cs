using PruebaNetcore.Entities;

namespace PruebaNetcore.DTOs
{
    public class FacturaCabeceraDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public List<FacturaDetalle> Detalles { get; set; }
    }
}
