using MyProductList.Data.Models;
using MyProductList.Data.Repository.Abstract;

namespace MyProductList.Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<ShopList> ShopListRepository { get; }
        IGenericRepository<ProductCategory> ProductCategoryRepository { get; }
        IGenericRepository<ShopListProducts> ShopListProductRepository { get; }


        Task CompleteAsync();
    }
}
