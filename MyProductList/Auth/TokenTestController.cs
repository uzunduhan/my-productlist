using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProductList.Base.Types;

namespace MyProductList.Auth
{
    [Route("param/api/[controller]")]
    [ApiController]
    public class TokenTestController : ControllerBase
    {
        public TokenTestController()
        {
        }


        [HttpGet("NoToken")]
        public string NoToken()
        {
            return "No Token";
        }

        [HttpGet("Authorize")]
        [Authorize]
        public string Authorize()
        {
            return "Authorize";
        }

        [HttpGet("Admin")]
        [Authorize(Roles = Role.Admin)]
        public string Admin()
        {
            return "Admin";
        }

        [HttpGet("User")]
        [Authorize(Roles = Role.User)]
        public string User()
        {
            return "User";
        }


    }
}
