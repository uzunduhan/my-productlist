using AutoMapper;
using MyProductList.Data.Models;
using MyProductList.Data.Repository.Abstract;
using MyProductList.Data.UnitOfWork.Abstract;
using MyProductList.Dto.Dtos;
using MyProductList.Service.Abstract;
using MyProductList.ViewModel.ViewModels.ShopList;

namespace MyProductList.Service.Concrete
{
    public class ShopListService : IShopListService
    {
        private readonly IGenericRepository<ShopList> genericRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IGenericRepository<ShopListProducts> shopListProductRepository;
        private readonly IShopListRepository shopListRepository;

        public ShopListService(IGenericRepository<ShopList> genericRepository, IGenericRepository<ShopListProducts> shopListProductRepository, IShopListRepository shopListRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.shopListProductRepository = shopListProductRepository;
            this.shopListRepository = shopListRepository;
        }

        public async Task AddShopListAsync(int userId, ShopListDto updateResource)
        {
            var shopList = mapper.Map<ShopListDto, ShopList>(updateResource);

            shopList.UserId = userId;

            await genericRepository.InsertAsync(shopList);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteShopListAsync(int id, int userId)
        {
            var shopList = await genericRepository.GetByIdAsync(id);

            if (shopList.UserId != userId)
                throw new InvalidOperationException("shoplist not found");

            if (shopList is null)
                throw new InvalidOperationException("shoplist not found");

            genericRepository.RemoveAsync(shopList);
            await unitOfWork.CompleteAsync();
        }

        public async Task<List<ShopListViewModel>> GetAllShopListsForAdmin()
        {
            var tempEntity = await shopListRepository.GetAllWithProductsForAdminAsync();

            List<ShopListViewModel> vm = mapper.Map<List<ShopListViewModel>>(tempEntity);

            //var shopList = mapper.Map<List<ShopList>, List<ShopListDto>>((List<ShopList>)tempEntity);


            return vm;
        }


        public async Task<List<ShopListViewModel>> GetAllShopLists(int userId)
        {
            var tempEntity = await shopListRepository.GetAllWithProductsAsync(userId);

            List<ShopListViewModel> vm = mapper.Map<List<ShopListViewModel>>(tempEntity);

            //var shopList = mapper.Map<List<ShopList>, List<ShopListDto>>((List<ShopList>)tempEntity);


            return vm;
        }

        public async Task<ShopListDto> GetSingleShopListByIdAsync(int id, int userId)
        {
            var tempEntity = await shopListRepository.GetByIdAsyncWithProductsAsync(id, userId);

            if(tempEntity is null)
                throw new InvalidOperationException("shopList not found");   
            

            var shopList = mapper.Map<ShopList, ShopListDto>(tempEntity);


            return shopList;
        }

        public async Task AddProductToShopList(int userId, AddProductToShopListDto newProduct)
        {
            var tempEntity = await genericRepository.GetByIdAsync(newProduct.ShopListId);

            if (tempEntity.UserId != userId)
                throw new InvalidOperationException("shoplist not found");


            ShopListProducts shopListProduct = new()
            {
                ProductId = newProduct.ProductId,
                ShopListId = newProduct.ShopListId
            };


            await shopListProductRepository.InsertAsync(shopListProduct);

            await unitOfWork.CompleteAsync();
        }

        public async Task CheckIsCompleteColumnForShopList(ShopListDto shopList)
        {
            if (shopList.IsComplete is true)
                throw new InvalidOperationException("this list already completed");

            shopList.IsComplete = true;

            //ShopList dto = mapper.Map<ShopList>(shopList);

            //genericRepository.Update(dto);
        }
        
        public async Task GetAllShopListWithProducts(AddProductToShopListDto newProduct)
        {

            ShopListProducts shopListProduct = new()
            {
                ProductId = newProduct.ProductId,
                ShopListId = newProduct.ShopListId
            };


            await shopListProductRepository.InsertAsync(shopListProduct);

            await unitOfWork.CompleteAsync();
        }

        public async Task RemoveProductToShopList(int userId, AddProductToShopListDto newProduct)
        {
            var tempEntity = await genericRepository.GetByIdAsync(newProduct.ShopListId);

            if (tempEntity is null)
                throw new InvalidOperationException("error, cannot find shoplist or product");

            if (tempEntity.UserId != userId)
                throw new InvalidOperationException("error, cannot find shoplist or product");


            var shopListProduct = shopListProductRepository.Where(x => x.ShopListId == newProduct.ShopListId && x.ProductId == newProduct.ProductId).FirstOrDefault();

            if (shopListProduct is null)
                throw new InvalidOperationException("error, cannot find shoplist or product");




            shopListProductRepository.RemoveAsync(shopListProduct);

            await unitOfWork.CompleteAsync();
        }


        public async Task UpdateShopListAsync(int id, ShopListDto updateResource)
        {
            var shopList = await genericRepository.GetByIdAsync(id);

            if (shopList is null)
                throw new InvalidOperationException("shoplist not found");

            var mapped = mapper.Map(updateResource, shopList);

            genericRepository.Update(mapped);
            await unitOfWork.CompleteAsync();
        }

    }
}
