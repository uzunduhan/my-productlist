using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using MyProductList.Data.Models;
using MyProductList.Data.Repository.Abstract;
using MyProductList.Data.Repository.Concrete;
using MyProductList.Data.UnitOfWork.Abstract;
using MyProductList.Data.UnitOfWork.Concrete;
using MyProductList.Extensions;
using MyProductList.Service.Abstract;
using MyProductList.Service.Concrete;
using MyProductList.Service.Mapper;

namespace PracticumHomeWork.Extensions
{
    public static class StartUpDIExtension
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            services.AddScoped<IGenericRepository<ShopList>, GenericRepository<ShopList>>();
            services.AddScoped<IGenericRepository<ShopListProducts>, GenericRepository<ShopListProducts>>();

            services.AddScoped<ITokenManagementService, TokenManagementService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShopListService, ShopListService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IShopListRepository, ShopListRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }

        public static void AddCustomizeSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Param Api Management", Version = "v1.0" });
                c.OperationFilter<ExtensionSwaggerFileOperationFilter>();

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Techa Management for IT Company",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // Must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
            });
        }
    }
}
