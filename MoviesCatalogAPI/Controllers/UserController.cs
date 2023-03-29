using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesCatalogAPI.Interface;
using MoviesCatalogAPI.Models;

namespace MoviesCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsers _IUser;

        public UserController(IUsers users)
        { 
            _IUser = users;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            _IUser.AddUser(user);
            return await Task.FromResult(user);
        }

    }
}
