using MyProductList.Data.Models;

namespace MyProductList.Data.Repository.Abstract
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        public Task<Product> GetByIdAsync(int id);
        public Task<IEnumerable<Product>> GetAllAsync();

    }
}
