using Microsoft.EntityFrameworkCore;
using MyProductList.Data.DBOperations;
using MyProductList.Data.Models;
using MyProductList.Data.Repository.Abstract;

namespace MyProductList.Data.Repository.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.Include(x => x.Product_Categories).ThenInclude(x=>x.Category).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(x => x.Product_Categories).ThenInclude(x=>x.Category).ToListAsync();
        }
    }
}
