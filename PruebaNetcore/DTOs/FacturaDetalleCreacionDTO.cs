namespace PruebaNetcore.DTOs
{
    public class FacturaDetalleCreacionDTO
    {
        public int Id_Factura { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}
