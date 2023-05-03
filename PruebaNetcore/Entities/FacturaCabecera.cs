namespace PruebaNetcore.Entities
{
    public class FacturaCabecera
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public List<FacturaDetalle> Detalles { get; set; }
    }
}
