using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProductList.Dto.Dtos;
using MyProductList.Service.Abstract;

namespace MyProductList.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsers();

            return Ok(users);
        }



        //[HttpGet("api/{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var user = await _userService.GetSingleUserByIdAsync(id);

        //    return Ok(user);
        //}


        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDto user)
        {
            //UserDtoValidator validator = new UserDtoValidator();
            //validator.ValidateAndThrow(user);

            //await _userService.isUserExistByEmail(user.Email);

            await _userService.AddUserAsync(user);

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto updatedUser)
        {
            //UserDtoValidator validator = new UserDtoValidator();
            //validator.ValidateAndThrow(updatedUser);

            await _userService.UpdateUserAsync(id, updatedUser);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            await _userService.DeleteUsertAsync(id);

            return NoContent();
        }

    }
}
