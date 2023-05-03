using Microsoft.EntityFrameworkCore;
using PruebaNetcore.Entities;

namespace PruebaNetcore
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //public DbSet<AsignacionBusConductor> AsignacionesBusConductor { get; set; }
        public DbSet <FacturaCabecera> FacturaCabeceras { get; set; }
        public DbSet <FacturaDetalle> FacturaDetalles { get;set; }
        public DbSet <Producto> Productos { get; set; }
    }
}
