using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaNetcore.DTOs;
using PruebaNetcore.Entities;

namespace PruebaNetcore.Servicios
{
    public class ProductoServicios
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductoServicios(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<ProductoDTO>> GetListaProductos()
        {
            var productos = await context.Productos.ToListAsync();
            return mapper.Map<List<ProductoDTO>>(productos);
        }

        public async Task<ProductoDTO> GetProducto(int id)
        {
            var producto = await context.Productos.FirstOrDefaultAsync(fDb => fDb.Id == id);
            return mapper.Map<ProductoDTO>(producto);
        }

        public async Task<ProductoCreacionDTO> PostProducto(ProductoCreacionDTO productoCreacionDTO)
        {
            var producto = mapper.Map<Producto>(productoCreacionDTO);
            context.Add(producto);
            await context.SaveChangesAsync();
            return productoCreacionDTO;
        }

    }
}
