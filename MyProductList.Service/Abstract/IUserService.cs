using MyProductList.Dto.Dtos;
using MyProductList.ViewModel.ViewModels.User;

namespace MyProductList.Service.Abstract
{
    public interface IUserService
    {
        public Task<UserViewModel> GetSingleUserByIdAsync(int id);
        public Task<List<UserViewModel>> GetAllUsers();
        Task UpdateUserAsync(int id,  UserDto updateResource);
        Task DeleteUsertAsync(int id);
        Task AddUserAsync(UserDto updateResource);
    }
}
