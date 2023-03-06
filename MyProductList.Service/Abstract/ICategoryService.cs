using MyProductList.Data.Models;
using MyProductList.Dto.Dtos;
using MyProductList.ViewModel.ViewModels.Category;

namespace MyProductList.Service.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<CategoryDetailViewModel> GetCategoryById(int id);
        Task UpdateCategoryAsync(int id, CategoryDto updateResource);
        Task AddCategoryAsync(CategoryDto updateResource);
        Task SafeDeleteCategorytAsync(int id);
    }
}
