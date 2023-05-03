namespace PruebaNetcore.DTOs
{
    public class FacturaDetalleDTO
    {
        public int Id { get; set; }
        public int Id_Factura { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        //Propiedad de navegacion
        public ProductoDTO ProductoDTO { get; set; }
    }
}
