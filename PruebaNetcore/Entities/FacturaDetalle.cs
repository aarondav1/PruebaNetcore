namespace PruebaNetcore.Entities
{
    public class FacturaDetalle
    {
        public int Id { get; set; }
        public int Id_Factura { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        //Propiedad de navegacion
        public Producto Producto { get; set; }
    }
}
