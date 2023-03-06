using AutoMapper;
using MyProductList.Data.Models;
using MyProductList.Data.Repository.Abstract;
using MyProductList.Data.UnitOfWork.Abstract;
using MyProductList.Dto.Dtos;
using MyProductList.Service.Abstract;
using MyProductList.ViewModel.ViewModels.Product;

namespace MyProductList.Service.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> genericRepository;
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IGenericRepository<Product> genericRepository, IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task AddProductAsync(ProductDto updateResource)
        {
            var product = mapper.Map<ProductDto, Product>(updateResource);

            await genericRepository.InsertAsync(product);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await genericRepository.GetByIdAsync(id);

            if (product is null)
                throw new InvalidOperationException("product not found");

            genericRepository.RemoveAsync(product);
            await unitOfWork.CompleteAsync();
        }

        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            var products = await productRepository.GetAllAsync();

            List<ProductViewModel> vm = mapper.Map<List<ProductViewModel>>(products);

            return vm;
        }

        public async Task<ProductDetailViewModel> GetSingleProductByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            ProductDetailViewModel vm = mapper.Map<ProductDetailViewModel>(product);

            return vm;
        }

        public async Task UpdateProductAsync(int id, ProductDto updateResource)
        {
            var product = await genericRepository.GetByIdAsync(id);

            if (product is null)
                throw new InvalidOperationException("product not found");

            var mapped = mapper.Map(updateResource, product);

            genericRepository.Update(mapped);
            await unitOfWork.CompleteAsync();
        }
    }
}
