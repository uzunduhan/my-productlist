using Microsoft.AspNetCore.Mvc;
using MyProductList.Dto.Models;
using MyProductList.Service.Abstract;

namespace MyProductList.Auth
{
    [Route("[controller]s")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenManagementService tokenManagementService;

        public TokenController(ITokenManagementService tokenManagementService)
        {
            this.tokenManagementService = tokenManagementService;
        }


        [HttpPost("token")]
        public async Task<IActionResult> LoginAsync([FromBody] TokenRequest request)
        {
            var userAgent = Request.Headers["User-Agent"].ToString();
            var result = await tokenManagementService.GenerateTokensAsync(request, DateTime.UtcNow, userAgent);

            if (result is not null)
            {
                return Ok(result);
            }

            return Unauthorized();
        }

    }
}
