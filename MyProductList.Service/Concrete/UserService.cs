using AutoMapper;
using MyProductList.Data.Models;
using MyProductList.Data.Repository.Abstract;
using MyProductList.Data.UnitOfWork.Abstract;
using MyProductList.Dto.Dtos;
using MyProductList.Service.Abstract;
using MyProductList.ViewModel.ViewModels.User;

namespace MyProductList.Service.Concrete
{
    public class UserService : IUserService
    {

        private readonly IGenericRepository<User> genericRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IGenericRepository<User> genericRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task AddUserAsync(UserDto updateResource)
        {
            var user = mapper.Map<UserDto, User>(updateResource);

            await genericRepository.InsertAsync(user);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteUsertAsync(int id)
        {
            var user = await genericRepository.GetByIdAsync(id);

            if (user is null)
                throw new InvalidOperationException("user not found");

            genericRepository.RemoveAsync(user);
            await unitOfWork.CompleteAsync();
        }

        public async Task<List<UserViewModel>> GetAllUsers()
        {
            var tempEntity = await genericRepository.GetAllAsync();

            List<UserViewModel> vm = mapper.Map<List<UserViewModel>>(tempEntity);

            return vm;

            throw new NotImplementedException();
        }

        public Task<UserViewModel> GetSingleUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(int id, UserDto updateResource)
        {
            var user = await genericRepository.GetByIdAsync(id);

            if (user is null)
                throw new InvalidOperationException("user not found");

            var mapped = mapper.Map(updateResource, user);

            genericRepository.Update(mapped);
            await unitOfWork.CompleteAsync();
        }

    }
}
