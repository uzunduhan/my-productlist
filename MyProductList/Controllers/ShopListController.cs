using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using MyProductList.Data.Models;
using MyProductList.Dto.Dtos;
using MyProductList.Queues;
using MyProductList.Service.Abstract;
using System.Security.Claims;

namespace MyProductList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopListController : ControllerBase
    {
        private readonly IShopListService _shopListService;
        private readonly IBackgroundTaskQueue<ShopListDto> _queue;

        public ShopListController(IShopListService shopListService, IBackgroundTaskQueue<ShopListDto> queue)
        {
            _shopListService = shopListService;
            _queue = queue;
        }

        [HttpGet]
        [Authorize(Roles = "User")]

        public async Task<IActionResult> GetShopLists()
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var shopLists = await _shopListService.GetAllShopLists(userId);

            return Ok(shopLists);
        }

        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetShopListsForAdmin()
        {

            var shopLists = await _shopListService.GetAllShopListsForAdmin();

            return Ok(shopLists);
        }


        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetByID(int id)
        //{
        //    var shopList = await _shopListService.GetSingleShopListByIdAsync(id);

        //    return Ok(shopList);
        //}


        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddShopList([FromBody] ShopListDto newShopList)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            //GenreDtoValidator validator = new GenreDtoValidator();

            //validator.ValidateAndThrow(newGenre);


            //await _genreService.isMovieExistByTitle(newMovie.Title);

            await _shopListService.AddShopListAsync(userId, newShopList);

            return Ok();
        }

      
        [HttpPost("AddProductToShopList")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddProductToShopList([FromBody] AddProductToShopListDto newProduct)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            //GenreDtoValidator validator = new GenreDtoValidator();

            //validator.ValidateAndThrow(newGenre);

            await _shopListService.AddProductToShopList(userId,newProduct);


            //await _genreService.isMovieExistByTitle(newMovie.Title);

            //await _shopListService.AddShopListAsync(newShopList);

            return Ok();
        }

        [HttpPost("RemoveProductToShopList")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> RemoveProductToShopList([FromBody] AddProductToShopListDto newProduct)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            //GenreDtoValidator validator = new GenreDtoValidator();

            //validator.ValidateAndThrow(newGenre);

            await _shopListService.RemoveProductToShopList(userId, newProduct);


            //await _genreService.isMovieExistByTitle(newMovie.Title);

            //await _shopListService.AddShopListAsync(newShopList);

            return Ok();
        }

        [HttpPost("MarkShopListComplete{shopListId}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> MarkShopListComplete(int shopListId)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var shopList = await _shopListService.GetSingleShopListByIdAsync(shopListId, userId);

            await _shopListService.CheckIsCompleteColumnForShopList(shopList);

             await _queue.AddQueue(shopList);


            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShopList([FromQuery] int id, [FromBody] ShopListDto updatedShopList)
        {
            //GenreDtoValidator validator = new GenreDtoValidator();
            //validator.ValidateAndThrow(updatedGenre);

            await _shopListService.UpdateShopListAsync(id, updatedShopList);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShopList([FromQuery] int id)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            await _shopListService.DeleteShopListAsync(userId, id);

            return NoContent();
        }
    }
}
