using AutoMapper;
using MyProductList.Data.Models;
using MyProductList.Dto.Dtos;
using MyProductList.ViewModel.ViewModels.Category;
using MyProductList.ViewModel.ViewModels.Product;
using MyProductList.ViewModel.ViewModels.ShopList;
using MyProductList.ViewModel.ViewModels.User;

namespace MyProductList.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Category, CategoryDetailViewModel>().ForMember(destination => destination.Products, opt => opt.MapFrom(src => src.Product_Categories.Select(x=>x.Product).ToList()));

            CreateMap<Category, CategoryViewModel>();

            CreateMap<Product, ProductForCategoryDetailViewModel>();


            CreateMap<Product, ProductDetailViewModel>().ForMember(destination => destination.Categories, opt => opt.MapFrom(src => src.Product_Categories.Select(x => x.Category).ToList()));

            CreateMap<Product, ProductViewModel>();

            CreateMap<Category, CategoryForProductViewModel>();


            CreateMap<ShopList, ShopListViewModel>().ForMember(destination => destination.Products, opt => opt.MapFrom(src => src.ShopList_Products.Select(x => x.Product).ToList()));

            CreateMap<Product, ProductForShopListDetailViewModel>();


            //CreateMap<Category, CategoryDetailViewModel>();

            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();

            // CreateMap<Category, CategoryDto>().ReverseMap().ForMember(destination => destination.Product_Categories, opt => opt.MapFrom(src => src.Product_Categories));

            CreateMap<ShopList, ShopListDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<User, UserViewModel>();

            CreateMap<ShopList, ShopListMongo>();

           // CreateMap<ShopListDto, ShopListMongo>().ForMember(dest=>dest.Id, opt=>opt.MapFrom(src=>src.))



        }
    }
}
