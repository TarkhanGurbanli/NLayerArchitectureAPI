using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities;
using NLayer.Core.Repositorys;

namespace NLayer.Repository.Repositorys
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            //Eager Loading
            //Lazy Loading bunlari arasdir

            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
